using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Maze_Generation_With_Fog_Of_War
{
    class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        private Maze _maze; // Reference to the Maze object

        public Player(Maze maze, int startX, int startY)
        {
            _maze = maze;
            X = startX;
            Y = startY;
        }

        public void Move(Maze maze, int X, int Y)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (!_maze.IsWall(X, Y - 1))
                    {
                        Y--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (!_maze.IsWall(X, Y + 1))
                    {
                        Y++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (!_maze.IsWall(X - 1, Y))
                    {
                        X--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (!_maze.IsWall(X + 1, Y))
                    {
                        X++;
                    }
                    break;
                default:
                    // Handle other keys or do nothing for unrecognized keys
                    break;
            }

        }
    }
}