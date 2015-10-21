import os
import cgi
import sys
from BaseHTTPServer import HTTPServer, BaseHTTPRequestHandler

class mirrorHTTPServer(BaseHTTPRequestHandler):
	def do_GET(self):
		self.send_response(200)
		self.send_header('Content-type', 'text/html')
		self.end_headers()
		self.wfile.write('<HTML><body>Get!</body></HTML>')
		return 
			
	def do_POST(self):
		length = int(self.headers.getheader('content-length'))
		data = self.rfile.read(length)
		self.send_response(200)
		self.end_headers()

		self.wfile.write(data)
		#self.wfile.write('<HTML><body>Get!</body></HTML>')
		
	#def	log_message(self, format, *args):
	#	return
		
def main():
	try:
		address = '127.0.0.1'
		port = 8088
		server = HTTPServer((address, port), mirrorHTTPServer)
		print 'Mirror server started at port', port, 'and listen to', address
		server.serve_forever()
	except KeyboardInterrupt:
		server.socket.close() 
 
if __name__=='__main__':
	main()
