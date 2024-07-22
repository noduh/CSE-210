import socket

SERVER_IP = "127.0.0.1"
SERVER_PORT = 11000

message = "Hello, World!"
client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

client_socket.connect((SERVER_IP, SERVER_PORT))
client_socket.sendall(message.encode("utf-8"))  # send message encoded as utf-8

client_socket.close()
