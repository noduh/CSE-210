import socket
import json

SERVER_IP = "127.0.0.1"
SERVER_PORT = 11000
BUFFER_SIZE = 1024
DISCONNECT_MESSAGE = "disconnect"

global keep_going
keep_going = True
message = ""
client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

# test variables
observer = {"name": "test", "side": "observer"}
white = {"name": "test", "side": "white"}
black = {"name": "test", "side": "black"}

client_socket.connect((SERVER_IP, SERVER_PORT))
print("Connected...")


def get_command():
    command = input("Command: ")

    if command == DISCONNECT_MESSAGE:  # disconnect if needed
        return DISCONNECT_MESSAGE

    user = input("User: ")
    if user == "observer":
        user = observer
    elif user == "white":
        user = white
    elif user == "black":
        user = black
    else:  # default to observer
        user = observer
    arg1 = None
    arg2 = None
    if command == "move":
        arg1 = input("Start Location: ")
        arg2 = input("End Location: ")

    json_stuff = {"sender": user, "command": command, "args": [arg1, arg2]}
    return json.dumps(json_stuff)


def send_messages():
    print("Sending Ready...")
    global keep_going
    while keep_going:
        message = get_command()  # get the command from the user
        print(f"commandJson: {message}")
        if message.lower() == DISCONNECT_MESSAGE:
            keep_going = False
        client_socket.sendall(message.encode("utf-8"))  # send message encoded as utf-8
        data = client_socket.recv(BUFFER_SIZE)
        if data.decode() != DISCONNECT_MESSAGE:
            print(f"Received: {data.decode()}")


send_messages()
client_socket.close()
