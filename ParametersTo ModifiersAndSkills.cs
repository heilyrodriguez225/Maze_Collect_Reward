using System; 
using System.Collections.Generic; 
namespace Game
{
    public class Parameters //Contenedor de dependencia
    {
        public int positionActualX; 
        public int positionActualY;
        public int round;
        public int cooldown; 
        public int maxCooldown;
        public int speed; 
        public int playerMoney;
        public List<int[]> PathCells;
        public Maze maze;
        public void PositionActualXAdd(int x)
        {
            positionActualX = x;
        }
        public void PositionActualYAdd(int x)
        {
            positionActualY = x;
        }
        public void RoundAdd(int x)
        {
            round = x;
        }
        public void CooldownAdd(int x)
        {
            cooldown = x;
        }
        public void MaxCooldownAdd(int x)
        {
            maxCooldown = x;
        }
        public void SpeedAdd(int x)
        {
            speed = x;
        }
        public void PlayerMoneyAdd(int x)
        {
            playerMoney = x;
        }
        public void PathCellsAdd(List<int[]> x)
        {
            PathCells = x;
        }
        public void MazeAdd(Maze x)
        {
            maze = x;
        }
    }
}