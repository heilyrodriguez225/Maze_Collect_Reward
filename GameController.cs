using System;
using System.Collections.Generic;
using Spectre.Console;
namespace Game
{    
    public static class GameController
    {
        static List<Player> Players = new List<Player>();  
        static List<Chip> Chips = new List<Chip>();
        private static void InitializeChip()
        {
           Chips.Add(new BlueChip("BlueChip", 2, 3)); 
           Chips.Add(new RedChip("RedChip", 3, 5)); 
           Chips.Add(new YellowChip("YellowChip", 3, 4));
           Chips.Add(new OrangeChip("OrangeChip", 4, 5));
           Chips.Add(new PurpleChip("PurpleChip", 2, 6));
        }
        public static void InitializePlayers()
        {
            AnsiConsole.Markup("[underline black] Elige una ficha:"); 
            for (int i = 0; i < Chips.Count; i++) 
            { 
                AnsiConsole.Markup($"[underline black]{i + 1}. {Chips[i].Name} - Velocidad: {Chips[i].Speed}, Enfriamiento: {Chips[i].Cooldown}"); 
            } 
            int selection = int.Parse(Console.ReadLine()) - 1; 

            Players.Add(new Player("Player1", 1, 1, Chips[selection], 0));
            Players.Add(new Player("Player2", 24, 1, Chips[selection], 0));
            Players.Add(new Player("Player3", 1, 24, Chips[selection], 0));
            Players.Add(new Player("Player4", 24, 24, Chips[selection], 0));
        }
        static int currentRound = 1;
        static int currentTurn = 0;
        static Player currentPlayer = Players[currentTurn];
        public static bool GameOver = false;
        public static void UpdateRound()
        {
            while(!GameOver)
            {
                currentTurn++;
                int aux;
                aux = currentTurn % Players.Count;
                currentPlayer = Players[aux];
                currentRound = (currentTurn / Players.Count) + 1;
            }
        }
        public static void Move(int positionX, int positionY)
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            key = Console.ReadKey(true);
            switch (key.Key) 
            { 
                case ConsoleKey.UpArrow: 
                    if(positionY > 0) positionY--;
                    break;
                case ConsoleKey.DownArrow: 
                    if(positionY < Console.WindowHeight - 1) positionY++;
                    break; 
                case ConsoleKey.LeftArrow: 
                    if(positionX > 0) positionX--; 
                    break; 
                case ConsoleKey.RightArrow: 
                    if(positionX < Console.WindowWidth - 1) positionX++;
                    break; 
            }
        }
    }
}
