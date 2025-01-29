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
            maze.AddPathCells();
            maze.AddModifiersInMaze(6);
            maze.AddMoneyInMaze(10,6);
            Player p = new Player("Player1",new BlueChip("Pedro",3,0),0,maze);
            
            Imprimir(maze, p, maze.Modifiers);
            while (true)
            {
                p.Move(maze);
                Console.WriteLine(" ");
                Imprimir(maze, p, maze.Modifiers);
            }
        }
        public static void Imprimir(Maze maze, Player p, List<Modifier> Modifiers)
        {
            for (int x = 0; x < maze.maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.maze.GetLength(1); y++)
                {
                        if(x == p.PositionX && y == p.PositionY)
                            Console.Write("9 ");
                        else if(PrintCoins(maze,x,y))
                            Console.Write("3 ");
                        else if(PrintDiamonds(maze,x,y))
                            Console.Write("4 ");
                        else if(PrintModifiers(maze,x,y))
                            Console.Write("2 ");
                        else if(maze.maze[x,y] == 1)
                            Console.Write("1 ");
                        else if(maze.maze[x,y] == 0)
                            Console.Write("0 ");
                }
                Console.WriteLine();
            }
        }
        public static bool PrintModifiers(Maze maze,int x, int y)
        {
            bool traverseModifierList = false;
           
                    for (int k = 0; k < maze.Modifiers.Count; k++)
                    {
                        if(x == maze.Modifiers[k].CoordinateX && y == maze.Modifiers[k].CoordinateY)
                        traverseModifierList = true;
                    }

            return traverseModifierList;
        }
        public static bool PrintCoins(Maze maze, int x, int y)
        {
            bool traverseCoinsList = false;
            for (int k = 0; k < maze.Coins.Count; k++)
            {
                if(x == maze.Coins[k].CoordinateX && y == maze.Coins[k].CoordinateY)
                traverseCoinsList = true;
            }   
            return traverseCoinsList;
        }
        public static bool PrintDiamonds(Maze maze, int x, int y)
        {
            bool traverseDiamondsList = false;
            for (int k = maze.Diamonds.Count - 1; k >= 0; k--)
            {
                if(x == maze.Diamonds[k].CoordinateX && y == maze.Diamonds[k].CoordinateY)
                traverseDiamondsList = true;
            }
            return traverseDiamondsList;
        }
    }
}