using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Generation_With_Fog_Of_War
{
    class Maze
    {
        private char[,] _maze;
        public int _width; //
        public int _height; //
        private Random _random;

        public int _endX; // Declare the end point's X-coordinate
        public int _endY; // Declare the end point's Y-coordinate

        public Maze(int width, int height)
        {
            _width = width;
            _height = height;
            _maze = new char[_width, _height];
            _random = new Random();
            InitializeMaze();
        }

        private void InitializeMaze()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _maze[x, y] = '#'; // Initialize all cells as walls
                }
            }
        }

     
        public void GenerateMaze(int startX, int startY)
        {
            
            int borderX = startX + DX[3]; // Move left
            int borderY = startY;

            _maze[borderX, borderY] = '.'; // Set the border cell as path  <--- Unsure if this still means anything? relic from the past.

            // Perform recursive backtracking algorithm
            RecursiveBacktrack(borderX, borderY);
            
            PlaceStartPoint(); // Place the start point (random, make setting to set it as corners?)
            PlaceEndPoint(); // Place the end point      ^
        }

        // Irrelevent PlaceStartPoint, this is ignored for now, but make a mental note ------------------------------------------------------------------------------
        private void PlaceStartPoint()
        {
            int minX = _width - 1;
            int minY = _height - 1;

            // Find a valid location for the start point
            do
            {
                _endX = _random.Next(minX);
                _endY = _random.Next(minY);
            } while (_maze[_endX, _endY] != '.');

            // Set the end point symbol
            _maze[_endX, _endY] = 'S';
        }
        
        private void PlaceEndPoint()
        {
            int maxX = _width - 1;
            int maxY = _height - 1;

            // Find a valid location for the end point
            do
            {
                _endX = _random.Next(maxX);
                _endY = _random.Next(maxY);
            } while (_maze[_endX, _endY] != '.');

            // Set the end point symbol
            _maze[_endX, _endY] = 'E';
        }
        
        private void RecursiveBacktrack(int x, int y)
        {
            int[] directions = { 0, 1, 2, 3 };
            ShuffleArray(directions); // Randomize the order of directions

            foreach (int direction in directions)
            {
                int newX = x + DX[direction] * 2; // Move two steps to account for walls
                int newY = y + DY[direction] * 2;

                if (IsInBounds(newX, newY) && _maze[newX, newY] == '#')
                {
                    _maze[newX, newY] = '.';
                    _maze[newX - DX[direction], newY - DY[direction]] = ' ';
                    RecursiveBacktrack(newX, newY);
                }
            }
        }
        public char GetCell(int x, int y)
        {
            if (IsInBounds(x, y))
            {
                return _maze[x, y];
            }
            return ' '; // Return a space for out-of-bounds cells
        }

        private bool IsInBounds(int x, int y)
        {
            return x >= 0 && x < _width && y >= 0 && y < _height;
        }

        private void ShuffleArray(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        public void PrintMaze()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    char cell = _maze[x, y];

                    if (cell == '#')
                    {
                        Console.Write('#'); // Wall
                    }
                    else if (cell == 'S')
                    {
                        Console.Write('S'); // Starting point
                    }
                    else if (cell == 'E')
                    {
                        Console.Write('E'); // End point
                    }
                    else
                    {
                        Console.Write(" "); // Wider space for path
                    }
                }
                Console.WriteLine();
            }
        }


        public bool IsWall(int x, int y)
        {
            if (IsInBounds(x, y))
            {
                return _maze[x, y] == '#';
            }
            return true; // Consider out-of-bounds as a wall
        }


        // Offsets for the four cardinal directions (N, S, E, W)
        private readonly int[] DX = { 0, 0, 1, -1 };
        private readonly int[] DY = { -1, 1, 0, 0 };
    }
}

