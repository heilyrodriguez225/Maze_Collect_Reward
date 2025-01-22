using System;
using System.Collections.Generic;
namespace Game
{    
    public class Program
    {
        public static void Main(string[] args)
        {
            Maze maze = new Maze(11,11);
            maze.InitializeMaze();
            maze.GenerateMaze(1,1);
            maze.ApplyMask();
            maze.Imprimir();
            maze.AddModifiersInMaze(5);

        }
    }
}