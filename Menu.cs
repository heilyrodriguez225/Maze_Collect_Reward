using System;
using System.Collections.Generic;
using Spectre.Console;
namespace Game
{    
    public class Menu
    {
        private static int numberOfPlayers = 2;
        private static string difficultyLevel = "Medium"; 
        public static void StartGame()
        {
            AnsiConsole.Write(new FigletText("Maze Collect Reward").Color(Color.Red).LeftJustified());
            Thread.Sleep(3000);
            AnsiConsole.Clear();
            ShowMainMenu();
        }
        public static void ShowMainMenu()
        {
            bool exit = false;

            while (!exit)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("GAME MENU")
                        .PageSize(4)
                        .AddChoices(new[] 
                        {
                            "Play",
                            "Number of Players",
                            "Select Difficulty Level",
                            "Exit"
                        })
                );

                switch (option)
                {
                    case "Play":
                        StartGameWithSettings();
                        break;
                    case "Number of Players":
                        SelectNumberOfPlayers();
                        break;
                    case "Select Difficulty Level":
                        SelectDifficultyLevel();
                        break;
                    case "Exit":
                        exit = true;
                        Environment.Exit(0);
                        break;
                }
            }
        }
        private static void StartGameWithSettings()
        {
            Console.Clear();
            AnsiConsole.Write(new FigletText("Starting Game").Color(Color.Green).LeftJustified());
            AnsiConsole.WriteLine($"Number of Players: {numberOfPlayers}");
            AnsiConsole.WriteLine($"Difficulty Level: {difficultyLevel}");
            AnsiConsole.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            GameManager.StartGame(numberOfPlayers, difficultyLevel);
        }

        private static void SelectNumberOfPlayers()
        {
            var numberPlayers = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Number of Players")
                    .PageSize(3)
                    .AddChoices(new[] { "One Player", "Two Players"})
            );

            if (numberPlayers == "One Player")
            {
                numberOfPlayers = 1;
                AnsiConsole.WriteLine("Number of Players set to 1.");
            }
            else if (numberPlayers == "Two Players")
            {
                numberOfPlayers = 2;
                AnsiConsole.WriteLine("Number of Players set to 2.");
            }
            Thread.Sleep(1000);
        }
        private static void SelectDifficultyLevel()
        {
            var difficulty = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select Difficulty Level")
                    .PageSize(4)
                    .AddChoices(new[] { "Easy", "Medium", "Hard"})
            );
            difficultyLevel = difficulty;
            AnsiConsole.WriteLine($"Difficulty Level set to {difficultyLevel}.");
            Thread.Sleep(1000); 
        }
    }
}