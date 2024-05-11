# Game functionality
Players can choose the dimensions of the board (3x3, 4x4).
Also they can undo their moves during the game. After the end of the round, you can start a new one or finish the game completely. During the game, the number of winnings of the player is counted.
# Programming Principles

## Single Responsibility, SRP
All classes have their own scope of responsibility, for example, the Board class operates only with methods related to Lattice (displaying the array, recording the player's symbol in the array, saving and restoring the state of the array). Therefore, in the TicTacToe class, when it is need to write the sign of the player on the board, the WriteSign method is called, in which, after passing the necessary checks, the WriteSign method of the Board class is called.
## Open/Closed, OCP
The classes are designed to be extensible without modifying existing code. For example, the abstract Board class can be extended by adding a child class with a certain lattice dimension.
## Liskov Substitution, LSP
The TicTacToe class has a TicTacToeBoard field of type Board to which we can assign a variable of type Board3 or Board4 in the [Create() method](./ClassLibrary/TicTacToe.cs#L48-L55).
## Interface Segregation Principle, ISP
We have small interfaces that have only the necessary methods and that can be implemented by different classes.
## KISS
Classes and methods are simple and focused on a single responsibility. They only have basic, simple and necessary methods for the game.
## Fail Fast
The [WriteSign(int position) method](./ClassLibrary/TicTacToe.cs#L33-L46) of the TicTacToeBoard class and the [WriteSign(int position, string sign) method](./ClassLibrary/Board.cs#L13-L25) of the Board class have checks for the correct functioning of the game. If these checks don't pass, an Exception is generated with a description of the error.

# Design Patterns

## Factory Method
The [BoardFactory](./ClassLibrary/BoardFactory.cs) factory class has a Create method that, depending on the value passed, returns a 3x3 or 4x4 board.
## Memento
Used to store a list of board states and for the ability to revert to a previous state (i.e. cancel a player's move). Implemented in IMemento interface, BoardMemento, Board (MakeSnapshot and Restore methods), [TicTacToe (Save and Undo methods)](./ClassLibrary/TicTacToe.cs#L95-L111) classes.
## Command
The TicTacToe class has a WriteSign method that performs certain checks, and if they pass, it calls the Board class's WriteSign method, which adds the player's sign to the board.

# Refactoring Techniques

## Rename Method 
It was used when the method was supplemented with functionality or changed it altogether.
## Extract Method
Separation of checks of winning combinations into [CheckRows](https://github.com/SofiiaKozlyk/TicTacToe/commit/0f6f01d57b331fe53407316434ad3532cb9e011b), CheckCols, CheckDiagonals methods from the CheckWinning method in the TicTacToe class. Separating the output of board and player information into the PrintGameInfo method.
## Hide Method
In the TicTacToe class methods not used by other classes have been made protected.
## Consolidate Conditional Expression
Used in the [CheckWinning method](./ClassLibrary/TicTacToe.cs#L155-L158).
## Replace Data Value with Object
The [CurrentPlayer](https://github.com/SofiiaKozlyk/TicTacToe/commit/ecaff0978d1b8531efd10b689c88b082d857b7e6#diff-45e7f450b361f69ac8f625ec936929e2c84cdbfc4aa2c2abe1bd95386efaabf6) field used to be of type string and stored the sign of the player, now it is of type Player and stores an object.