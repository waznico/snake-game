# Snake Game in Console
A C# implementation of snake rendered in a simple console application. It's written in .NET 6. Snake is a game where you have to collect randomly spawning items
and avoid crashing into the border or yourself.

## Rules
Snake is an endless running game. It's over when you crash into an obstacle. The goal is to live as long as you can and to let the snake grow as far as possible.

## Project setup
The goal of this project is to learn how to apply simple object oriented patterns in C#. There're some difficulties which require to split up the code correctly.

### Rendering
In a console application all rendering happens line by line or starting at the current curser position. To prevent flickering of the whole game a buffer is needed.
A buffer represents all content which should be rendered on the console output. In this project the buffer is under `Display/ConsoleRenderer`.
With this buffer you have to seperate visual output and logic like check if there's a collision or fetching and processing user input. After game logic was 
processed, all objects are added to the buffer and the rendering is executed by the main process. Each time the `ExecuteRendering` method is called the whole
display output will be overridden by the buffers contend and the buffer will be cleared to prevent unexpected output.

### Basic types
Currently there're two basic types in this project:
1. Direction (enum)
2. Vector2D

**Direction** contains the four directions you can go and is important to translating user input from the main method into a new snake moving direction. 

**Vector2D** is inspired by Unitys system of working with directions and positions. It holds two values for X and Y positions and can execute very basic arithmetic 
operations (add and substract). Vector2D also contains definitions for a zero vector and for each direction you can move (up, down, left and right).

### Game objects
All objects which are rendered are game objects. A game object basically contains a list of element positions and a symbol which should be rendered to display it.
The console renderer works with thiese properties to display all game objects on their positions with their symbols.
Each game object (like the snake) has its own code to execute more specific code.

### Movement
There're three parts in the programs process to move the snake along the board.
The user input is fetched in the main method. If the user is pressing any of the arrow keys the method `ChangeDirection` of the snake is called. If the user
doesn't press any keys, the snake continues to move in the last given direction.
After the snake `move` method was executed the main process starts to transfer all changes to the renderer which is then executed to display the new positions 
on the screen.

### Growing the snake and detecting game over
All collision detection is currently made by the main method. It checks every time after moving the snake if there's a collision with a collectable, border or 
the snake itself. If there's an collision with a collectable (e. g. the apple) the snake grows by one tail element. If a collision with the border or the snake 
is detected the game ends and shows "Game over".
