using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Generation_With_Fog_Of_War
{
    class Fog_Of_War
    {
        private bool[,] _revealedCells;
        private int _width;
        private int _height;

        public Fog_Of_War(int width, int height)
        {
            _width = width;
            _height = height;
            _revealedCells = new bool[_width, _height];
            InitializeFog();
        }

        private void InitializeFog()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _revealedCells[x, y] = false; // Initialize all cells as unrevealed
                }
            }
        }

        public void RevealArea(int playerX, int playerY, int visibilityRange)
        {
            for (int x = playerX - visibilityRange; x <= playerX + visibilityRange; x++)
            {
                for (int y = playerY - visibilityRange; y <= playerY + visibilityRange; y++)
                {
                    if (IsCoordinateValid(x, y))
                    {
                        _revealedCells[x, y] = true; // Mark the cell as revealed
                    }
                }
            }
        }

        private bool IsCoordinateValid(int x, int y)
        {
            return x >= 0 && x < _width && y >= 0 && y < _height;
        }

        public bool IsCellRevealed(int x, int y)
        {
            if (IsCoordinateValid(x, y))
            {
                return _revealedCells[x, y];
            }
            return false; // Consider out-of-bounds as unrevealed
        }
    }
}
