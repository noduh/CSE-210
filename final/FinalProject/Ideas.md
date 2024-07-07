# Ideas for the Final Project
This describes my ideas for my final project.

## Stock Market Game
A simple stock market game, that can be played with multiple people.

This includes:
 - server/client communication
 - saving
 - comparing your winnings with other users
 - start at a set amount of money
 - this will implement an api

The idea of this game is that you'll start with a set amount of money and you will try to buy an sell stock to earn more money.
I might change the game to let you buy things other than stock, however the default is just buying shares.
This will work by comparing the stocks to the real stock market.
It's a low risk way to get experience in the Stock Market.
I may or may not implement a GUI for the client side.
I will likely create an API myself to communicate with the server.
This will allow clients to be written in other languages and made in different ways, while still being able to communicate with the same server.
I need a way to cover polymorphism, but I'm sure there's a good way to do that here.

## Chess Server
An open chess server that uses an API for people to be able to build their own clients.
The server will reject moves that aren't allowed, and will be able to update clients with current information.