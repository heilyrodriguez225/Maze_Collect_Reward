using System;
using System.Collections.Generic;
using Spectre.Console;
namespace Game
{    
    public class Menu
    {
        public static void StartGame()
        {
            AnsiConsole.Write(new FigletText("Maze Collect Reward").Color(Color.Red).LeftJustified());
            Thread.Sleep(3000);
            AnsiConsole.Clear();
        }
        public static void MenuPrint()
        {
            var select = new SelectionPrompt<string>(). Title(" GAME MENU").PageSize(3);
            select.AddChoiceGroup("Options", new string[] {"[Red]Play[/]","[Red]Number of Players[/]","[Red]Adjust Volume[/]","[Red]Select Difficulty Level[/]","[Red]Exit[/]"});
            var option = AnsiConsole.Prompt(
                select
            );
            if(option == "[Red]Number of Players[/]")
            {

            }
            else if(option == "[Red]Adjust Volume[/]")
            {

            }
            else if(option == "[Red]Select Difficulty Level[/]")
            {

            }
            else if(option == "[Red]Exit[/]")
            {
                Environment.Exit(0);
            }
        }
    }
}