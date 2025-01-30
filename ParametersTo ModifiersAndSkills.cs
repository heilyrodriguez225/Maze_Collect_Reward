using System; 
using System.Collections.Generic; 
namespace Game
{
    public class Parameters //Contenedor de dependencia
    {
        public int positionInitialX;
        public int positionInitialY;
        public int positionActualX; 
        public int positionActualY;
        public int round;
        public bool itsYourTurn;
        public int cooldown; 
        public int initialCooldown;
        public int speed; 
        public int playerMoney;
        public List<int[]> PathCells;
        public Maze maze;

        public void PositionInitialXAdd(int x)
        {
            positionInitialX = x;
        }
        public void PositionInitialYAdd(int x)
        {
            positionInitialY = x;
        }
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
        public void ItsYourTurnAdd(bool x)
        {
            itsYourTurn= x;
        }
        public void CooldownAdd(int x)
        {
            cooldown = x;
        }
        public void InitialCooldownAdd(int x)
        {
            initialCooldown = x;
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