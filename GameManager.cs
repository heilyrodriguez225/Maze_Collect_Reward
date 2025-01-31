using System;
using System.Collections.Generic;
using Spectre.Console;
namespace Game
{    
    public class GameManager
    {
        public static void Main(string[] args)
        {
            Maze maze = new Maze(23,23);

            List<Chip> Chips = new List<Chip>();
            Chips.Add(new OrangeChip("SuperSpeed", 2, 6, 6)); 
            Chips.Add(new PinkChip("PassThroughWall ", 3, 12, 12)); 
            Chips.Add(new BrownChip("MoveToARandomCell", 3, 9, 9));
            Chips.Add(new GreenChip("WinADiamond", 4, 16, 16));
            Chips.Add(new WhiteChip("WinACoin", 2, 10, 10));

            Player player1= new Player("Player1",new OrangeChip("OrangeChip", 2, 3, 3),0,maze);
            player1.SelectRandomChip(Chips);
            Player player2= new Player("Player2",new OrangeChip("OrangeChip", 2, 3, 3),0,maze);
            player2.SelectRandomChip(Chips);
            var players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            Player winnerPlayer = null;
            Player auxPlayer = new Player("AuxPlayer", new OrangeChip("OrangeChip",3,0,0),0,maze);
            int turn = 0;
            Draw.Print(maze, players, maze.Modifiers);
            Draw.InitialPlayer1Print(player1, players);
            Draw.InitialPlayer2Print(player2, players);
            do{
                int i = 0;
                int round = turn/players.Count + 1;
                auxPlayer = players[turn % players.Count];
                while(i <= auxPlayer.Chip.Speed)
                {
                    Parameters parameter = new Parameters();
                    parameter.PositionActualXAdd(auxPlayer.PositionX);
                    parameter.PositionActualYAdd(auxPlayer.PositionY);
                    parameter.RoundAdd(round);
                    parameter.ItsYourTurnAdd(true);
                    parameter.CooldownAdd(auxPlayer.Chip.Cooldown);
                    parameter.MaxCooldownAdd(auxPlayer.Chip.MaxCooldown);
                    parameter.SpeedAdd(auxPlayer.Chip.Speed);
                    parameter.PlayerMoneyAdd(auxPlayer.Money);
                    parameter.PathCellsAdd(maze.PathCells);
                    parameter.MazeAdd(maze);
                    
                    if(auxPlayer.Chip.Cooldown <= 0)
                    {
                        Draw.UseSkillPrint(auxPlayer);
                        ConsoleKeyInfo key = new ConsoleKeyInfo();
                        key = Console.ReadKey(true);
                        switch (key.Key)
                        {
                            case ConsoleKey.A:
                                auxPlayer.Chip.UseSkill(parameter);
                                auxPlayer.Chip.Cooldown = auxPlayer.Chip.MaxCooldown;
                                break;
                            default:
                                break;
                        }
                    }
                    auxPlayer.Move(maze);
                    maze.ActivatedModifierInMaze(auxPlayer, parameter);
                    i++;
                    Console.Clear();
                    //Console.WriteLine(" ");
                    auxPlayer.CollectMoney(maze);
                    winnerPlayer = VictoryCondition.CheckVictory(maze,players);
                    auxPlayer.Chip.Cooldown --;
                    Draw.Print(maze, players, maze.Modifiers);
                    Draw.TurnPrint(auxPlayer);
                    Console.WriteLine($"Speed:{auxPlayer.Chip.Speed}    Cooldown:{auxPlayer.Chip.Cooldown}    Money:{auxPlayer.Money}");
                    Draw.ActivatedModifierPrint(maze, auxPlayer);
                }
                turn++;
            }
            while (winnerPlayer == null);
            Console.WriteLine($"Ha ganado el player {winnerPlayer.Name}");
        }
    }
}