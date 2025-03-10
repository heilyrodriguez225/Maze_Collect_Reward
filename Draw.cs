using System;
using System.Collections.Generic;
using Spectre.Console;
namespace Game
{    
    public class Draw
    {
        public static void Print(Maze maze, List<Player> players, List<Modifier> Modifiers)
        {
            for (int x = 0; x < maze.maze.GetLength(0); x++)
            {
                string row = "";
                for (int y = 0; y < maze.maze.GetLength(1); y++)
                {
                        if(x == players[0].PositionX && y == players[0].PositionY)
                        {
                            if(players[0].Chip is OrangeChip)
                                row+=("🦋");
                            else if(players[0].Chip is PinkChip)
                                row+=("🐖");
                            else if(players[0].Chip is BrownChip)
                                row+=("🦉");
                            else if(players[0].Chip is GreenChip)
                                row+=("🐢");
                            else if(players[0].Chip is WhiteChip)
                                row+=("🦢");
                        }
                        else if (x == players[1].PositionX && y == players[1].PositionY)
                        {
                            if(players[1].Chip is OrangeChip)
                                row+=("🦀");
                            else if(players[1].Chip is PinkChip)
                                row+=("🦩");
                            else if(players[1].Chip is BrownChip)
                                row+=("🐎");
                            else if(players[1].Chip is GreenChip)
                                row+=("🐊");
                            else if(players[1].Chip is WhiteChip)
                                row+=("🐑");
                        }
                        else if(PrintCoins(maze,x,y))
                            row+=("💰");
                        else if(PrintDiamonds(maze,x,y))
                            row+=("💎");
                        else if(PrintModifiers(maze,x,y))
                            row+=("🔸");
                        else if(maze.maze[x,y] == 1)
                            row+=("🧱");
                        else if(maze.maze[x,y] == 0)
                            row+=("  ");
                }
                Console.WriteLine(row);
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
        public static void InitialPlayer1Print(Player player, List<Player> Players)
        {
            if(player == Players[0])
            {
                if(player.Chip is OrangeChip)
                    Console.WriteLine("Player1: 🦋");
                else if(player.Chip is PinkChip)
                    Console.WriteLine("Player1: 🐖");
                else if(player.Chip is BrownChip)
                    Console.WriteLine("Player1: 🦉");
                else if(player.Chip is GreenChip)
                    Console.WriteLine("Player1: 🐢");
                else if(player.Chip is WhiteChip)
                    Console.WriteLine("Player1: 🦢");
            }
        }
        public static void InitialPlayer2Print(Player player, List<Player> Players)
        {
            if(player == Players[1])
            {
                if(player.Chip is OrangeChip)
                    Console.WriteLine("Player2: 🦀");
                else if(player.Chip is PinkChip)
                    Console.WriteLine("Player2: 🦩");
                else if(player.Chip is BrownChip)
                    Console.WriteLine("Player2: 🐎");
                else if(player.Chip is GreenChip)
                    Console.WriteLine("Player2: 🐊");
                else if(player.Chip is WhiteChip)
                    Console.WriteLine("Player2: 🐑");
            }
        }
        public static void TurnPrint(Player player)
        {
            Console.WriteLine($"Es el turno de {player.Name}");
        }
        public static void ActivatedModifierPrint(Maze maze,Player player)
        {
            if(maze.ActivatedModifierInMaze != null)
            {   
                for (int k = 0; k < maze.Modifiers.Count; k++)
                {
                    if(player.PositionX == maze.Modifiers[k].CoordinateX && player.PositionY == maze.Modifiers[k].CoordinateY)
                    {
                        if(maze.Modifiers[k] is MoveToARandomCellTrap)
                            Console.WriteLine($"Ha caido en un modificador MoveARandomCellTrap");
                        else if(maze.Modifiers[k] is OverrideSkillTrap)
                            Console.WriteLine($"Ha caido en un modificador OverrideSkillTrap");
                        else if(maze.Modifiers[k] is SlowDownChipTrap)
                            Console.WriteLine($"Ha caido en un modificador SlowDownChipTrap");
                        else if(maze.Modifiers[k] is WinADiamondBenefit)
                            Console.WriteLine($"Ha caido en un modificador WinADiamondBenefit");
                        else if(maze.Modifiers[k] is WinACoinBenefit)
                            Console.WriteLine($"Ha caido en un modificador WinACoinBenefit");
                        else if(maze.Modifiers[k] is DismissSpeedAndDuplicateMoneyBenefit)
                            Console.WriteLine($"Ha caido en un modificador DismissSpeedAndDuplicateMoneyBenefit");
                        else if(maze.Modifiers[k] is SuperSpeedBenefit)
                            Console.WriteLine($"Ha caido en un modificador SuperSpeedBenefit");
                        else if(maze.Modifiers[k] is LoseADiamondTrap)
                            Console.WriteLine($"Ha caido en un modificador LoseADiamondTrap");
                        else if(maze.Modifiers[k] is LoseACoinTrap)
                            Console.WriteLine($"Ha caido en un modificador LoseACoinTrap");
                    }
                }
            }
        }
        public static void UseSkillPrint(Player player)
        {
            if(player.Chip.Cooldown <= 0)
            {
                Console.WriteLine($"Puede usar su habilidad {player.Chip.Name}");
            }
        }
    }
}