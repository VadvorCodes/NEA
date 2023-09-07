using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Generation_With_Fog_Of_War
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int mazeWidth = 59; //needs to be odd
            int mazeHeight = 31;
            int startX = 2; 
            int startY = 1;


            // =---------------------------------------------------------------------------------=
            Maze maze = new Maze(mazeWidth, mazeHeight);
            maze.GenerateMaze(startX, startY); // Generate the maze from your desired start point
            maze.PrintMaze(); // Print the maze
            Console.ReadKey();
            // =---------------------------------------------------------------------------------=


            
            
            Player player = new Player(maze, startX,startY); // temporary at the middle of the maze



            Fog_Of_War fogOfWar = new Fog_Of_War(mazeWidth, mazeHeight);
            GameController gameController = new GameController(maze, player, fogOfWar);
            UI ui = new UI();

            // Start the game loop
            gameController.StartGameLoop();
        }
    }
}
