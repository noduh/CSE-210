import socket

SERVER_IP = "127.0.0.1"
SERVER_PORT = 11000
BUFFER_SIZE = 1024
DISCONNECT_MESSAGE = "disconnect"

global keep_going
keep_going = True
message = ""
client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

client_socket.connect((SERVER_IP, SERVER_PORT))
print("Connected...")


def send_messages():
    print("Sending Ready...")
    global keep_going
    while keep_going:
        message = input("Message: ")
        if message.lower() == DISCONNECT_MESSAGE:
            keep_going = False
        client_socket.sendall(message.encode("utf-8"))  # send message encoded as utf-8
        data = client_socket.recv(BUFFER_SIZE)
        if data.decode() != DISCONNECT_MESSAGE:
            print(f"Received: {data.decode()}")


send_messages()
client_socket.close()
