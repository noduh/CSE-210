import socket

SERVER_IP = "127.0.0.1"
SERVER_PORT = 11000

keep_sending = True
message = ""
client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

client_socket.connect((SERVER_IP, SERVER_PORT))
while keep_sending:
    message = input("Message: ")
    if message.lower() == "disconnect":
        keep_sending = False
    
    client_socket.sendall(message.encode("utf-8"))  # send message encoded as utf-8

client_socket.close()
