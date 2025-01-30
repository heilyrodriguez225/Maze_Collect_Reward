using System;
using System.Collections.Generic;
namespace Game
{    
    public class Program
    {
        public static void Main(string[] args)
        {
            Maze maze = new Maze(11,11);

            Player player1= new Player("Player1",new BlueChip("Pedro",3,0),0,maze);
            Player player2= new Player("Player2",new BlueChip("Pedro",2,0),0,maze);
            //maze.ActivatedModifierInMaze(p);
            var players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            Player winnerPlayer = null;
            Player auxPlayer = new Player("AuxPlayer", new BlueChip("BlueChip",3,0),0,maze);
            int i = 0;
            Print(maze, players, maze.Modifiers);
            do{
                int x = 0;
                auxPlayer = players[i % players.Count];
                while(x <= auxPlayer.Chip.Speed)
                {
                    auxPlayer.Move(maze);
                    x++;
                    Console.WriteLine(" ");
                    auxPlayer.CollectMoney(maze);
                    winnerPlayer = VictoryCondition.CheckVictory(maze,players);
                    Print(maze, players, maze.Modifiers);
                }
                i++;
            }
            while (winnerPlayer == null);
            Console.WriteLine($"Ha ganado el player {winnerPlayer.Name}");
        }
        public static void Print(Maze maze, List<Player> players, List<Modifier> Modifiers)
        {
            for (int x = 0; x < maze.maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.maze.GetLength(1); y++)
                {
                        if(x == players[0].PositionX && y == players[0].PositionY)
                            Console.Write("9 ");
                        else if (x == players[1].PositionX && y == players[1].PositionY)
                            Console.Write("8 ");
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