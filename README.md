# BoardKnight

## Description

A Web Application to predict the possible moves of a chessboard knight in 1 or 2 turns.
The project is composed by the front end application written in angular 6 and an api written in .net core 2.1.

## Technologies used on this project

.Net Core 2.0  
Angular 6  
XUnit  
Docker

## Instructions

You will need to have docker installed to run the project, after this requirement is satisfied you can run the project with the following commands in the project directory:

```console
foo@bar:~$ docker-compose build
foo@bar:~$ docker-compose up
```

After this, the application will be accessible on <http://localhost:4200.>  

To stop the stack run the following commmand in the project directory:

```console
foo@bar:~$ docker-compose down
```

## Using the Web Application

The usage of the web application is really simple, a chessboard(kind of) is presented to the user, select the number of turns(1 or 2) and click in a position on the chess board, the chess board will highlight all the possible positions for the knight after the number of turns.

## Using the Api

The api endpoint is available at:  
<http://localhost:5000/api/boardknight/{position}/moves/{nrMoves}.>  
<http://localhost:5000/api/boardknight/{position}>

Where position is the selected position of the knight in algebraic notation and nrMoves is the number of turns(1 or 2). f the number of moves is not informed, 1 will be assumed by default.

The api will return a list of all the possible positions of the knight after that number of turns.

Example of the api output:

```json
["f2", "g3"]
```

## Unit Tests

The unit tests were written using xunit and are available on backend/tests.

The unittests will run automatically in the dockerfile and will break the build if there is any failure.

If you have the dotnet sdk installed the unittests can also be run with:

```console
foo@bar:~$ dotnet test backend/tests/BoardKnight.Tests
```
