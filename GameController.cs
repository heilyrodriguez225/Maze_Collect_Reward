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
           Chips.Add(new RedChip("RedChip", 3, 4)); 
           Chips.Add(new YellowChip("YellowChip", 3, 3));
           Chips.Add(new OrangeChip("OrangeChip", 4, 4));
           Chips.Add(new PurpleChip("PurpleChip", 2, 5));
        }
        /*public static void InitializePlayers()
        {
            AnsiConsole.Markup("[underline black] Elige una ficha:"); 
            for (int i = 0; i < Chips.Count; i++) 
            { 
                AnsiConsole.Markup($"[underline black]{i + 1}. {Chips[i].Name} - Velocidad: {Chips[i].Speed}, Enfriamiento: {Chips[i].Cooldown}"); 
            } 
            int selection = int.Parse(Console.ReadLine()) - 1; 

            Players.Add(new Player("Player1", Chips[selection], 0, Maze));
            Players.Add(new Player("Player2", Chips[selection], 0, Maze));
            Players.Add(new Player("Player3", Chips[selection], 0, Maze));
            Players.Add(new Player("Player4", Chips[selection], 0, Maze));
        }*/
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
    }
}
