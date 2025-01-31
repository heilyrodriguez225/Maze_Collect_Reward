using System; 
using System.Collections.Generic; 
namespace Game
{
    public class Player
    {
        public string Name { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public Chip Chip { get; set; }
        public int Money { get; set; }

        public Player( string name,Chip chip, int money,Maze maze)
        {
            Name = name;
            Chip = chip;
            Money = money;
            InitializePlayerPositionInMaze(maze);
            CollectMoney(maze);
        }
        public void Move(Maze maze)
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            key = Console.ReadKey(true);
            switch (key.Key) 
            { 
                case ConsoleKey.UpArrow: 
                    if(PositionX > 0 && maze.maze[PositionX - 1, PositionY] == 0) 
                        PositionX--;
                    else Move(maze);
                        return;
                case ConsoleKey.DownArrow: 
                    if(PositionX < maze.rows - 1 && maze.maze[PositionX + 1, PositionY] == 0) 
                        PositionX++;
                    else Move(maze);
                        return; 
                case ConsoleKey.LeftArrow: 
                    if(PositionY > 0 && maze.maze[PositionX, PositionY - 1] == 0) 
                        PositionY--; 
                    else Move(maze);
                        return; 
                case ConsoleKey.RightArrow: 
                    if(PositionY < maze.columns - 1 && maze.maze[PositionX, PositionY + 1] == 0) 
                        PositionY++;
                    else Move(maze);
                        return;
                default:
                    Move(maze);
                    break; 
            }
        }
        public void InitializePlayerPositionInMaze(Maze maze)
        {
            Random random = new Random();
            int x, y; 
                do 
                { 
                    x = random.Next(maze.maze.GetLength(0)); 
                    y = random.Next(maze.maze.GetLength(1)); 
                } 
                while (maze.maze[x, y] != 0); 
            PositionX = x;
            PositionY = y;
        }
        public void SelectRandomChip(List<Chip> Chips)
        {
            Random random = new Random();
            int x = random.Next(Chips.Count);
            Chip = Chips[x];
        }
        public void CollectMoney(Maze maze)
        {
            for (int k = 0; k < maze.Coins.Count; k++)
            {
                if(PositionX == maze.Coins[k].CoordinateX && PositionY == maze.Coins[k].CoordinateY)  
                {
                    maze.Coins.Remove(maze.Coins[k]);
                    Money ++;
                } 
            }
            for (int k = 0; k < maze.Diamonds.Count; k++)
            {
                if(PositionX == maze.Diamonds[k].CoordinateX && PositionY == maze.Diamonds[k].CoordinateY)  
                {
                    maze.Diamonds.Remove(maze.Diamonds[k]);
                    Money +=3;
                } 
            }
        }
    }
}