using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Maze_Generation_With_Fog_Of_War
{
    class GameController
    {
        private Maze _maze;
        private Player _player;
        private Fog_Of_War _fogOfWar;


        public GameController(Maze maze, Player player, Fog_Of_War fogOfWar)
        {
            _maze = maze;
            _player = player;
            _fogOfWar = fogOfWar;
            
        }

        public void StartGameLoop()
        {
            while (true) // Your main game loop
            {
                Console.Clear(); // Clear the console for each frame

                // Handle player input (for example, arrow keys)
                // Update the player's position accordingly
                // For example, if the player presses the right arrow key:
                //player.Move(1, 0);





                // Reveal the area around the player
                int visibilityRange = 3; // Adjust the visibility range as needed
                _fogOfWar.RevealArea(_player.X, _player.Y, visibilityRange);

                // Print the maze with fog of war
                for (int y = 0; y < _maze._height; y++)
                {
                    for (int x = 0; x < _maze._width; x++)
                    {
                        char cell;
                        if (_fogOfWar.IsCellRevealed(x, y))
                        {
                            cell = _maze.GetCell(x, y);
                        }
                        else
                        {
                            cell = ' '; // Hide unrevealed cells
                        }

                        Console.Write(cell);
                    }
                    Console.WriteLine();
                }
                

                // Check if the player has reached the end point
                if (_player.X == _maze._endX && _player.Y == _maze._endY)
                {
                    Console.WriteLine("You reached the end point!");
                    break; // Exit the game loop
                }

                // Add game logic and other updates here

                Thread.Sleep(100); // Add a delay for smoother rendering
            }
        }
    }
}
