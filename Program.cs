using System;
using System.Collections.Generic;
namespace Game
{    
    public class Program
    {
        public static void Main(string[] args)
        {
            Maze maze = new Maze(25,25);
            maze.Imprimir();
        }
        
    }
}