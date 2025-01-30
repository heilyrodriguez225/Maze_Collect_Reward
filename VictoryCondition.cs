using System; 
using System.Collections.Generic; 
namespace Game
{
    public class VictoryCondition
    {
        //si ya no quedan monedas en el maze revisa el money 
        //de cada jugador y gana el que mas money tenga
        public static Player CheckVictory(Maze maze, List<Player> Players)
        {
            if(maze.MoneyLeft() == false)
            {
                Player player = new Player("aux",new BlueChip("aux",2,2),-1,maze);
                for (int i = 0; i < Players.Count; i++)
                {
                    if (Players[i].Money > player.Money)
                    {
                        player = Players[i];
                    }
                }
                return player;
            }
            return null;
        }
    }
}