using System; 
using System.Collections.Generic; 
namespace Game
{
    public abstract class Modifier
    {
        public int CoordinateX { get; }
        public int CoordinateY { get; }

        public Modifier(int coordinateX, int coordinateY)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }
        public abstract void ActivatedModifier(Parameters x);
    }
    public class ReturnToStartTrap : Modifier 
    {
        public ReturnToStartTrap(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}

        public override void ActivatedModifier(Parameters x)
        {
            x.positionActualX = x.positionInitialX;
            x.positionActualY = x.positionInitialY;
        }
    }
    public class MoveToARandomCellTrap : Modifier 
    {
        public MoveToARandomCellTrap(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        public override void ActivatedModifier(Parameters x) //int positionActualX, int positionActualY, List<int[]> PathCells
        {
            Random random = new Random();
            int randomCell = random.Next(x.PathCells.Count); 
            x.positionActualX = x.PathCells[randomCell][0];
            x.positionActualY = x.PathCells[randomCell][1];
        }
    }
    public class ParalyzeTrap : Modifier 
    {
        public ParalyzeTrap(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        int slow = 3;
        int paralyzeRound;
        public override void ActivatedModifier(Parameters x) 
        {
            if (x.round != paralyzeRound + slow && x.itsYourTurn == true)
            {
                x.itsYourTurn = false;
            }
            else
            {
                x.itsYourTurn = true;
            }
        }
    }
    public class OverrideSkillTrap : Modifier 
    {
        public OverrideSkillTrap(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        public override void ActivatedModifier(Parameters x) 
        {
            if(x.cooldown == 0)
            {
                x.cooldown = x.initialCooldown;
            }
        }
    }
    public class SlowDownChipTrap : Modifier 
    {
        public SlowDownChipTrap(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        int retarder = 3;
        int retarderRound;
        public override void ActivatedModifier(Parameters x) 
        {
            if (x.round != retarderRound + retarder && x.itsYourTurn == true)
            {
                x.speed = 1;
            }
        }
    }
    public class LoseADiamondTrap : Modifier 
    {
        public LoseADiamondTrap(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        int diamond = 3;
        public override void ActivatedModifier(Parameters x) 
        {
            x.playerMoney = x.playerMoney - diamond;
        }
    }
    public class LoseACoinTrap : Modifier 
    {
        public LoseACoinTrap(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        int coin = 1;
        public override void ActivatedModifier(Parameters x) 
        {
            x.playerMoney = x.playerMoney - coin;
        }
    }
    public class WinADiamondBenefit : Modifier 
    {
        public WinADiamondBenefit(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        int diamond = 3;
        public override void ActivatedModifier(Parameters x)
        {
            x.playerMoney = x.playerMoney + diamond;
        }
    }
    public class WinACoinBenefit : Modifier 
    {
        public WinACoinBenefit(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}

        int coin = 1;
        public override void ActivatedModifier(Parameters x) //int playerMoney
        {
            x.playerMoney = x.playerMoney + coin;
        }
    }
    public class PassThroughWallBenefit : Modifier 
    {
        public PassThroughWallBenefit(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        public override void ActivatedModifier(Parameters x) 
        {
            if(CanJump(0, x.positionActualX, x.positionActualY, x.maze.maze, Directions.Right))
            {
                x.positionActualY += 2;   
            }
            else if(CanJump(0,x.positionActualX, x.positionActualY, x.maze.maze, Directions.Left))
            {
                x.positionActualY -= 2;    
            }
            else if(CanJump(0,x.positionActualX, x.positionActualY, x.maze.maze,Directions.Up))
            {
                x.positionActualX -= 2;    
            }
            else if(CanJump(0,x.positionActualX, x.positionActualY, x.maze.maze,Directions.Down))
            {
                x.positionActualX += 2;    
            }
        }
        public bool CanJump(int cooldown, int positionActualX, int positionActualY, int[,] maze, Directions directions)
        {
            bool canJump = false;
            if(cooldown == 0)
            {
                if(directions == Directions.Right && maze[positionActualX, positionActualY + 1] == 1 && maze[positionActualX, positionActualY + 2] == 0)
                {
                    canJump = true;
                }
                else if(directions == Directions.Left && maze[positionActualX, positionActualY - 1] == 1 && maze[positionActualX, positionActualY - 2] == 0)
                {
                    canJump = true;
                }
                else if(directions == Directions.Up && maze[positionActualX - 1, positionActualY] == 1 && maze[positionActualX - 2, positionActualY] == 0)
                {
                    canJump = true;
                }
                else if(directions == Directions.Down && maze[positionActualX + 1, positionActualY] == 1 && maze[positionActualX + 2, positionActualY] == 0)
                {
                    canJump = true;
                }
            }
            return canJump;
        }
    }
    public class SuperSpeedBenefit : Modifier 
    {
        public SuperSpeedBenefit(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        int count = 3;
        int speedRound;
        public override void ActivatedModifier(Parameters x) //int speed, int round
        {

            if (x.round != speedRound + count)
            {
                x.speed = x.speed * 2;
            }
        }
    }
    public enum Directions
    {
        Up, Down, Left, Right,
    }
}