using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO.Compression;

namespace PacketEditor
{
    public delegate void delReceiveWebRequest(HttpListenerContext Context);

    public partial class Main : Form
    {
        // Vars
        NamedPipeServerStream pipeIn;
        NamedPipeClientStream pipeOut;
        string strDLL = Directory.GetCurrentDirectory() + "\\WSPE.dat";
        Thread trdPipeRead;
        int intTargetpID = 0;
        Glob.PipeHeader strPipeMsgOut;
        Glob.PipeHeader strPipeMsgIn;
        SockInfo sinfo = new SockInfo();
        bool filter = true;
        bool monitor = true;
        bool DNStrap = false;
        Encoding ae = Encoding.GetEncoding(28591);
        Filters frmChFilters;
        string reAttachPath;
        string BurpRequest = @"POST /?func=send()&sockid=1508 HTTP/1.1
Host: 127.0.0.1:8083
Content-Length: 62
Expect: 100-continue
Connection: Keep-Alive

DATA_TO_SEND";
        // Listen for requests
        private HttpListener listener;
        bool listen_for_requests = false;
        private bool firstRun = true;
        private string prefixes = "8083";
        public event delReceiveWebRequest ReceiveWebRequest;
        private const int RequestThreadAbortedException = 995;

        // External filter
        WebRequest req = null;
        WebResponse rsp = null;
        private string prefixes2 = "8084";
        bool externalFilter = false;
        // Wrap the request stream with a text-based writer
        StreamWriter writer = null;
        StreamReader reader = null;
        String rsptext = "";

        string reattacheDelay = "1000";

        // Flags
        [Flags]
        enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VMOperation = 0x00000008,
            VMRead = 0x00000010,
            VMWrite = 0x00000020,
            DupHandle = 0x00000040,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            Synchronize = 0x00100000
        }
        enum VirtualAllocExTypes : uint
        {
            MEM_COMMIT = 0x1000,
            MEM_RESERVE = 0x2000,
            MEM_RESET = 0x80000,
            MEM_LARGE_PAGES = 0x20000000,
            MEM_PHYSICAL = 0x400000,
            MEM_TOP_DOWN = 0x100000,
            MEM_WRITE_WATCH = 0x200000
        }
        [Flags]
        enum AccessProtectionFlags : uint
        {
            PAGE_EXECUTE = 0x10,
            PAGE_EXECUTE_READ = 0x20,
            PAGE_EXECUTE_READWRITE = 0x40,
            PAGE_EXECUTE_WRITECOPY = 0x80,
            PAGE_NOACCESS = 0x01,
            PAGE_READONLY = 0x02,
            PAGE_READWRITE = 0x04,
            PAGE_WRITECOPY = 0x08,
            PAGE_GUARD = 0x100,
            PAGE_NOCACHE = 0x200,
            PAGE_WRITECOMBINE = 0x400
        }
        enum VirtualFreeExTypes : uint
        {
            MEM_DECOMMIT = 0x4000,
            MEM_RELEASE = 0x8000
        }
        [Flags()]
        enum AllocationType : uint
        {
            COMMIT = 0x1000,
            RESERVE = 0x2000,
            RESET = 0x80000,
            LARGE_PAGES = 0x20000000,
            PHYSICAL = 0x400000,
            TOP_DOWN = 0x100000,
            WRITE_WATCH = 0x200000
        }
        [Flags()]
        enum MemoryProtection : uint
        {
            EXECUTE = 0x10,
            EXECUTE_READ = 0x20,
            EXECUTE_READWRITE = 0x40,
            EXECUTE_WRITECOPY = 0x80,
            NOACCESS = 0x01,
            READONLY = 0x02,
            READWRITE = 0x04,
            WRITECOPY = 0x08,
            GUARD_Modifierflag = 0x100,
            NOCACHE_Modifierflag = 0x200,
            WRITECOMBINE_Modifierflag = 0x400
        }

