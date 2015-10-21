import os
import cgi
import sys
import urlparse
from BaseHTTPServer import HTTPServer, BaseHTTPRequestHandler

# Settings
address = '127.0.0.1'
port = int(sys.argv[1])
if(len(sys.argv) > 2):
	log_path = sys.argv[2]

class logwriter(object):
	def write(self, data):
		with open(log_path, "a") as myfile:
			myfile.write(data)
		myfile.close()
	def clean(self):
		with open(log_path, "w") as myfile:
			pass
		myfile.close()
if 'log_path' in globals():
	logger = logwriter()
	sys.stdout = logger
	sys.stderr = logger
	logger.clean()

filter_path = os.path.dirname(os.path.realpath( __file__ )) + "\\filter.py"

class externalFilterHTTPServer(BaseHTTPRequestHandler):
	def do_GET(self):
		self.send_response(200)
		self.send_header('Content-type', 'text/html')
		self.end_headers()
		self.wfile.write('<HTML><body>Get!</body></HTML>')
		return 
			
	def do_POST(self):
		length = int(self.headers.getheader('content-length'))
		data = self.rfile.read(length)
		data = data[0:-2]
		self.send_response(200)
		self.end_headers()
		
		qs = urlparse.parse_qs(self.path.split('?', 1)[1])
		function = qs['func'][0][:-2]
		sockid = qs['sockid'][0]
		
		monitor = 1 # 0=hidden, 1=displayd
		monitor_color = 0 # 0=black, 1=dark_green, 2=red
		
		exec(open(filter_path).read())
		
		#execfile( filter_path )
		data = str(monitor) + str(monitor_color) + data
		self.wfile.write(data + "\r\n")
		
	def log_message(self, format, *args):
		pass
                
def main():
	try:
		server = HTTPServer((address, port), externalFilterHTTPServer)
		print '--------------------------------------------------------'
		print 'Server started at port', port, 'and listen to', address
		print '--------------------------------------------------------'
		print 'Filter path:', filter_path
		if 'log_path' in globals():
			print 'Log path:', log_path
		print '-------------------------------------------------------'
		server.serve_forever()
		
	except KeyboardInterrupt:
		print('^C received, shutting down server')
		server.socket.close() 
 
if __name__=='__main__':
	main()
