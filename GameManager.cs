using System;
using System.Collections.Generic;
using Spectre.Console;
namespace Game
{    
    public class GameManager
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Menu.StartGame();
            Menu.ShowMainMenu();
            Menu.StartGame();
        }
        public static void StartGame(int numberOfPlayers, string difficultyLevel)
        {
            int mazeSize, modifiers, coins, diamonds;

            switch (difficultyLevel)
            {
                case "Easy":
                    mazeSize = 9;
                    modifiers = 8;
                    coins = 15;
                    diamonds = 8;
                    break;
                case "Medium":
                    mazeSize = 15;
                    modifiers = 20;
                    coins = 25;
                    diamonds = 12;
                    break;
                case "Hard":
                    mazeSize = 23;
                    modifiers = 30;
                    coins = 40;
                    diamonds = 25;
                    break;
                default:
                    mazeSize = 15; 
                    modifiers = 20;
                    coins = 25;
                    diamonds = 12;
                    break;
            }
            Maze maze = new Maze(mazeSize, mazeSize, modifiers, coins, diamonds);

            List<Chip> Chips = new List<Chip>();
            Chips.Add(new OrangeChip("SuperSpeed", 1, 30, 30)); 
            Chips.Add(new PinkChip("DismissSpeedAndDuplicateMoney", 2, 24, 24)); 
            Chips.Add(new BrownChip("MoveToARandomCell", 2, 12, 12));
            Chips.Add(new GreenChip("WinADiamond", 2, 18, 18));
            Chips.Add(new WhiteChip("WinACoin", 3, 10, 10));

            var players = new List<Player>();
            Player player1= new Player("Player1",new OrangeChip("SuperSpeed", 2, 3, 3),0,maze);
            player1.SelectRandomChip(Chips);
            players.Add(player1);

            if(numberOfPlayers == 1)
            {
                Player virtualPlayer = new VirtualPlayer("VirtualPlayer", new OrangeChip("SuperSpeed", 2, 3, 3), 0, maze);
                virtualPlayer.SelectRandomChip(Chips);
                players.Add(virtualPlayer);
            }
            else
            {
                Player player2= new Player("Player2",new OrangeChip("SuperSpeed", 2, 3, 3),0,maze);
                player2.SelectRandomChip(Chips);
                players.Add(player2);
            }
            Player winnerPlayer = null;
            Player auxPlayer = new Player("AuxPlayer", new OrangeChip("OrangeChip",3,0,0),0,maze);
            int turn = 0;
            Draw.Print(maze, players, maze.Modifiers);
            Draw.InitialPlayer1Print(player1, players);
            
            if (numberOfPlayers > 1)
            {
                Draw.InitialPlayer2Print(players[1], players);
            }
            do{
                int i = 0;
                int round = turn/players.Count + 1;
                auxPlayer = players[turn % players.Count];
                while(i <= auxPlayer.Chip.Speed)
                {
                    Parameters parameter = new Parameters();
                    parameter.PositionActualXAdd(auxPlayer.PositionX);
                    parameter.PositionActualYAdd(auxPlayer.PositionY);
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
                                auxPlayer.Chip.UseSkill(parameter, auxPlayer);
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
                    Console.WriteLine($"Speed:{auxPlayer.Chip.Speed +1}    Cooldown:{auxPlayer.Chip.Cooldown}    Money:{auxPlayer.Money}");
                    Draw.ActivatedModifierPrint(maze, auxPlayer);
                }
                turn++;
            }
            while (winnerPlayer == null);
            Console.WriteLine($"Ha ganado el player {winnerPlayer.Name}");
        }
    }
}