        // DLL Imports
        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess,
        IntPtr lpThreadAttributes, uint dwStackSize, IntPtr
        lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);
        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress,
           uint dwSize, AllocationType flAllocationType, MemoryProtection flProtect);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

        // SeDebug
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool OpenProcessToken(IntPtr ProcessHandle,
            UInt32 DesiredAccess, out IntPtr TokenHandle);

        private static uint STANDARD_RIGHTS_REQUIRED = 0x000F0000;
        private static uint STANDARD_RIGHTS_READ = 0x00020000;
        private static uint TOKEN_ASSIGN_PRIMARY = 0x0001;
        private static uint TOKEN_DUPLICATE = 0x0002;
        private static uint TOKEN_IMPERSONATE = 0x0004;
        private static uint TOKEN_QUERY = 0x0008;
        private static uint TOKEN_QUERY_SOURCE = 0x0010;
        private static uint TOKEN_ADJUST_PRIVILEGES = 0x0020;
        private static uint TOKEN_ADJUST_GROUPS = 0x0040;
        private static uint TOKEN_ADJUST_DEFAULT = 0x0080;
        private static uint TOKEN_ADJUST_SESSIONID = 0x0100;
        private static uint TOKEN_READ = (STANDARD_RIGHTS_READ | TOKEN_QUERY);
        private static uint TOKEN_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | TOKEN_ASSIGN_PRIMARY |
            TOKEN_DUPLICATE | TOKEN_IMPERSONATE | TOKEN_QUERY | TOKEN_QUERY_SOURCE |
            TOKEN_ADJUST_PRIVILEGES | TOKEN_ADJUST_GROUPS | TOKEN_ADJUST_DEFAULT |
            TOKEN_ADJUST_SESSIONID);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetCurrentProcess();

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool LookupPrivilegeValue(string lpSystemName, string lpName,
            out LUID lpLuid);

        public const string SE_ASSIGNPRIMARYTOKEN_NAME = "SeAssignPrimaryTokenPrivilege";
        public const string SE_AUDIT_NAME = "SeAuditPrivilege";
        public const string SE_BACKUP_NAME = "SeBackupPrivilege";
        public const string SE_CHANGE_NOTIFY_NAME = "SeChangeNotifyPrivilege";
        public const string SE_CREATE_GLOBAL_NAME = "SeCreateGlobalPrivilege";
        public const string SE_CREATE_PAGEFILE_NAME = "SeCreatePagefilePrivilege";
        public const string SE_CREATE_PERMANENT_NAME = "SeCreatePermanentPrivilege";
        public const string SE_CREATE_SYMBOLIC_LINK_NAME = "SeCreateSymbolicLinkPrivilege";
        public const string SE_CREATE_TOKEN_NAME = "SeCreateTokenPrivilege";
        public const string SE_DEBUG_NAME = "SeDebugPrivilege";
        public const string SE_ENABLE_DELEGATION_NAME = "SeEnableDelegationPrivilege";
        public const string SE_IMPERSONATE_NAME = "SeImpersonatePrivilege";
        public const string SE_INC_BASE_PRIORITY_NAME = "SeIncreaseBasePriorityPrivilege";
        public const string SE_INCREASE_QUOTA_NAME = "SeIncreaseQuotaPrivilege";
        public const string SE_INC_WORKING_SET_NAME = "SeIncreaseWorkingSetPrivilege";
        public const string SE_LOAD_DRIVER_NAME = "SeLoadDriverPrivilege";
        public const string SE_LOCK_MEMORY_NAME = "SeLockMemoryPrivilege";
        public const string SE_MACHINE_ACCOUNT_NAME = "SeMachineAccountPrivilege";
        public const string SE_MANAGE_VOLUME_NAME = "SeManageVolumePrivilege";
        public const string SE_PROF_SINGLE_PROCESS_NAME = "SeProfileSingleProcessPrivilege";
        public const string SE_RELABEL_NAME = "SeRelabelPrivilege";
        public const string SE_REMOTE_SHUTDOWN_NAME = "SeRemoteShutdownPrivilege";
        public const string SE_RESTORE_NAME = "SeRestorePrivilege";
        public const string SE_SECURITY_NAME = "SeSecurityPrivilege";
        public const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
        public const string SE_SYNC_AGENT_NAME = "SeSyncAgentPrivilege";
        public const string SE_SYSTEM_ENVIRONMENT_NAME = "SeSystemEnvironmentPrivilege";
        public const string SE_SYSTEM_PROFILE_NAME = "SeSystemProfilePrivilege";
        public const string SE_SYSTEMTIME_NAME = "SeSystemtimePrivilege";
        public const string SE_TAKE_OWNERSHIP_NAME = "SeTakeOwnershipPrivilege";
        public const string SE_TCB_NAME = "SeTcbPrivilege";
        public const string SE_TIME_ZONE_NAME = "SeTimeZonePrivilege";
        public const string SE_TRUSTED_CREDMAN_ACCESS_NAME = "SeTrustedCredManAccessPrivilege";
        public const string SE_UNDOCK_NAME = "SeUndockPrivilege";
        public const string SE_UNSOLICITED_INPUT_NAME = "SeUnsolicitedInputPrivilege";

        [StructLayout(LayoutKind.Sequential)]
        public struct LUID
        {
            public UInt32 LowPart;
            public Int32 HighPart;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hHandle);

        public const UInt32 SE_PRIVILEGE_ENABLED_BY_DEFAULT = 0x00000001;
        public const UInt32 SE_PRIVILEGE_ENABLED = 0x00000002;
        public const UInt32 SE_PRIVILEGE_REMOVED = 0x00000004;
        public const UInt32 SE_PRIVILEGE_USED_FOR_ACCESS = 0x80000000;

        [StructLayout(LayoutKind.Sequential)]
        public struct TOKEN_PRIVILEGES
        {
            public UInt32 PrivilegeCount;
            public LUID Luid;
            public UInt32 Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LUID_AND_ATTRIBUTES
        {
            public LUID Luid;
            public UInt32 Attributes;
        }

        // Use this signature if you do not want the previous state
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AdjustTokenPrivileges(IntPtr TokenHandle,
           [MarshalAs(UnmanagedType.Bool)]bool DisableAllPrivileges,
           ref TOKEN_PRIVILEGES NewState,
           UInt32 Zero,
           IntPtr Null1,
           IntPtr Null2);

        //Classes
        public class SockInfo
        {
            public string[] afamily = new string[] { "UNSPEC", "UNIX", "INET", "IMPLINK", "PUP", "CHAOS", "NS", "ISO", "ECMA", "DATAKIT", "CCITT", "SNA", "DECnet", "DLI", "LAT", "HYLINK", "APPLETALK", "NETBIOS", "MAX" };
            public string[] atype = new string[] { "", "STREAM", "DGRAM", "RAW", "RDM", "SEQPACKET" };
            public string[] sdhow = new string[] { "RECEIVE", "SEND", "BOTH" };
            public string sockidfmt = "X4";

            public string proto(int proto)
            {
                switch (proto)
                {
                    case 0:
                        return "IP";
                    case 1:
                        return "ICMP";
                    case 2:
                        return "GGP";
                    case 6:
                        return "TCP";
                    case 12:
                        return "PUP";
                    case 17:
                        return "UDP";
                    case 22:
                        return "IDP";
                    case 77:
                        return "ND";
                    case 255:
                        return "RAW";
                    case 256:
                        return "MAX";
                    default:
                        return "UNKNOWN";
                }
            }
            public string type(int type)
            {
                switch (type)
                {
                    case 0:
                        return "IP";
                    case 1:
                        return "ICMP";
                    case 2:
                        return "GGP";
                    case 6:
                        return "TCP";
                    case 12:
                        return "PUP";
                    case 17:
                        return "UDP";
                    case 22:
                        return "IDP";
                    case 77:
                        return "ND";
                    case 255:
                        return "RAW";
                    case 256:
                        return "MAX";
                    default:
                        return "UNKNOWN";
                }
            }
            public string msg(int function)
            {
                switch (function)
                {
                    case Glob.FUNC_SEND:
                        return "send()";
                    case Glob.FUNC_SENDTO:
                        return "sendto()";
                    case Glob.FUNC_WSASEND:
                        return "WSASend()";
                    case Glob.FUNC_WSASENDTO:
                        return "WSASendTo()";
                    case Glob.FUNC_WSASENDDISCONNECT:
                        return "WSASendDisconnect()";
                    case Glob.FUNC_RECV:
                        return "recv()";
                    case Glob.FUNC_RECVFROM:
                        return "recvfrom()";
                    case Glob.FUNC_WSARECV:
                        return "WSARecv()";
                    case Glob.FUNC_WSARECVFROM:
                        return "WSARecvFrom()";
                    case Glob.FUNC_WSARECVDISCONNECT:
                        return "WSARecvDisconnect()";
                    default:
                        return "";
                }
            }
            public string api(int function)
            {
                switch (function)
                {
                    case Glob.FUNC_WSAACCEPT:
                        return "WSAAccept()";
                    case Glob.FUNC_ACCEPT:
                        return "accept()";
                    case Glob.FUNC_WSACONNECT:
                        return "WSAConnect()";
                    case Glob.FUNC_CONNECT:
                        return "connect()";
                    case Glob.FUNC_WSASOCKETW_IN:
                    case Glob.FUNC_WSASOCKETW_OUT:
                        return "WSASocket()";
                    case Glob.FUNC_BIND:
                        return "bind()";
                    case Glob.CONN_WSASENDTO:
                        return "WSASendTo()";
                    case Glob.CONN_WSARECVFROM:
                        return "WSARecvFrom()";
                    case Glob.CONN_SENDTO:
                        return "sendto()";
                    case Glob.CONN_RECVFROM:
                        return "recvfrom()";
                    case Glob.FUNC_SOCKET_IN:
                    case Glob.FUNC_SOCKET_OUT:
                        return "socket()";
                    case Glob.FUNC_CLOSESOCKET:
                        return "closesocket()";
                    case Glob.FUNC_LISTEN:
                        return "listen()";
                    case Glob.FUNC_SHUTDOWN:
                        return "shutdown()";
                    case Glob.FUNC_WSASENDDISCONNECT:
                        return "WSASendDisconnect()";
                    case Glob.FUNC_WSARECVDISCONNECT:
                        return "WSARecvDisconnect()";
                    case Glob.DNS_GETHOSTNAME:
                        return "gethostname()";
                    case Glob.DNS_GETHOSTBYADDR_IN:
                    case Glob.DNS_GETHOSTBYADDR_OUT:
                        return "gethostbyaddr()";
                    case Glob.DNS_GETHOSTBYNAME_IN:
                    case Glob.DNS_GETHOSTBYNAME_OUT:
                        return "gethostbyname()";
                    default:
                        return "";
                }
            }
            public byte msgnum(string name)
            {
                switch (name)
                {
                    case "send()":
                        return Glob.FUNC_SEND;
                    case "sendto()":
                        return Glob.FUNC_SENDTO;
                    case "WSASend()":
                        return Glob.FUNC_WSASEND;
                    case "WSASendTo()":
                        return Glob.FUNC_WSASENDTO;
                    case "WSASendDisconnect()":
                        return Glob.FUNC_WSASENDDISCONNECT;
                    case "recv()":
                        return Glob.FUNC_RECV;
                    case "recvfrom()":
                        return Glob.FUNC_RECVFROM;
                    case "WSARecv()":
                        return Glob.FUNC_WSARECV;
                    case "WSARecvFrom()":
                        return Glob.FUNC_WSARECVFROM;
                    case "WSARecvDisconnect()":
                        return Glob.FUNC_WSARECVDISCONNECT;
                    default:
                        return 0;
                }
            }
            public byte apinum(string name)
            {
                switch (name)
                {
                    case "WSAAccept()":
                        return Glob.FUNC_WSAACCEPT;
                    case "accept()":
                        return Glob.FUNC_ACCEPT;
                    case "WSAConnect()":
                        return Glob.FUNC_WSACONNECT;
                    case "connect()":
                        return Glob.FUNC_CONNECT;
                    case "WSASocket()":
                        return Glob.FUNC_WSASOCKETW_IN;
                    case "bind()":
                        return Glob.FUNC_BIND;
                    case "WSASendTo()":
                        return Glob.CONN_WSASENDTO;
                    case "WSARecvFrom()":
                        return Glob.CONN_WSARECVFROM;
                    case "sendto()":
                        return Glob.CONN_SENDTO;
                    case "recvfrom()":
                        return Glob.CONN_RECVFROM;
                    case "socket()":
                        return Glob.FUNC_SOCKET_IN;
                    case "closesocket()":
                        return Glob.FUNC_CLOSESOCKET;
                    case "listen()":
                        return Glob.FUNC_LISTEN;
                    case "shutdown()":
                        return Glob.FUNC_SHUTDOWN;
                    case "gethostname()":
                        return Glob.DNS_GETHOSTNAME;
                    case "gethostbyname()":
                        return Glob.DNS_GETHOSTBYNAME_OUT;
                    case "gethostbyaddr()":
                        return Glob.DNS_GETHOSTBYADDR_OUT;
                    default:
                        return 0;
                }
            }
            public int errornum(string name)
            {
                switch (name)
                {
                    case "WSA_IO_PENDING":
                        return 10035;
                    case "WSA_OPERATION_ABORTED":
                        return 10004;
                    case "WSAEACCES":
                        return 10013;
                    case "WSAEADDRINUSE":
                        return 10048;
                    case "WSAEADDRNOTAVAIL":
                        return 10049;
                    case "WSAEAFNOSUPPORT":
                        return 10047;
                    case "WSAEALREADY":
                        return 10037;
                    case "WSAECONNABORTED":
                        return 10053;
                    case "WSAECONNREFUSED":
                        return 10061;
                    case "WSAECONNRESET":
                        return 10054;
                    case "WSAEDESTADDRREQ":
                        return 10039;
                    case "WSAEDISCON":
                        return 10101;
                    case "WSAEFAULT":
                        return 10014;
                    case "WSAEHOSTUNREACH":
                        return 10065;
                    case "WSAEINPROGRESS":
                        return 10036;
                    case "WSAEINTR":
                        return 10004;
                    case "WSAEINVAL":
                        return 10022;
                    case "WSAEISCONN":
                        return 10056;
                    case "WSAEMFILE":
                        return 10024;
                    case "WSAEMSGSIZE":
                        return 10040;
                    case "WSAENETDOWN":
                        return 10050;
                    case "WSAENETRESET":
                        return 10052;
                    case "WSAENETUNREACH":
                        return 10051;
                    case "WSAENOBUFS":
                        return 10055;
                    case "WSAENOPROTOOPT":
                        return 10042;
                    case "WSAENOTCONN":
                        return 10057;
                    case "WSAENOTSOCK":
                        return 10038;
                    case "WSAEOPNOTSUPP":
                        return 10045;
                    case "WSAEPROTONOSUPPORT":
                        return 10043;
                    case "WSAEPROTOTYPE":
                        return 10041;
                    case "WSAESHUTDOWN":
                        return 10058;
                    case "WSAESOCKTNOSUPPORT":
                        return 10044;
                    case "WSAETIMEDOUT":
                        return 10060;
                    case "WSAEWOULDBLOCK":
                        return 10035;
                    case "WSAHOST_NOT_FOUND":
                        return 11001;
                    case "WSANO_DATA":
                        return 11004;
                    case "WSANO_RECOVERY":
                        return 11003;
                    case "WSANOTINITIALISED":
                        return 10093;
                    case "WSATRY_AGAIN":
                        return 11002;
                    case "NO_ERROR":
                    default:
                        return 0;
                }
            }
            public string error(int error)
            {
                switch (error)
                {
                    case 10013:
                        return "WSAEACCES";
                    case 10048:
                        return "WSAEADDRINUSE";
                    case 10049:
                        return "WSAEADDRNOTAVAIL";
                    case 10047:
                        return "WSAEAFNOSUPPORT";
                    case 10037:
                        return "WSAEALREADY";
                    case 10053:
                        return "WSAECONNABORTED";
                    case 10061:
                        return "WSAECONNREFUSED";
                    case 10054:
                        return "WSAECONNRESET";
                    case 10039:
                        return "WSAEDESTADDRREQ";
                    case 10101:
                        return "WSAEDISCON";
                    case 10014:
                        return "WSAEFAULT";
                    case 10065:
                        return "WSAEHOSTUNREACH";
                    case 10036:
                        return "WSAEINPROGRESS";
                    case 10004:
                        return "WSAEINTR";
                    case 10022:
                        return "WSAEINVAL";
                    case 10056:
                        return "WSAEISCONN";
                    case 10024:
                        return "WSAEMFILE";
                    case 10040:
                        return "WSAEMSGSIZE";
                    case 10050:
                        return "WSAENETDOWN";
                    case 10052:
                        return "WSAENETRESET";
                    case 10051:
                        return "WSAENETUNREACH";
                    case 10055:
                        return "WSAENOBUFS";
                    case 10042:
                        return "WSAENOPROTOOPT";
                    case 10057:
                        return "WSAENOTCONN";
                    case 10038:
                        return "WSAENOTSOCK";
                    case 10045:
                        return "WSAEOPNOTSUPP";
                    case 10043:
                        return "WSAEPROTONOSUPPORT";
                    case 10041:
                        return "WSAEPROTOTYPE";
                    case 10058:
                        return "WSAESHUTDOWN";
                    case 10044:
                        return "WSAESOCKTNOSUPPORT";
                    case 10060:
                        return "WSAETIMEDOUT";
                    case 10035:
                        return "WSAEWOULDBLOCK";
                    case 11001:
                        return "WSAHOST_NOT_FOUND";
                    case 11004:
                        return "WSANO_DATA";
                    case 11003:
                        return "WSANO_RECOVERY";
                    case 10093:
                        return "WSANOTINITIALISED";
                    case 11002:
                        return "WSATRY_AGAIN";
                    case 0:
                    default:
                        return "NO_ERROR";
                }
            }
        }
        // Functions
        bool invokeDLL()
        {
            //Named Pipes
            pipeOut = new NamedPipeClientStream(".", "wspe.send." + intTargetpID.ToString("X8"), PipeDirection.Out, PipeOptions.Asynchronous);
            try
            {
                pipeIn = new NamedPipeServerStream("wspe.recv." + intTargetpID.ToString("X8"), PipeDirection.In, 1, PipeTransmissionMode.Message);
            }
            catch
            {
                MessageBox.Show("Cannot attach to process!\n\nA previous instance could still be loaded in the targets memory waiting to unload.\nTry flushing sockets by sending/receiving data to clear blocking sockets.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                intTargetpID = 0;
                return false;
            }
            // Inject WSPE.dat from current directory
            IntPtr hProc = OpenProcess(ProcessAccessFlags.All, false, intTargetpID);
            IntPtr ptrLoadLib = GetProcAddress(GetModuleHandle("KERNEL32.DLL"), "LoadLibraryA");

            if (hProc == IntPtr.Zero)
            {
                MessageBox.Show("Cannot open process.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            IntPtr ptrMem = VirtualAllocEx(hProc, (IntPtr)0, (uint)strDLL.Length, AllocationType.COMMIT, MemoryProtection.EXECUTE_READ);
            if (ptrMem == IntPtr.Zero)
            {
                MessageBox.Show("Cannot allocate process memory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            byte[] dbDLL = ae.GetBytes(strDLL);
            int ipTmp = 0;

            if (!WriteProcessMemory(hProc, ptrMem, dbDLL, (uint)dbDLL.Length, out ipTmp))
            {
                MessageBox.Show("Cannot write to process memory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            CreateRemoteThread(hProc, IntPtr.Zero, 0, ptrLoadLib, ptrMem, 0, IntPtr.Zero);

            pipeIn.WaitForConnection();
            pipeOut.Connect();

            string RegName = "PacketEditor.com";
            string RegKey = "7007C8466C99901EF555008BF90D0C0F11C2005CE042C84B7C1E2C0050DF305647026513";

            pipeOut.Write(BitConverter.GetBytes(RegName.Length), 0, 1);
            pipeOut.Write(ae.GetBytes(RegName), 0, RegName.Length);
            pipeOut.Write(ae.GetBytes(RegKey), 0, RegKey.Length);

            trdPipeRead = new Thread(new ThreadStart(this.PipeRead));
            trdPipeRead.IsBackground = true;
            trdPipeRead.Start();
            return true;
        }
        byte[] trimzeros(byte[] bytes)
        {
            int i;
            for (i = bytes.Length - 1; i != 0 && bytes[i] == 0; i--)
            { }
            if (i != bytes.Length - 1)
            {
                byte[] b = new byte[++i];
                for (i = 0; i != b.Length; i++)
                {
                    b[i] = bytes[i];
                }
                return b;
            }
            else
                return bytes;
        }
        string hexstringtoaddy(string s)
        {
            string r = "";

            for (int i = 0; i < s.Length; i += 2)
            {
                r += byte.Parse(s.Substring(i, 2), System.Globalization.NumberStyles.HexNumber).ToString();
                if (i != 6)
                    r += ".";
            }
            return r;
        }
        string bytestoaddy(byte[] bytes)
        {
            string r = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                r += bytes[i].ToString();
                if (i != 3)
                    r += ".";
            }
            return r;
        }
        string bytestohexstring(byte[] bytes)
        {
            string result = "";
            foreach (byte b in bytes)
            {
                result += b.ToString("X2");
            }
            return result;

        }
        byte[] hexstringtobyte(string s)
        {
            byte[] b = new byte[s.Length / 2];

            for (int i = 0; i < s.Length; i += 2)
            {
                b[i / 2] = byte.Parse(s.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
            }
            return b;
        }
        Glob.sockaddr_in addyporttosockaddy(string s, Glob.sockaddr_in sa)
        {
            IPAddress ip = IPAddress.Parse(s.Substring(0, s.IndexOf(":")));
            byte[] ipb = ip.GetAddressBytes();
            sa.s_b1 = ipb[0];
            sa.s_b2 = ipb[1];
            sa.s_b3 = ipb[2];
            sa.s_b4 = ipb[3];
            sa.sin_port = UInt16.Parse(s.Substring(s.IndexOf(":") + 1, s.Length - s.IndexOf(":") - 1));
            return sa;
        }
        Glob.sockaddr_in hexaddyporttosockaddy(string s, Glob.sockaddr_in sa)
        {
            IPAddress ip = IPAddress.Parse(int.Parse(s.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString() + "." + int.Parse(s.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString() + "." + int.Parse(s.Substring(4, 2), System.Globalization.NumberStyles.HexNumber).ToString() + "." + int.Parse(s.Substring(6, 2), System.Globalization.NumberStyles.HexNumber).ToString());
            byte[] ipb = ip.GetAddressBytes();
            sa.s_b1 = ipb[0];
            sa.s_b2 = ipb[1];
            sa.s_b3 = ipb[2];
            sa.s_b4 = ipb[3];
            sa.sin_port = UInt16.Parse(s.Substring(8, 4), System.Globalization.NumberStyles.HexNumber);
            return sa;
        }
        void writepipe()
        {
            try
            {
                pipeOut.Write(Glob.RawSerializeEx(strPipeMsgOut), 0, Marshal.SizeOf(strPipeMsgOut));
            }
            catch
            {
            }
        }
        delegate void UpdateMainGridDelegate(byte[] data);
        delegate void UpdateTreeDelegate(byte[] data);
        delegate void ProcessExitedDelegate();
        void UpdateMainGrid(byte[] data)
        {
            int i = 0;
            bool changed_by_internal_filter = false;
            bool changed_by_external_filter = false;
            //backup because it will changed later
            bool monitor_original = monitor;
            DataGridViewCellStyle dvs = new DataGridViewCellStyle();
            
            // If ExternalFilter is true, it will added the line later, after verify the monitor flag
            if ((externalFilter == false || filter == false) && monitor == true)
                i = dgridMain.Rows.Add();

            // External filter run only if also the filter option in menu is true
            if (filter && externalFilter)
                try
                {
                    // send to external filter
                    req = WebRequest.Create("http://127.0.0.1:" + prefixes2 + "/?func=" + sinfo.msg(strPipeMsgIn.function).ToString() + "&sockid=" + strPipeMsgIn.sockid);
                    //req.Proxy = WebProxy.GetDefaultProxy(); // Enable if using proxy
                    req.Method = "POST";        // Post method
                    //req.ContentType = "text/html";     // content type
                    //req.ContentType = "multipart/form-data";
                    
                    // Write the text into the stream
                    writer = new StreamWriter(req.GetRequestStream());
                    writer.WriteLine(ae.GetString(data));
                    writer.Close();

                    // Send the data to the webserver and read the response
                    rsp = req.GetResponse();
                    reader = new StreamReader(rsp.GetResponseStream(), Encoding.UTF8);
                    rsptext = reader.ReadToEnd();

                    // check monitor (the first) flag
                    if (rsptext[0] == '0' || monitor == false)
                        monitor = false;
                    else
                    {
                        monitor = true;
                        i = dgridMain.Rows.Add();
                    }

                    // check color (the second) flag
                    if (monitor)
                    {
                        switch (rsptext[1])
                        {
                            case '1':
                                dvs.ForeColor = Color.Green;
                                break;
                            case '2':
                                dvs.ForeColor = Color.Red;
                                break;
                        }
                        dgridMain.Rows[i].Cells["data"].Style = dvs;
                    }

                    // cut the falgs chars and the two new lines that finished the response
                    rsptext = rsptext.Substring(2, rsptext.Length - 4);

                    if (rsptext != ae.GetString(data))
                    {
                        changed_by_external_filter = true;
                        strPipeMsgOut.command = Glob.CMD_FILTER;
                    }
                    
                    data = ae.GetBytes(rsptext);
                }
                catch (WebException webEx)
                {
                    MessageBox.Show(webEx.Message);
                }
                catch (Exception ex)
                {
                    // handle error
                    MessageBox.Show(ex.Message);
                }

            // Internal filter
            if (filter == true)
            {
                DataRow[] rows = dsMain.Tables["filters"].Select("enabled = true");
                strPipeMsgOut.command = Glob.CMD_FILTER;

                for (int x = 0; x < rows.Length; x++)
                {
                    foreach (byte bf in (byte[])rows[x]["MsgFunction"])
                    {
                        if (bf == strPipeMsgIn.function)
                        {
                            switch ((byte)rows[x]["MsgAction"])
                            {
                                case Glob.ActionReplaceString:
                                    if (Regex.IsMatch(ae.GetString(data), rows[x]["MsgCatch"].ToString()))
                                    {
                                        try
                                        {
                                            data = ae.GetBytes(Regex.Replace(ae.GetString(data), rows[x]["MsgCatch"].ToString(), rows[x]["MsgReplace"].ToString(), RegexOptions.Multiline | RegexOptions.Compiled));
                                            changed_by_internal_filter = true;
                                        }
                                        catch
                                        {
                                            dvs.ForeColor = Color.Red;
                                            if (monitor == true)
                                                dgridMain.Rows[i].Cells["data"].Style = dvs;
                                        }
                                    }
                                    break;
                                case Glob.ActionReplaceStringH: // Convert result to bytes of valid data, not hex
                                    if (Regex.IsMatch(bytestohexstring(data), rows[x]["MsgCatch"].ToString()))
                                    {
                                        try
                                        {
                                            data = hexstringtobyte(Regex.Replace(bytestohexstring(data), rows[x]["MsgCatch"].ToString(), rows[x]["MsgReplace"].ToString(), RegexOptions.Multiline | RegexOptions.Compiled | RegexOptions.IgnoreCase));
                                            changed_by_internal_filter = true;
                                        }
                                        catch
                                        {
                                            dvs.ForeColor = Color.Red;
                                            if (monitor == true)
                                                dgridMain.Rows[i].Cells["data"].Style = dvs;
                                        }
                                    }
                                    break;
                                case Glob.ActionError:
                                    if (Regex.IsMatch(ae.GetString(data), rows[x]["MsgCatch"].ToString()))
                                    {
                                        strPipeMsgOut.extra = (int)rows[x]["MsgError"];
                                        strPipeMsgOut.datasize = 0;
                                        writepipe();
                                        dvs.ForeColor = Color.DarkGray;
                                        if (monitor == true)
                                            dgridMain.Rows[i].Cells["data"].Style = dvs;
                                        goto skipfilter;
                                    }
                                    break;
                                case Glob.ActionErrorH:
                                    if (Regex.IsMatch(bytestohexstring(data), rows[x]["MsgCatch"].ToString()))
                                    {
                                        strPipeMsgOut.extra = (int)rows[x]["MsgError"];
                                        strPipeMsgOut.datasize = 0;
                                        writepipe();
                                        dvs.ForeColor = Color.DarkGray;
                                        if (monitor == true)
                                            dgridMain.Rows[i].Cells["data"].Style = dvs;
                                        goto skipfilter;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            
            if (changed_by_internal_filter == false && changed_by_external_filter == false)
            {
                strPipeMsgOut.datasize = 0;
                strPipeMsgOut.extra = 0; // Error
                writepipe();
            }
            else
            {
                strPipeMsgOut.datasize = data.Length;
                strPipeMsgOut.extra = 0;
                writepipe();
                pipeOut.Write(data, 0, data.Length);
                if (changed_by_internal_filter)
                {
                    dvs.ForeColor = Color.Green;
                    if (monitor == true)
                        dgridMain.Rows[i].Cells["data"].Style = dvs;
                }
            }
            
        skipfilter:
            DataRow drsock = dsMain.Tables["sockets"].Rows.Find(strPipeMsgIn.sockid);
            if (drsock != null)
            {
                if ((drsock["proto"].ToString() != String.Empty) && (monitor == true))
                    dgridMain.Rows[i].Cells["proto"].Value = sinfo.proto((int)drsock["proto"]);
                drsock["lastmsg"] = strPipeMsgIn.function;
            }
            else
            {
                drsock = dsMain.Tables["sockets"].NewRow();
                drsock["socket"] = strPipeMsgIn.sockid;
                drsock["lastmsg"] = strPipeMsgIn.function;
                dsMain.Tables["sockets"].Rows.Add(drsock);
            }

            if (monitor)
            {
                String method = sinfo.msg(strPipeMsgIn.function).ToString();
                // "ecv" catch recv & Recv, "end" catch send & Send. to catch all methods (like sendto).
                if (method.Contains("ecv") && showrecvRecvAllToolStripMenuItem.Checked == true ||
                                    method.Contains("end") && showToolStripMenuItem.Checked == true)
                {
                }
                else
                {
                    dgridMain.Rows[i].Visible = false;
                    //dgridMain.Rows.Remove(dgridMain.Rows[i]);
                }

                dgridMain.Rows[i].Cells["time"].Value = DateTime.Now.ToLongTimeString();
                dgridMain.Rows[i].Cells["socket"].Value = strPipeMsgIn.sockid.ToString(sinfo.sockidfmt);
                dgridMain.Rows[i].Cells["method"].Value = sinfo.msg(strPipeMsgIn.function);
                dgridMain.Rows[i].Cells["rawdata"].Value = data;
                dgridMain.Rows[i].Cells["data"].Value = ae.GetString(data);
                dgridMain.Rows[i].Cells["size"].Value = data.Length;
            }

            monitor = monitor_original;
        }

        void UpdateTree(byte[] data)
        {
            TreeNode basenode = new TreeNode();
            TreeNode rootnode;
            Glob.sockaddr_in sockaddr;
            DataRow drsock = dsMain.Tables["sockets"].Rows.Find(strPipeMsgIn.sockid);
            bool changed_by_internal_filter = false;
            string addr;

            if (drsock != null)
            {
                drsock["lastapi"] = strPipeMsgIn.function;
            }
            else
            {
                if (strPipeMsgIn.sockid != 0)
                {
                    drsock = dsMain.Tables["sockets"].NewRow();
                    drsock["socket"] = strPipeMsgIn.sockid;
                    drsock["lastapi"] = strPipeMsgIn.function;
                    dsMain.Tables["sockets"].Rows.Add(drsock);
                }
            }

            //Glob.RawDeserializeEx();
            switch (strPipeMsgIn.command)
            {
                case Glob.CMD_STRUCTDATA:
                    string socklr;
                    switch (strPipeMsgIn.function)
                    {
                        case Glob.FUNC_WSAACCEPT:
                        case Glob.FUNC_ACCEPT:
                            if (monitor == true)
                                rootnode = treeAPI.Nodes.Add(DateTime.Now.ToLongTimeString() + " " + sinfo.api(strPipeMsgIn.function));
                            else
                                rootnode = new TreeNode();
                            rootnode.Nodes.Add("socket: " + strPipeMsgIn.sockid.ToString(sinfo.sockidfmt));
                            rootnode.Nodes.Add("new socket: " + strPipeMsgIn.extra.ToString(sinfo.sockidfmt));
                            DataRow drsock2 = dsMain.Tables["sockets"].Rows.Find(strPipeMsgIn.extra);
                            if (drsock2 != null)
                            {
                                drsock2["lastapi"] = strPipeMsgIn.function;
                            }
                            else
                            {
                                if (strPipeMsgIn.extra != 0)
                                {
                                    drsock2 = dsMain.Tables["sockets"].NewRow();
                                    drsock2["socket"] = strPipeMsgIn.extra;
                                    drsock2["lastapi"] = strPipeMsgIn.function;
                                    dsMain.Tables["sockets"].Rows.Add(drsock2);
                                }
                            }
                            goto sockaddrl;
                        case Glob.FUNC_BIND:
                        case Glob.CONN_WSARECVFROM:
                        case Glob.CONN_RECVFROM:
                        sockaddrl:
                            socklr = "local";
                            goto sockaddr;
                        case Glob.FUNC_WSACONNECT:
                        case Glob.FUNC_CONNECT:
                        case Glob.CONN_WSASENDTO:
                        case Glob.CONN_SENDTO:
                            socklr = "remote";
                        sockaddr:
                            string addrport = "";
                            string hexaddrport = "";
                            byte tempbyte;
                            if (monitor == true)
                                rootnode = treeAPI.Nodes.Add(DateTime.Now.ToLongTimeString() + " " + sinfo.api(strPipeMsgIn.function));
                            else
                                rootnode = new TreeNode();
                            rootnode.Nodes.Add("socket: " + strPipeMsgIn.sockid.ToString(sinfo.sockidfmt));
                            if (data.Length == 16)
                            {
                                tempbyte = data[2];
                                data[2] = data[3];
                                data[3] = tempbyte;

                                sockaddr = (Glob.sockaddr_in)Glob.RawDeserializeEx(data, typeof(Glob.sockaddr_in));
                                addrport = sockaddr.s_b1.ToString() + "." + sockaddr.s_b2.ToString() + "." + sockaddr.s_b3.ToString() + "." + sockaddr.s_b4.ToString() + ":" + sockaddr.sin_port.ToString();
                                hexaddrport = sockaddr.s_b1.ToString("X2") + sockaddr.s_b2.ToString("X2") + sockaddr.s_b3.ToString("X2") + sockaddr.s_b4.ToString("X2") + sockaddr.sin_port.ToString("X4");
                                drsock[socklr] = addrport;
                                if ((sockaddr.sin_family >= 0) && (sockaddr.sin_family <= sinfo.afamily.Length - 1))
                                {
                                    rootnode.Nodes.Add("family: " + sockaddr.sin_family.ToString() + " (" + sinfo.afamily[sockaddr.sin_family] + ")");
                                }
                                else
                                {
                                    rootnode.Nodes.Add("family: " + sockaddr.sin_family.ToString());
                                }
                                rootnode.Nodes.Add("port: " + sockaddr.sin_port.ToString());
                                addr = sockaddr.s_b1.ToString() + "." + sockaddr.s_b2.ToString() + "." + sockaddr.s_b3.ToString() + "." + sockaddr.s_b4.ToString();
                                drsock = dsMain.Tables["dns"].Rows.Find(addr);
                                if (drsock != null)
                                {
                                    addr += " (" + drsock["host"] + ")";
                                }
                                rootnode.Nodes.Add("addr: " + addr);
                            }
                            else
                            {
                                // IPv6
                                sockaddr = (Glob.sockaddr_in)Glob.RawDeserializeEx(data, typeof(Glob.sockaddr_in));
                            }


                            if (filter == true)
                            {
                                DataRow[] rows = dsMain.Tables["filters"].Select("enabled = true");
                                strPipeMsgOut.command = Glob.CMD_FILTER;

                                for (int x = 0; x < rows.Length; x++)
                                {
                                    foreach (byte bf in (byte[])rows[x]["APIFunction"])
                                    {
                                        if (bf == strPipeMsgIn.function)
                                        {
                                            switch ((byte)rows[x]["APIAction"])
                                            {
                                                case Glob.ActionReplaceString:
                                                    try
                                                    {
                                                        if (Regex.IsMatch(addrport, rows[x]["APICatch"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase))
                                                        {
                                                            sockaddr = addyporttosockaddy(Regex.Replace(addrport, rows[x]["APICatch"].ToString(), rows[x]["APIReplace"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase), sockaddr);
                                                            data = Glob.RawSerializeEx(sockaddr);
                                                            tempbyte = data[2];
                                                            data[2] = data[3];
                                                            data[3] = tempbyte;
                                                            addr = sockaddr.s_b1.ToString() + "." + sockaddr.s_b2.ToString() + "." + sockaddr.s_b3.ToString() + "." + sockaddr.s_b4.ToString();
                                                            rootnode.Nodes.Add("new port: " + sockaddr.sin_port.ToString()).ForeColor = Color.Green;
                                                            rootnode.Nodes.Add("new addr: " + addr).ForeColor = Color.Green;
                                                            changed_by_internal_filter = true;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        rootnode.ForeColor = Color.Red;
                                                    }

                                                    break;
                                                case Glob.ActionReplaceStringH:
                                                    try
                                                    {
                                                        if (Regex.IsMatch(hexaddrport, rows[x]["APICatch"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase))
                                                        {
                                                            sockaddr = hexaddyporttosockaddy(Regex.Replace(hexaddrport, rows[x]["APICatch"].ToString(), rows[x]["APIReplace"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase), sockaddr);
                                                            data = Glob.RawSerializeEx(sockaddr);
                                                            tempbyte = data[2];
                                                            data[2] = data[3];
                                                            data[3] = tempbyte;
                                                            addr = sockaddr.s_b1.ToString() + "." + sockaddr.s_b2.ToString() + "." + sockaddr.s_b3.ToString() + "." + sockaddr.s_b4.ToString();
                                                            rootnode.Nodes.Add("new port: " + sockaddr.sin_port.ToString()).ForeColor = Color.Green;
                                                            rootnode.Nodes.Add("new addr: " + addr).ForeColor = Color.Green;
                                                            changed_by_internal_filter = true;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        rootnode.ForeColor = Color.Red;
                                                    }

                                                    break;
                                                case Glob.ActionError:
                                                    try
                                                    {
                                                        if (Regex.IsMatch(bytestoaddy(data), rows[x]["APICatch"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase))
                                                        {
                                                            strPipeMsgOut.extra = (int)rows[x]["APIError"];
                                                            strPipeMsgOut.datasize = 0;
                                                            writepipe();
                                                            rootnode.ForeColor = Color.DarkGray;
                                                            changed_by_internal_filter = true;
                                                            goto skipfilterAPI2;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        rootnode.ForeColor = Color.Red;
                                                    }
                                                    break;
                                                case Glob.ActionErrorH:
                                                    try
                                                    {
                                                        if (Regex.IsMatch(bytestohexstring(data), rows[x]["APICatch"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase))
                                                        {
                                                            strPipeMsgOut.extra = (int)rows[x]["APIError"];
                                                            strPipeMsgOut.datasize = 0;
                                                            writepipe();
                                                            rootnode.ForeColor = Color.DarkGray;
                                                            changed_by_internal_filter = true;
                                                            goto skipfilterAPI2;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        rootnode.ForeColor = Color.Red;
                                                    }
                                                    break;
                                            }
                                        }
                                    }
                                }
                                if (changed_by_internal_filter == false)
                                {
                                    strPipeMsgOut.datasize = 0;
                                    strPipeMsgOut.extra = 0; // Error
                                    writepipe();
                                    changed_by_internal_filter = true;
                                }
                                else
                                {
                                    strPipeMsgOut.datasize = data.Length;
                                    strPipeMsgOut.extra = 0;
                                    writepipe();
                                    pipeOut.Write(data, 0, data.Length);
                                    rootnode.ForeColor = Color.Green;
                                }
                            }
                        skipfilterAPI2:
                            break;
                        case Glob.FUNC_WSASOCKETW_IN:
                        case Glob.FUNC_SOCKET_IN:
                            if (monitor == true)
                                rootnode = treeAPI.Nodes.Add(DateTime.Now.ToLongTimeString() + " " + sinfo.api(strPipeMsgIn.function));
                            else
                                rootnode = new TreeNode();
                            if (filter == true)
                            {
                                DataRow[] rows = dsMain.Tables["filters"].Select("enabled = true");
                                strPipeMsgOut.command = Glob.CMD_FILTER;
                                for (int x = 0; x < rows.Length; x++)
                                {
                                    foreach (byte bf in (byte[])rows[x]["APIFunction"])
                                    {
                                        if (bf == strPipeMsgIn.function)
                                        {
                                            switch ((byte)rows[x]["APIAction"])
                                            {
                                                case Glob.ActionError:
                                                case Glob.ActionErrorH:
                                                    strPipeMsgOut.extra = (int)rows[x]["APIError"];
                                                    strPipeMsgOut.datasize = 0;
                                                    writepipe();
                                                    rootnode.ForeColor = Color.DarkGray;
                                                    changed_by_internal_filter = true;
                                                    goto skipfilterAPI1;
                                            }
                                        }
                                    }
                                }
                                strPipeMsgOut.datasize = 0;
                                strPipeMsgOut.extra = 0; // Error
                                writepipe();
                                changed_by_internal_filter = true;
                            }
                        skipfilterAPI1:
                            rootnode.Nodes.Add("socket: " + strPipeMsgIn.sockid.ToString(sinfo.sockidfmt));
                            drsock["fam"] = Convert.ToInt32(data[0]);
                            drsock["type"] = Convert.ToInt32(data[4]);
                            drsock["proto"] = Convert.ToInt32(data[8]);
                            if ((Convert.ToInt32(data[0]) >= 0) && (Convert.ToInt32(data[0]) <= sinfo.afamily.Length - 1))
                            {
                                rootnode.Nodes.Add("family: " + Convert.ToInt32(data[0]).ToString() + " (" + sinfo.afamily[Convert.ToInt32(data[0])] + ")");
                            }
                            else
                            {
                                rootnode.Nodes.Add("family: " + Convert.ToInt32(data[0]).ToString());
                            }
                            if ((Convert.ToInt32(data[4]) >= 1) && (Convert.ToInt32(data[4]) <= sinfo.atype.Length))
                            {
                                rootnode.Nodes.Add("type: " + Convert.ToInt32(data[4]).ToString() + " (" + sinfo.atype[Convert.ToInt32(data[4])] + ")");
                            }
                            else
                            {
                                rootnode.Nodes.Add("type: " + Convert.ToInt32(data[4]).ToString());
                            }
                            rootnode.Nodes.Add("protocol: " + Convert.ToInt32(data[8]) + " (" + sinfo.proto(Convert.ToInt32(data[8])) + ")");
                            break;
                        case Glob.FUNC_WSASOCKETW_OUT:
                        case Glob.FUNC_SOCKET_OUT:
                            break;
                    }
                    break;
                case Glob.CMD_NODATA:
                    switch (strPipeMsgIn.function)
                    {
                        case Glob.FUNC_WSAACCEPT:
                        case Glob.FUNC_ACCEPT:
                            if (monitor == true)
                                rootnode = treeAPI.Nodes.Add(DateTime.Now.ToLongTimeString() + " " + sinfo.api(strPipeMsgIn.function));
                            else
                                rootnode = new TreeNode();
                            if (filter == true)
                            {
                                DataRow[] rows = dsMain.Tables["filters"].Select("enabled = true");
                                strPipeMsgOut.command = Glob.CMD_FILTER;
                                for (int x = 0; x < rows.Length; x++)
                                {
                                    foreach (byte bf in (byte[])rows[x]["APIFunction"])
                                    {
                                        if (bf == strPipeMsgIn.function)
                                        {
                                            switch ((byte)rows[x]["APIAction"])
                                            {
                                                case Glob.ActionError:
                                                case Glob.ActionErrorH:
                                                    strPipeMsgOut.extra = (int)rows[x]["APIError"];
                                                    strPipeMsgOut.datasize = 0;
                                                    writepipe();
                                                    rootnode.ForeColor = Color.DarkGray;
                                                    changed_by_internal_filter = true;
                                                    goto skipfilterAPI1;
                                            }
                                        }
                                    }
                                }
                                strPipeMsgOut.datasize = 0;
                                strPipeMsgOut.extra = 0; // Error
                                writepipe();
                                changed_by_internal_filter = true;
                            }
                        skipfilterAPI1:
                            rootnode.Nodes.Add("socket: " + strPipeMsgIn.sockid.ToString(sinfo.sockidfmt));
                            rootnode.Nodes.Add("new socket: " + strPipeMsgIn.extra.ToString(sinfo.sockidfmt));
                            DataRow drsock2 = dsMain.Tables["sockets"].Rows.Find(strPipeMsgIn.extra);
                            if (drsock2 != null)
                            {
                                drsock2["lastapi"] = strPipeMsgIn.function;
                            }
                            else
                            {
                                if (strPipeMsgIn.extra != 0)
                                {
                                    drsock2 = dsMain.Tables["sockets"].NewRow();
                                    drsock2["socket"] = strPipeMsgIn.extra;
                                    drsock2["lastapi"] = strPipeMsgIn.function;
                                    dsMain.Tables["sockets"].Rows.Add(drsock2);
                                }
                            }
                            break;
                        case Glob.FUNC_CLOSESOCKET:
                        case Glob.FUNC_LISTEN:
                        case Glob.FUNC_WSASENDDISCONNECT:
                        case Glob.FUNC_WSARECVDISCONNECT:
                            if (monitor == true)
                                rootnode = treeAPI.Nodes.Add(DateTime.Now.ToLongTimeString() + " " + sinfo.api(strPipeMsgIn.function));
                            else
                                rootnode = new TreeNode();
                            if (filter == true)
                            {
                                DataRow[] rows = dsMain.Tables["filters"].Select("enabled = true");
                                strPipeMsgOut.command = Glob.CMD_FILTER;
                                for (int x = 0; x < rows.Length; x++)
                                {
                                    foreach (byte bf in (byte[])rows[x]["APIFunction"])
                                    {
                                        if (bf == strPipeMsgIn.function)
                                        {
                                            switch ((byte)rows[x]["APIAction"])
                                            {
                                                case Glob.ActionError:
                                                case Glob.ActionErrorH:
                                                    strPipeMsgOut.extra = (int)rows[x]["APIError"];
                                                    strPipeMsgOut.datasize = 0;
                                                    writepipe();
                                                    rootnode.ForeColor = Color.DarkGray;
                                                    changed_by_internal_filter = true;
                                                    goto skipfilterAPI2;
                                            }
                                        }
                                    }
                                }
                                strPipeMsgOut.datasize = 0;
                                strPipeMsgOut.extra = 0; // Error
                                writepipe();
                                changed_by_internal_filter = true;
                            }
                        skipfilterAPI2:
                            rootnode.Nodes.Add("socket: " + strPipeMsgIn.sockid.ToString(sinfo.sockidfmt));
                            break;
                        case Glob.FUNC_SHUTDOWN:
                            if (monitor == true)
                                rootnode = treeAPI.Nodes.Add(DateTime.Now.ToLongTimeString() + " " + sinfo.api(strPipeMsgIn.function));
                            else
                                rootnode = new TreeNode();
                            if (filter == true)
                            {
                                DataRow[] rows = dsMain.Tables["filters"].Select("enabled = true");
                                strPipeMsgOut.command = Glob.CMD_FILTER;
                                for (int x = 0; x < rows.Length; x++)
                                {
                                    foreach (byte bf in (byte[])rows[x]["APIFunction"])
                                    {
                                        if (bf == strPipeMsgIn.function)
                                        {
                                            switch ((byte)rows[x]["APIAction"])
                                            {
                                                case Glob.ActionError:
                                                case Glob.ActionErrorH:
                                                    strPipeMsgOut.extra = (int)rows[x]["APIError"];
                                                    strPipeMsgOut.datasize = 0;
                                                    writepipe();
                                                    rootnode.ForeColor = Color.DarkGray;
                                                    changed_by_internal_filter = true;
                                                    goto skipfilterAPI3;
                                            }
                                        }
                                    }
                                }
                                strPipeMsgOut.datasize = 0;
                                strPipeMsgOut.extra = 0; // Error
                                writepipe();
                                changed_by_internal_filter = true;
                            }
                        skipfilterAPI3:
                            rootnode.Nodes.Add("socket: " + strPipeMsgIn.sockid.ToString(sinfo.sockidfmt));
                            if ((strPipeMsgIn.extra >= 0) && (strPipeMsgIn.extra <= sinfo.sdhow.Length - 1))
                            {
                                rootnode.Nodes.Add("how: " + strPipeMsgIn.extra.ToString() + " (" + sinfo.sdhow[strPipeMsgIn.extra] + ")");
                            }
                            else
                            {
                                rootnode.Nodes.Add("how: " + strPipeMsgIn.extra.ToString());
                            }
                            break;
                    }
                    break;
                case Glob.CMD_DNS_STRUCTDATA:
                    switch (strPipeMsgIn.function)
                    {
                        case Glob.DNS_GETHOSTBYNAME_IN:
                            if (DNStrap == true)
                            {
                                rootnode = treeDNS.Nodes[treeDNS.Nodes.Count - 1];
                                DNStrap = false;
                            }
                            else
                                rootnode = new TreeNode();
                            for (int i = 0; i < data.Length; i += 4)
                            {
                                addr = data[i].ToString() + "." + data[i + 1].ToString() + "." + data[i + 2].ToString() + "." + data[i + 3].ToString();
                                rootnode.Nodes.Add("addr: " + addr);
                                drsock = dsMain.Tables["dns"].Rows.Find(addr);
                                if (drsock != null)
                                {
                                    drsock["host"] = rootnode.Nodes[0].Text.ToString().Substring(6);
                                }
                                else
                                {
                                    drsock = dsMain.Tables["dns"].NewRow();
                                    drsock["addr"] = addr;
                                    drsock["host"] = rootnode.Nodes[0].Text.ToString().Substring(6);
                                    dsMain.Tables["dns"].Rows.Add(drsock);
                                }
                            }
                            break;
                        case Glob.DNS_GETHOSTBYADDR_IN:
                            if (data.Length > 4)
                            {
                                if (DNStrap == true)
                                {
                                    treeDNS.Nodes[treeDNS.Nodes.Count - 1].Nodes.Add("name: " + ae.GetString(data));
                                    DNStrap = false;
                                }
                            }
                            break;
                    }
                    break;
                case Glob.CMD_DNS_DATA:
                    switch (strPipeMsgIn.function)
                    {
                        case Glob.DNS_GETHOSTBYNAME_OUT:
                            if (monitor == true)
                            {
                                rootnode = treeDNS.Nodes.Add(DateTime.Now.ToLongTimeString() + " gethostbyname()");
                                DNStrap = true;
                            }
                            else
                                rootnode = new TreeNode();
                            data = trimzeros(data);
                            rootnode.Nodes.Add("name: " + ae.GetString(data));
                            if (filter == true)
                            {
                                DataRow[] rows = dsMain.Tables["filters"].Select("enabled = true");
                                strPipeMsgOut.command = Glob.CMD_FILTER;

                                for (int x = 0; x < rows.Length; x++)
                                {
                                    foreach (byte bf in (byte[])rows[x]["DNSFunction"])
                                    {
                                        if (bf == strPipeMsgIn.function)
                                        {
                                            switch ((byte)rows[x]["DNSAction"])
                                            {
                                                case Glob.ActionReplaceString:
                                                    if (Regex.IsMatch(ae.GetString(data), rows[x]["DNSCatch"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase))
                                                    {
                                                        try
                                                        {
                                                            data = ae.GetBytes(Regex.Replace(ae.GetString(data).Replace("\\0", ""), rows[x]["DNSCatch"].ToString(), rows[x]["DNSReplace"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase) + "\0");
                                                            rootnode.Nodes.Add("new name: " + ae.GetString(data)).ForeColor = Color.Green;
                                                            changed_by_internal_filter = true;
                                                        }
                                                        catch
                                                        {
                                                            rootnode.ForeColor = Color.Red;
                                                        }
                                                    }
                                                    break;
                                                case Glob.ActionReplaceStringH:
                                                    if (Regex.IsMatch(bytestohexstring(data), rows[x]["DNSCatch"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase))
                                                    {
                                                        try
                                                        {
                                                            data = hexstringtobyte(Regex.Replace(bytestohexstring(data), rows[x]["DNSCatch"].ToString(), rows[x]["DNSReplace"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase) + "\0");
                                                            rootnode.Nodes.Add("new name: " + ae.GetString(data)).ForeColor = Color.Green;
                                                            changed_by_internal_filter = true;
                                                        }
                                                        catch
                                                        {
                                                            rootnode.ForeColor = Color.Red;
                                                        }
                                                    }
                                                    break;
                                                case Glob.ActionError:
                                                    if (Regex.IsMatch(ae.GetString(data), rows[x]["DNSCatch"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase))
                                                    {
                                                        strPipeMsgOut.extra = (int)rows[x]["DNSError"];
                                                        strPipeMsgOut.datasize = 0;
                                                        writepipe();
                                                        rootnode.ForeColor = Color.DarkGray;
                                                        changed_by_internal_filter = true;
                                                        goto skipfilterdns1;
                                                    }
                                                    break;
                                                case Glob.ActionErrorH:
                                                    if (Regex.IsMatch(bytestohexstring(data), rows[x]["DNSCatch"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase))
                                                    {
                                                        strPipeMsgOut.extra = (int)rows[x]["DNSError"];
                                                        strPipeMsgOut.datasize = 0;
                                                        writepipe();
                                                        rootnode.ForeColor = Color.DarkGray;
                                                        changed_by_internal_filter = true;
                                                        goto skipfilterdns1;
                                                    }
                                                    break;
                                            }
                                        }
                                    }
                                }
                                if (changed_by_internal_filter == false)
                                {
                                    strPipeMsgOut.datasize = 0;
                                    strPipeMsgOut.extra = 0; // Error
                                    writepipe();
                                    changed_by_internal_filter = true;
                                }
                                else
                                {
                                    strPipeMsgOut.datasize = data.Length;
                                    strPipeMsgOut.extra = 0;
                                    writepipe();
                                    pipeOut.Write(data, 0, data.Length);
                                    rootnode.ForeColor = Color.Green;
                                }
                            }
                        skipfilterdns1:
                            break;
                        case Glob.DNS_GETHOSTBYADDR_OUT:
                            if (monitor == true)
                            {
                                rootnode = treeDNS.Nodes.Add(DateTime.Now.ToLongTimeString() + " gethostbyaddr()");
                                DNStrap = true;
                            }
                            else
                                rootnode = new TreeNode();
                            rootnode.Nodes.Add("addr: " + bytestoaddy(data));
                            data = trimzeros(data);
                            if (filter == true)
                            {
                                DataRow[] rows = dsMain.Tables["filters"].Select("enabled = true");
                                strPipeMsgOut.command = Glob.CMD_FILTER;

                                for (int x = 0; x < rows.Length; x++)
                                {
                                    foreach (byte bf in (byte[])rows[x]["DNSFunction"])
                                    {
                                        if (bf == strPipeMsgIn.function)
                                        {
                                            switch ((byte)rows[x]["DNSAction"])
                                            {
                                                case Glob.ActionReplaceString:
                                                    try
                                                    {
                                                        if (Regex.IsMatch(bytestoaddy(data), rows[x]["DNSCatch"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase))
                                                        {
                                                            IPAddress addy = IPAddress.Parse(Regex.Replace(bytestoaddy(data), rows[x]["DNSCatch"].ToString(), rows[x]["DNSReplace"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase));
                                                            data = addy.GetAddressBytes();
                                                            rootnode.Nodes.Add("new addr: " + addy.ToString()).ForeColor = Color.Green;
                                                            changed_by_internal_filter = true;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        rootnode.ForeColor = Color.Red;
                                                    }

                                                    break;
                                                case Glob.ActionReplaceStringH:
                                                    try
                                                    {
                                                        if (Regex.IsMatch(bytestohexstring(data), rows[x]["DNSCatch"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase))
                                                        {
                                                            IPAddress addy = IPAddress.Parse(hexstringtoaddy(Regex.Replace(bytestohexstring(data), rows[x]["DNSCatch"].ToString(), rows[x]["DNSReplace"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase)));
                                                            data = addy.GetAddressBytes();
                                                            rootnode.Nodes.Add("new addr: " + addy.ToString()).ForeColor = Color.Green;
                                                            changed_by_internal_filter = true;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        rootnode.ForeColor = Color.Red;
                                                    }

                                                    break;
                                                case Glob.ActionError:
                                                    try
                                                    {
                                                        if (Regex.IsMatch(bytestoaddy(data), rows[x]["DNSCatch"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase))
                                                        {
                                                            strPipeMsgOut.extra = (int)rows[x]["DNSError"];
                                                            strPipeMsgOut.datasize = 0;
                                                            writepipe();
                                                            rootnode.ForeColor = Color.DarkGray;
                                                            changed_by_internal_filter = true;
                                                            goto skipfilterdns2;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        rootnode.ForeColor = Color.Red;
                                                    }
                                                    break;
                                                case Glob.ActionErrorH:
                                                    try
                                                    {
                                                        if (Regex.IsMatch(bytestohexstring(data), rows[x]["DNSCatch"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase))
                                                        {
                                                            strPipeMsgOut.extra = (int)rows[x]["DNSError"];
                                                            strPipeMsgOut.datasize = 0;
                                                            writepipe();
                                                            rootnode.ForeColor = Color.DarkGray;
                                                            changed_by_internal_filter = true;
                                                            goto skipfilterdns2;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        rootnode.ForeColor = Color.Red;
                                                    }
                                                    break;
                                            }
                                        }
                                    }
                                }
                                if (changed_by_internal_filter == false)
                                {
                                    strPipeMsgOut.datasize = 0;
                                    strPipeMsgOut.extra = 0; // Error
                                    writepipe();
                                    changed_by_internal_filter = true;
                                }
                                else
                                {
                                    strPipeMsgOut.datasize = data.Length;
                                    strPipeMsgOut.extra = 0;
                                    writepipe();
                                    pipeOut.Write(data, 0, data.Length);
                                    rootnode.ForeColor = Color.Green;
                                }
                            }
                        skipfilterdns2:
                            break;
                        case Glob.DNS_GETHOSTNAME:
                            if (monitor == true)
                                rootnode = treeDNS.Nodes.Add(DateTime.Now.ToLongTimeString() + " gethostname()");
                            else
                                rootnode = new TreeNode();
                            data = trimzeros(data);
                            rootnode.Nodes.Add("name: " + ae.GetString(data));
                            if (filter == true)
                            {
                                DataRow[] rows = dsMain.Tables["filters"].Select("enabled = true");
                                strPipeMsgOut.command = Glob.CMD_FILTER;

                                for (int x = 0; x < rows.Length; x++)
                                {
                                    foreach (byte bf in (byte[])rows[x]["DNSFunction"])
                                    {
                                        if (bf == strPipeMsgIn.function)
                                        {
                                            switch ((byte)rows[x]["DNSAction"])
                                            {
                                                case Glob.ActionReplaceString:
                                                    if (Regex.IsMatch(ae.GetString(data), rows[x]["DNSCatch"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase))
                                                    {
                                                        try
                                                        {
                                                            data = ae.GetBytes(Regex.Replace(ae.GetString(data), rows[x]["DNSCatch"].ToString(), rows[x]["DNSReplace"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase) + "\0");
                                                            rootnode.Nodes.Add("new name: " + ae.GetString(data)).ForeColor = Color.Green;
                                                            changed_by_internal_filter = true;
                                                        }
                                                        catch
                                                        {
                                                            rootnode.ForeColor = Color.Red;
                                                        }
                                                    }
                                                    break;
                                                case Glob.ActionReplaceStringH:
                                                    if (Regex.IsMatch(bytestohexstring(data), rows[x]["DNSCatch"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase))
                                                    {
                                                        try
                                                        {
                                                            data = hexstringtobyte(Regex.Replace(bytestohexstring(data), rows[x]["DNSCatch"].ToString(), rows[x]["DNSReplace"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase) + "\0");
                                                            rootnode.Nodes.Add("new name: " + ae.GetString(data)).ForeColor = Color.Green;
                                                            changed_by_internal_filter = true;
                                                        }
                                                        catch
                                                        {
                                                            rootnode.ForeColor = Color.Red;
                                                        }
                                                    }
                                                    break;
                                                case Glob.ActionError:
                                                    if (Regex.IsMatch(ae.GetString(data), rows[x]["DNSCatch"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase))
                                                    {
                                                        strPipeMsgOut.extra = (int)rows[x]["DNSError"];
                                                        strPipeMsgOut.datasize = 0;
                                                        writepipe();
                                                        rootnode.ForeColor = Color.DarkGray;
                                                        changed_by_internal_filter = true;
                                                        goto skipfilterdns3;
                                                    }
                                                    break;
                                                case Glob.ActionErrorH:
                                                    if (Regex.IsMatch(bytestohexstring(data), rows[x]["DNSCatch"].ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase))
                                                    {
                                                        strPipeMsgOut.extra = (int)rows[x]["DNSError"];
                                                        strPipeMsgOut.datasize = 0;
                                                        writepipe();
                                                        rootnode.ForeColor = Color.DarkGray;
                                                        changed_by_internal_filter = true;
                                                        goto skipfilterdns3;
                                                    }
                                                    break;
                                            }
                                        }
                                    }
                                }
                                if (changed_by_internal_filter == false)
                                {
                                    strPipeMsgOut.datasize = 0;
                                    strPipeMsgOut.extra = 0; // Error
                                    writepipe();
                                    changed_by_internal_filter = true;
                                }
                                else
                                {
                                    strPipeMsgOut.datasize = data.Length;
                                    strPipeMsgOut.extra = 0;
                                    writepipe();
                                    pipeOut.Write(data, 0, data.Length);
                                    rootnode.ForeColor = Color.Green;
                                }
                            }
                        skipfilterdns3:
                            break;
                    }
                    break;
            }
            if ((filter == true) && (changed_by_internal_filter == false)) 
            {
                strPipeMsgOut.command = Glob.CMD_FILTER;
                strPipeMsgOut.datasize = 0;
                strPipeMsgOut.extra = 0; // Error
                writepipe();
            }
        }

        void ProcessExited()
        {
            pipeIn.Close();
            pipeOut.Close();
            intTargetpID = 0;
            this.Text = "PacketEditor";
            mnuFileDetach.Enabled = false;
        }

        public Main()
        {
            IntPtr hToken;
            LUID luidSEDebugNameValue;
            TOKEN_PRIVILEGES tkpPrivileges;

            InitializeComponent();

            if (OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, out hToken))
            {
                if (LookupPrivilegeValue(null, SE_DEBUG_NAME, out luidSEDebugNameValue))
                {
                    tkpPrivileges.PrivilegeCount = 1;
                    tkpPrivileges.Luid = luidSEDebugNameValue;
                    tkpPrivileges.Attributes = SE_PRIVILEGE_ENABLED;

                    AdjustTokenPrivileges(hToken, false, ref tkpPrivileges, 0, IntPtr.Zero, IntPtr.Zero);
                }
                CloseHandle(hToken);
            }
        }
        private void PipeRead()
        {
            byte[] dbPipeMsgIn = new byte[14];
            byte[] zero = new byte[] { 0 };

            System.Delegate delMainup = new UpdateMainGridDelegate(UpdateMainGrid);
            System.Delegate delExitProc = new ProcessExitedDelegate(ProcessExited);
            System.Delegate delTree = new UpdateTreeDelegate(UpdateTree);
            TreeNode retNode = new TreeNode();
            TreeNode retNode2 = new TreeNode();

            byte[] dbPipeMsgInData;
        PipeLoop:
            while (pipeIn.Read(dbPipeMsgIn, 0, 14) != 0)
            {
                strPipeMsgIn = (Glob.PipeHeader)Glob.RawDeserializeEx(dbPipeMsgIn, typeof(Glob.PipeHeader));
                if (strPipeMsgIn.datasize != 0)
                {
                    dbPipeMsgInData = new byte[strPipeMsgIn.datasize];
                    pipeIn.Read(dbPipeMsgInData, 0, dbPipeMsgInData.Length);

                    switch (strPipeMsgIn.function)
                    {
                        case Glob.FUNC_SEND:
                        case Glob.FUNC_SENDTO:
                        case Glob.FUNC_WSASEND:
                        case Glob.FUNC_WSASENDTO:
                        case Glob.FUNC_WSASENDDISCONNECT:
                        case Glob.FUNC_RECV:
                        case Glob.FUNC_RECVFROM:
                        case Glob.FUNC_WSARECV:
                        case Glob.FUNC_WSARECVFROM:
                        case Glob.FUNC_WSARECVDISCONNECT:
                            try
                            {
                                Invoke(delMainup, dbPipeMsgInData);
                            }
                            catch
                            { }
                            break;
                        case Glob.CONN_RECVFROM:
                        case Glob.CONN_SENDTO:
                        case Glob.CONN_WSARECVFROM:
                        case Glob.CONN_WSASENDTO:
                        case Glob.DNS_GETHOSTBYADDR_IN:
                        case Glob.DNS_GETHOSTBYADDR_OUT:
                        case Glob.DNS_GETHOSTBYNAME_IN:
                        case Glob.DNS_GETHOSTBYNAME_OUT:
                        case Glob.DNS_GETHOSTNAME:
                        case Glob.DNS_WSAASYNCGETHOSTBYADDR_IN:
                        case Glob.DNS_WSAASYNCGETHOSTBYADDR_OUT:
                        case Glob.DNS_WSAASYNCGETHOSTBYNAME_IN:
                        case Glob.DNS_WSAASYNCGETHOSTBYNAME_OUT:
                        case Glob.FUNC_ACCEPT:
                        case Glob.FUNC_BIND:
                        case Glob.FUNC_CLOSESOCKET:
                        case Glob.FUNC_CONNECT:
                        case Glob.FUNC_GETPEERNAME:
                        case Glob.FUNC_GETSOCKNAME:
                        case Glob.FUNC_LISTEN:
                        case Glob.FUNC_SHUTDOWN:
                        case Glob.FUNC_SOCKET_IN:
                        case Glob.FUNC_SOCKET_OUT:
                        case Glob.FUNC_WSAACCEPT:
                        case Glob.FUNC_WSACLEANUP:
                        case Glob.FUNC_WSACONNECT:
                        case Glob.FUNC_WSASOCKETW_IN:
                        case Glob.FUNC_WSASOCKETW_OUT:
                            Invoke(delTree, dbPipeMsgInData);
                            break;
                    }
                }
                else
                {
                    if (strPipeMsgIn.command == Glob.CMD_INIT)
                    {
                        if (strPipeMsgIn.function == Glob.INIT_DECRYPT)
                            if (strPipeMsgIn.extra == 0)
                            {
                                Invoke(delExitProc);
                                MessageBox.Show(this.Owner, "Invalid license.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                strPipeMsgOut.datasize = 0;
                                if (monitor == true)
                                {
                                    strPipeMsgOut.command = Glob.CMD_ENABLE_MONITOR;
                                    strPipeMsgOut.datasize = 0;
                                    writepipe();
                                }
                                if (filter == true)
                                {
                                    strPipeMsgOut.command = Glob.CMD_ENABLE_FILTER;
                                    strPipeMsgOut.datasize = 0;
                                    writepipe();
                                }
                            }
                    }
                    else
                    {
                        switch (strPipeMsgIn.function)
                        {
                            case Glob.CONN_RECVFROM:
                            case Glob.CONN_SENDTO:
                            case Glob.CONN_WSARECVFROM:
                            case Glob.CONN_WSASENDTO:
                            case Glob.DNS_GETHOSTBYADDR_IN:
                            case Glob.DNS_GETHOSTBYADDR_OUT:
                            case Glob.DNS_GETHOSTBYNAME_IN:
                            case Glob.DNS_GETHOSTBYNAME_OUT:
                            case Glob.DNS_GETHOSTNAME:
                            case Glob.DNS_WSAASYNCGETHOSTBYADDR_IN:
                            case Glob.DNS_WSAASYNCGETHOSTBYADDR_OUT:
                            case Glob.DNS_WSAASYNCGETHOSTBYNAME_IN:
                            case Glob.DNS_WSAASYNCGETHOSTBYNAME_OUT:
                            case Glob.FUNC_ACCEPT:
                            case Glob.FUNC_BIND:
                            case Glob.FUNC_CLOSESOCKET:
                            case Glob.FUNC_CONNECT:
                            case Glob.FUNC_GETPEERNAME:
                            case Glob.FUNC_GETSOCKNAME:
                            case Glob.FUNC_LISTEN:
                            case Glob.FUNC_SHUTDOWN:
                            case Glob.FUNC_SOCKET_IN:
                            case Glob.FUNC_SOCKET_OUT:
                            case Glob.FUNC_WSAACCEPT:
                            case Glob.FUNC_WSACLEANUP:
                            case Glob.FUNC_WSACONNECT:
                            case Glob.FUNC_WSASOCKETW_IN:
                            case Glob.FUNC_WSASOCKETW_OUT:
                                Invoke(delTree, zero);
                                break;
                            default: // Useless data call with no data
                                if (filter == true)
                                {
                                    strPipeMsgOut.command = Glob.CMD_FILTER;
                                    strPipeMsgOut.datasize = 0;
                                    strPipeMsgOut.extra = 0; // Error
                                    writepipe();
                                }
                                break;
                        }
                    }
                }
            }
            if (pipeIn.IsConnected) goto PipeLoop;
            Invoke(delExitProc);
            if (MessageBox.Show("Process Exited.\nTry to reattach?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (!Attach(processID, processPath))
                {
                    mnuFileDetach.Enabled = false;
                    reAttachToolStripMenuItem.Enabled = true;
                }
            }
           
        }
        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Global Variables for Attach
        string processPath;
        int processID;
        //End of global variables for attach
        private void mnuFileAttach_Click(object sender, EventArgs e)
        {
            Attach frmChAttach = new Attach();
            if (intTargetpID != 0)
            {
                if (MessageBox.Show("You are curently attached to a process. Are you sure you would like to detach?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (pipeOut.IsConnected)
                    {
                        strPipeMsgOut.command = Glob.CMD_UNLOAD_DLL;
                        try
                        {
                            writepipe();
                        }
                        catch { }
                    }
                    try
                    {
                        if (trdPipeRead.IsAlive)
                        {
                            trdPipeRead.Abort();
                        }
                    }
                    catch
                    {
                    }
                    pipeIn.Close();
                    pipeOut.Close();
                    intTargetpID = 0;
                    this.Text = "PacketEditor";
                    mnuFileDetach.Enabled = false;
                }
                else
                {
                    return;
                }
            }
            this.Enabled = false;
            if (this.TopMost == true)
                frmChAttach.TopMost = true;
            frmChAttach.ShowDialog();
            processID = frmChAttach.pID;
            processPath = frmChAttach.GetpPath();
            Attach(processID, processPath);
            
            
        }
        private bool Attach(int pID, string Path)
        {
            intTargetpID = pID;
            this.Enabled = true;
            if (intTargetpID != 0)
            {
                if (invokeDLL())
                {
                    reAttachPath = Path;
                    this.Text = "PacketEditor - " + reAttachPath;
                    mnuFileDetach.Enabled = true;
                    reAttachToolStripMenuItem.Enabled = true;
                    return true;
                }
                else
                    return false;
            }
            return false;
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (procExternalFilter != null)
            {
                try
                {
                    procExternalFilter.Kill();
                }
                catch(Exception)
                {}
            }
            if (intTargetpID != 0)
            {
                if (MessageBox.Show("You are curently attached to a process. Are you sure you would like to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (pipeOut.IsConnected)
                    {
                        strPipeMsgOut.command = Glob.CMD_UNLOAD_DLL;
                        try
                        {
                            writepipe();
                        }
                        catch { }
                    }
                    if (trdPipeRead.IsAlive)
                    {
                        trdPipeRead.Abort();
                    }
                    pipeIn.Close();
                    pipeOut.Close();
                }
                else
                {
                    e.Cancel = true;
                }
            }

            listen_for_requests = false;
            if (!firstRun)
                listener.Close();
        }
        private void mnuFileDetach_Click(object sender, EventArgs e)
        {
            if (intTargetpID != 0)
            {
                if (pipeOut.IsConnected)
                {
                    strPipeMsgOut.command = Glob.CMD_UNLOAD_DLL;
                    try
                    {
                        writepipe();
                    }
                    catch { }
                }
                if (trdPipeRead.IsAlive)
                {
                    trdPipeRead.Abort();
                }
                pipeIn.Close();
                pipeOut.Close();
                intTargetpID = 0;
                this.Text = "PacketEditor";
                mnuFileDetach.Enabled = false;
                reAttachToolStripMenuItem.Enabled = true;
            }
        }
        private void mnuToolsMonitor_CheckedChanged(object sender, EventArgs e)
        {
            if (mnuToolsMonitor.Checked == true)
            {
                monitor = true;
                DNStrap = false;
                if (intTargetpID != 0)
                {
                    strPipeMsgOut.command = Glob.CMD_ENABLE_MONITOR;
                    strPipeMsgOut.datasize = 0;
                    writepipe();
                }
            }
            else
            {
                monitor = false;
                DNStrap = false;
                if (intTargetpID != 0)
                {
                    strPipeMsgOut.command = Glob.CMD_DISABLE_MONITOR;
                    strPipeMsgOut.datasize = 0;
                    writepipe();
                }
            }
        }
        private void frmMain_Resize(object sender, EventArgs e)
        {
            //if (FormWindowState.Minimized == WindowState)
            //{
            //icoNotify.Visible = true;
            //Hide();
            //}
        }
        private void icoNotify_DoubleClick(object sender, EventArgs e)
        {
            //icoNotify.Visible = false;
            //Show();
            //WindowState = FormWindowState.Normal;
            BringToFront();
        }
        private void mnuNotifyExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void mnuMsgReplay_Click(object sender, EventArgs e)
        {
            if (dgridMain.SelectedRows.Count != 0)
            {
                ReplayEditor frmChReplay = new ReplayEditor((byte[])dgridMain.SelectedRows[0].Cells["rawdata"].Value, Int32.Parse(dgridMain.SelectedRows[0].Cells["socket"].Value.ToString(), System.Globalization.NumberStyles.AllowHexSpecifier), pipeOut);
                if (this.TopMost == true)
                    frmChReplay.TopMost = true;
                frmChReplay.Show();
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!File.Exists(strDLL))
                this.Close();
            procExternalFilter = null;
            Python = null;
            tsExternalFilter.BackColor = Color.Red;
        }
        private void mnuMsgSocketSDrecv_Click(object sender, EventArgs e)
        {
            if (dgridMain.SelectedRows.Count != 0)
            {
                strPipeMsgOut.command = Glob.CMD_INJECT;
                strPipeMsgOut.sockid = Int32.Parse(dgridMain.SelectedRows[0].Cells["socket"].Value.ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
                strPipeMsgOut.function = Glob.FUNC_SHUTDOWN;
                strPipeMsgOut.extra = (int)SocketShutdown.Receive;
                strPipeMsgOut.datasize = 0;
                writepipe();
            }
        }
        private void mnuMsgSocketSDsend_Click(object sender, EventArgs e)
        {
            if (dgridMain.SelectedRows.Count != 0)
            {
                strPipeMsgOut.command = Glob.CMD_INJECT;
                strPipeMsgOut.sockid = Int32.Parse(dgridMain.SelectedRows[0].Cells["socket"].Value.ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
                strPipeMsgOut.function = Glob.FUNC_SHUTDOWN;
                strPipeMsgOut.extra = (int)SocketShutdown.Send;
                strPipeMsgOut.datasize = 0;
                writepipe();
            }
        }
        private void mnuMsgSocketSDboth_Click(object sender, EventArgs e)
        {
            if (dgridMain.SelectedRows.Count != 0)
            {
                strPipeMsgOut.command = Glob.CMD_INJECT;
                strPipeMsgOut.sockid = Int32.Parse(dgridMain.SelectedRows[0].Cells["socket"].Value.ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
                strPipeMsgOut.function = Glob.FUNC_SHUTDOWN;
                strPipeMsgOut.extra = (int)SocketShutdown.Both;
                strPipeMsgOut.datasize = 0;
                writepipe();
            }
        }
        private void mnuMsgSocketClose_Click(object sender, EventArgs e)
        {
            if (dgridMain.SelectedRows.Count != 0)
            {
                strPipeMsgOut.command = Glob.CMD_INJECT;
                strPipeMsgOut.sockid = Int32.Parse(dgridMain.SelectedRows[0].Cells["socket"].Value.ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
                strPipeMsgOut.function = Glob.FUNC_CLOSESOCKET;
                strPipeMsgOut.datasize = 0;
                writepipe();
            }
        }
        private void mnuToolsFilter_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (mnuToolsFilter.Checked == true)
                {
                    filter = true;
                    if (intTargetpID != 0)
                    {
                        strPipeMsgOut.command = Glob.CMD_ENABLE_FILTER;
                        strPipeMsgOut.datasize = 0;
                        writepipe();
                    }
                }
                else
                {
                    filter = false;
                    if (intTargetpID != 0)
                    {
                        strPipeMsgOut.command = Glob.CMD_DISABLE_FILTER;
                        strPipeMsgOut.datasize = 0;
                        writepipe();
                    }
                }
            }
        }
        private void mnuOptionsOntop_CheckedChanged(object sender, EventArgs e)
        {
            if (mnuOptionsOntop.Checked == true)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }
        private void frmMain_Activated(object sender, EventArgs e)
        {
            if (this.TopMost == true)
            {
                this.Opacity = 1;
            }
        }
        private void frmMain_Deactivate(object sender, EventArgs e)
        {
            if (this.TopMost == true)
            {
                this.Opacity = .5;
            }
        }
        private void mnuToolsSockets_Click(object sender, EventArgs e)
        {
            Sockets frmChReplay = new Sockets(dsMain.Tables["sockets"], sinfo, pipeOut);
            if (this.TopMost == true)
                frmChReplay.TopMost = true;
            frmChReplay.Show();
        }
        private void dgridMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgridMain.SelectedRows.Count != 0)
            {
                strPipeMsgOut.command = Glob.CMD_INJECT;
                strPipeMsgOut.function = Glob.FUNC_SEND;
                strPipeMsgOut.sockid = Int32.Parse(dgridMain.SelectedRows[0].Cells["socket"].Value.ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
                strPipeMsgOut.datasize = ((byte[])dgridMain.SelectedRows[0].Cells["rawdata"].Value).Length;
                writepipe();
                try
                {
                    pipeOut.Write((byte[])dgridMain.SelectedRows[0].Cells["rawdata"].Value, 0, strPipeMsgOut.datasize);
                }
                catch (Exception)
                { }
            
            }
        }
        private void mnuToolsFilters_Click(object sender, EventArgs e)
        {
            frmChFilters = new Filters(dsMain.Tables["filters"], sinfo);
            if (this.TopMost == true)
                frmChFilters.TopMost = true;
            frmChFilters.Show();
        }
        private void mnuInvokeFreeze_Click(object sender, EventArgs e)
        {
            if (mnuInvokeFreeze.Text == "Freeze")
            {
                mnuInvokeFreeze.Text = "Unfreeze";
                strPipeMsgOut.command = Glob.CMD_FREEZE;
                strPipeMsgOut.datasize = 0;
                writepipe();
            }
            else
            {
                mnuInvokeFreeze.Text = "Freeze";
                strPipeMsgOut.command = Glob.CMD_UNFREEZE;
                strPipeMsgOut.datasize = 0;
                writepipe();
            }
        }
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (intTargetpID != 0)
            {
                if (MessageBox.Show("You are curently attached to a process. Are you sure you would like to detach?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (pipeOut.IsConnected)
                    {
                        strPipeMsgOut.command = Glob.CMD_UNLOAD_DLL;
                        try
                        {
                            writepipe();
                        }
                        catch { }
                    }
                    if (trdPipeRead.IsAlive)
                    {
                        trdPipeRead.Abort();
                    }
                    pipeIn.Close();
                    pipeOut.Close();
                    intTargetpID = 0;
                    this.Text = "PacketEditor";
                    mnuFileDetach.Enabled = false;
                }
                else
                {
                    return;
                }
            }
            OpenFileDialog opn = new OpenFileDialog();
            opn.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*";
            opn.Title = "Open File";
            opn.CheckFileExists = true;
            opn.Multiselect = false;
            if (opn.ShowDialog() != DialogResult.OK) return;
            Process proc = new Process();
            proc.StartInfo.FileName = opn.FileName;
            proc.StartInfo.WorkingDirectory = opn.FileName.Substring(0, opn.FileName.LastIndexOf("\\") + 1);
            proc.Start();

            intTargetpID = proc.Id;
            processID = proc.Id;
            processPath = opn.FileName;
            if (invokeDLL())
            {
                this.Text = "Advanced Packet Editor v1.1 - " + opn.FileName;
                mnuFileDetach.Enabled = true;
            }

        }
        private void mnuHelpHelp_Click(object sender, EventArgs e)
        {
            Process.Start("https://appsec-labs.com/Advanced_Packet_Editor");
        }
        private void mnuHelpWebsite_Click(object sender, EventArgs e)
        {
            var frmChAbout = new frmAbout();
            if (this.TopMost == true)
                frmChAbout.TopMost = true;
            frmChAbout.Show();
        }
        private void mnuDNSClear_Click(object sender, EventArgs e)
        {
            treeDNS.Nodes.Clear();
        }
        private void mnuAPIClear_Click(object sender, EventArgs e)
        {
            treeAPI.Nodes.Clear();
        }
        private void mnuMsgClear_Click(object sender, EventArgs e)
        {
            dgridMain.Rows.Clear();
        }
        private void mnuMsgCopyASCII_Click(object sender, EventArgs e)
        {
            string data = "";
            for (int i = 0; i < dgridMain.SelectedRows.Count; i++)
                data += dgridMain.SelectedRows[i].Cells["data"].Value;
            if (data != string.Empty)
                Clipboard.SetData(DataFormats.Text, data.Replace("\0", "\\0"));
        }
        private void mnuMsgCopyHex_Click(object sender, EventArgs e)
        {
            string data = "";
            try
            {
                for (int i = 0; i < dgridMain.SelectedRows.Count; i++)
                    data += bytestohexstring((byte[])dgridMain.SelectedRows[i].Cells["rawdata"].Value);
                if (data != string.Empty)
                    Clipboard.SetData(DataFormats.Text, data);
            }
            catch { }
        }

        private void filtersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChFilters.BringToFront();
        }

        private void reAttachToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            reattacheDelay = Microsoft.VisualBasic.Interaction.InputBox("Delay in milliseconds (1000 = 1 second)", "Reattach delay", reattacheDelay);
            if (reattacheDelay == "")
                return;
            System.Threading.Thread.Sleep(Convert.ToInt32(reattacheDelay));

            if (intTargetpID != 0)
            {
                if (MessageBox.Show("You are curently attached to a process. Are you sure you would like to detach?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (pipeOut.IsConnected)
                    {
                        strPipeMsgOut.command = Glob.CMD_UNLOAD_DLL;
                        try
                        {
                            writepipe();
                        }
                        catch { }
                    }
                    if (trdPipeRead.IsAlive)
                    {
                        trdPipeRead.Abort();
                    }
                    pipeIn.Close();
                    pipeOut.Close();
                    intTargetpID = 0;
                    this.Text = "PacketEditor";
                    mnuFileDetach.Enabled = false;
                }
                else
                {
                    return;
                }
            }

            intTargetpID = 0;

            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                try
                {
                    if (theprocess.MainModule.FileName == reAttachPath)
                    {
                        intTargetpID = theprocess.Id;
                    }
                }
                catch { }
            }

            if (intTargetpID != 0)
            {
                if (invokeDLL())
                {
                    this.Text = "Advanced Packet Editor v1.1 - " + reAttachPath;
                    mnuFileDetach.Enabled = true;
                }
            }
        }

        private void injectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgridMain.SelectedRows.Count != 0)
            {
                ReplayEditor frmChReplay = new ReplayEditor(new byte[0], Int32.Parse(dgridMain.SelectedRows[0].Cells["socket"].Value.ToString(), System.Globalization.NumberStyles.AllowHexSpecifier), pipeOut);
                if (this.TopMost == true)
                    frmChReplay.TopMost = true;
                frmChReplay.Show();
            }
            else
                MessageBox.Show("You must choose the socket. You can choose from Menu->Tools->Sockets."); 
        }

        private void MnuToolsProxy_Click(object sender, EventArgs e)
        {
            if (MnuToolsProxy.Checked == true)
            {
                listen_for_requests = true;

                try
                {
                    Start();
                    
                    new FrmBurpCode(BurpRequest).ShowDialog();
                }
                catch
                {
                    MessageBox.Show("Error occur. Did you run it with administrator privileges?");
                }
            }
            else
            {
                // stop the listen
                listen_for_requests = false;
                //listener.Close();
            }
        }
        
        public void Start()
        {
            listener = new HttpListener();

            prefixes = Microsoft.VisualBasic.Interaction.InputBox("On which port you want to listen?", "Start listen for requests", prefixes);
            if (prefixes == "") // user press cancel
                return;
            else
                BurpRequest = @"POST /?func=send()&sockid=0D3B HTTP/1.1
Host: 127.0.0.1:" + prefixes + @"
Content-Length: 62
Expect: 100-continue
Connection: Keep-Alive

DATA_TO_SEND";

            if (firstRun)
            {
                listener.Prefixes.Add("http://127.0.0.1:" + (string)prefixes + "/");

                firstRun = false;
                
                listener.Start();

                listen_for_requests = true;
                Thread thread = new Thread(new ThreadStart(listen));
                thread.Start();
            }
            listen_for_requests = true;
        }

        private void listen()
        {
            while (listen_for_requests)
            {
                IAsyncResult result = listener.BeginGetContext(new AsyncCallback(ListenerCallback), listener);
                result.AsyncWaitHandle.WaitOne();
            }

            listener.Close();
        }

        protected void ListenerCallback(IAsyncResult result)
        {
            if (this.listener == null)
                return;

            try
            {
                // Get out the context object
                HttpListenerContext context = this.listener.EndGetContext(result);

                // *** Immediately set up the next context
                this.listener.BeginGetContext(new AsyncCallback(ListenerCallback), this.listener);

                if (this.ReceiveWebRequest != null)
                    this.ReceiveWebRequest(context);

                this.ProcessRequest(context);
            }
            catch (HttpListenerException ex)
            {
                if (ex.ErrorCode != RequestThreadAbortedException)
                    throw;

                MessageBox.Show("Swallowing HttpListenerException({0}) Thread exit or aborted request" + RequestThreadAbortedException.ToString());
            }
        }

        /// <summary>
        /// Overridable method that can be used to implement a custom handler
        /// </summary>
        /// <param name="Context"></param>
        
        protected void ProcessRequest(System.Net.HttpListenerContext Context)
        {
            HttpListenerRequest Request = Context.Request;
            HttpListenerResponse Response = Context.Response;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Request.HttpMethod + " " + Request.RawUrl + " Http/" + Request.ProtocolVersion.ToString());
            String error = "";

            if (!Request.HasEntityBody)
                error = "Error: Empty body";

            // Fetch sock id from request
            String socketNm = null;
            Regex r = new Regex(@"sockid=([0-9a-fA-F]{4,4})", RegexOptions.IgnoreCase);
            Match m = r.Match(Request.Url.Query);
            if(m.Success) {
                Group g = m.Groups[1];
                socketNm = (string)g.Value;
            } else {
                error = "Error: sockid is wrong or missing";
            }

            try
            {
                strPipeMsgOut.sockid = int.Parse(socketNm, System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                error = "Error: Invalid socket ID (" + socketNm + ")";
            }
            

            // Fetch function from request
            String method = null;
            r = new Regex(@"func=(\w+\(\))&");
            m = r.Match(Request.Url.Query);
            if(m.Success) {
                Group g = m.Groups[1];
                method = (string)g.Value;
            } else {
                error = "Error: func is wrong or missing";
            }

            String Details = "";
            if (error != "")
                Details = error;
            else
            {
                System.IO.Stream body = Request.InputStream;
                System.Text.Encoding encoding = Request.ContentEncoding;
                System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
                String bodyText = reader.ReadToEnd();

                Details += "Socket: " + socketNm + "\r\n";
                Details += "Function: " + method + "\r\n";
                if (Request.ContentType != null)
                {
                    Details += "Data content type: " + Request.ContentType + "\r\n";
                }
                Details += "Data content length: " + Request.ContentLength64 + "\r\n";
                Details += "Data:\r\n" + bodyText;

                try
                {
                    //System.Text.ASCIIEncoding encoding2 = new System.Text.ASCIIEncoding();
                    Byte[] bcBytes = ae.GetBytes(bodyText);

                    strPipeMsgOut.command = Glob.CMD_INJECT;
                    strPipeMsgOut.function = sinfo.msgnum(method); // Glob.FUNC_SEND;
                    //strPipeMsgOut.sockid = Int32.Parse(dgridMain.SelectedRows[0].Cells["socket"].Value.ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
                    strPipeMsgOut.datasize = bcBytes.Length;
                    writepipe();
                    try
                    {
                        pipeOut.Write(bcBytes, 0, strPipeMsgOut.datasize);
                    }
                    catch (Exception)
                    { }
                    
                    
                    //pipeOut.Write(Glob.RawSerializeEx(strPipeMsgOut), 0, Marshal.SizeOf(strPipeMsgOut));
                    ///pipeOut.Write(bcBytes, 0, strPipeMsgOut.datasize);
                }
                catch
                {
                    Details += "\r\nAn error occured during perform the message";
                }

            }
            // print back the details/error
            byte[] bOutput = System.Text.Encoding.UTF8.GetBytes(Details);
            Response.ContentType = "text/html";
            Response.ContentLength64 = bOutput.Length;

            Stream OutputStream = Response.OutputStream;
            OutputStream.Write(bOutput, 0, bOutput.Length);
            OutputStream.Close();
        }

        private void showToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            for(int i = dgridMain.Rows.Count - 1; i >= 0; i--)
            {
                if(dgridMain.Rows[i].Cells["method"].Value.ToString().Contains("end") &&
                    showToolStripMenuItem.Checked == true)
                    dgridMain.Rows[i].Visible = true;
                if(dgridMain.Rows[i].Cells["method"].Value.ToString().Contains("end") &&
                    showToolStripMenuItem.Checked == false)
                    dgridMain.Rows[i].Visible = false;
            }
        }

        private void showrecvRecvAllToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            for(int i = dgridMain.Rows.Count - 1; i >= 0; i--)
            {
                if(dgridMain.Rows[i].Cells["method"].Value.ToString().Contains("ecv") &&
                    showrecvRecvAllToolStripMenuItem.Checked == true)
                    dgridMain.Rows[i].Visible = true;
                if(dgridMain.Rows[i].Cells["method"].Value.ToString().Contains("ecv") &&
                    showrecvRecvAllToolStripMenuItem.Checked == false)
                    dgridMain.Rows[i].Visible = false;
            }
        }

        private void dgridMain_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (mnuAutoScroll.Checked && !mnuMsg.Visible)
            {
                int index = dgridMain.RowCount - 1;
                dgridMain.FirstDisplayedScrollingRowIndex = index;
                dgridMain.Refresh();
                dgridMain.CurrentCell = dgridMain.Rows[index].Cells[0];
                dgridMain.Rows[index].Selected = true;
                
            }
        }

        private int mnuToolsExternalFilter()
        {
            prefixes2 = Microsoft.VisualBasic.Interaction.InputBox("What's the port of your external filter?", "Set external filter", prefixes2);
            if (prefixes2 == "") // user press cancel
            {
                externalFilter = false;
                return -1;
            }

         ////   if (prefixes2.Substring(prefixes2.Length - 1, 1) != "/" && prefixes2.Substring(prefixes2.Length - 1, 1) != "\\")
//MessageBox.Show(prefixes2.Substring(prefixes2.Length - 2, 1));
            
                
            externalFilter = true;
            return Int32.Parse(prefixes2);
        }

        static bool ArraysEqual(byte[] a1, byte[] a2)
        {
            if (a1 == a2)
                return true;

            if (a1 == null || a2 == null)
                return false;

            if (a1.Length != a2.Length)
                return false;

            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i] != a2[i])
                    return false;
            }
            return true;
        }

        private void UpdateText()
        {
            if (dgridMain.SelectedRows.Count != 0)
            {
                txbRecordText.Text = dgridMain.SelectedRows[0].Cells["data"].Value.ToString();
            }
        }

        private void dgridMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateText();
        }
        
        Process procExternalFilter;
        FrmPython Python;
        private void activateExtenalFilter()
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\scripts\\external_filter_server.py"))
            {
                int port = mnuToolsExternalFilter();
                if (port == -1)
                {
                    externalFilter = false;
                    return;
                }
                string file = CreateFile();
                procExternalFilter = new Process();
                procExternalFilter.StartInfo = new ProcessStartInfo()
                {
                    WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\scripts",
                    FileName = "python.exe",
                    Arguments ="external_filter_server.py "+  port.ToString() + " " + file,
                    UseShellExecute = false, 
                   RedirectStandardOutput = false,
                   RedirectStandardError = false,
                   RedirectStandardInput = false,
                   CreateNoWindow = true
                };
                try
                {
                    //procExternalFilter.Start();
                    tsExternalFilter.BackColor = Color.Green;
                    if (Python == null)
                    {
                        procExternalFilter.Start();
                        timerPython.Start();
                        Python = new FrmPython(file);
                        Python.Show();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Do you have python installed on your computer?");
                    //MessageBox.Show(ex.Message);
                }

            }
        }

        private string CreateFile()
        {
            string Path = AppDomain.CurrentDomain.BaseDirectory + "Log.txt";
            if (File.Exists(Path)) File.Delete(Path);
            File.CreateText(Path).Close() ;
            return Path;
        }

        private void closeExternalFilter()
        {
            try
            {
                Python.Close();
                Python = null;
                procExternalFilter.Kill();
                tsExternalFilter.BackColor = Color.Red;
            }
            catch (Exception)
            { }
            

        }
        
        private void toolToggleFilter_Click(object sender, EventArgs e)
        {
            if (!(sender as ToolStripMenuItem).Checked)
            {
                activateExtenalFilter();
                (sender as ToolStripMenuItem).Checked = true;
            }
            else
            {
                (sender as ToolStripMenuItem).Checked = false;
                try
                {
                    closeExternalFilter();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void MIReplay_Click(object sender, EventArgs e)
        {
            if (dgridMain.SelectedRows.Count != 0)
            {
                strPipeMsgOut.command = Glob.CMD_INJECT;
                strPipeMsgOut.function = Glob.FUNC_SEND;
                strPipeMsgOut.sockid = Int32.Parse(dgridMain.SelectedRows[0].Cells["socket"].Value.ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
                strPipeMsgOut.datasize = ((byte[])dgridMain.SelectedRows[0].Cells["rawdata"].Value).Length;
                writepipe();
                try
                {
                    pipeOut.Write(Encoding.ASCII.GetBytes(txbRecordText.Text), 0, strPipeMsgOut.datasize);
                }
                catch (Exception)
                { }
            }

        }

        private void timerPython_Tick(object sender, EventArgs e)
        {
            try
            {
                if (procExternalFilter.HasExited) tsExternalFilter.BackColor = Color.Red;
                else
                    tsExternalFilter.BackColor = Color.Green;
            }
            catch (Exception)
            {
                tsExternalFilter.BackColor = Color.Red;
                timerPython.Stop();
            }
        }

        private void copyForListenerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgridMain.SelectedRows.Count != 0)
            {
                String sockid = (string)dgridMain.SelectedRows[0].Cells["socket"].Value;
                String data = (string)dgridMain.SelectedRows[0].Cells["data"].Value;
                String method = (string)dgridMain.SelectedRows[0].Cells["method"].Value;

                String req = @"POST /?func=" + method + @"&sockid=" + sockid + @" HTTP/1.1
Host: 127.0.0.1:8083
Content-Length: 62
Expect: 100-continue
Connection: Keep-Alive

" + data;

                new FrmBurpCode(req).ShowDialog();
            }
        }
    }
}
