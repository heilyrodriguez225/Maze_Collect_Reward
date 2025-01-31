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
    public class MoveToARandomCellTrap : Modifier 
    {
        public MoveToARandomCellTrap(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        public override void ActivatedModifier(Parameters x) 
        {
            Random random = new Random();
            int randomCell = random.Next(x.PathCells.Count); 
            x.positionActualX = x.PathCells[randomCell][0];
            x.positionActualY = x.PathCells[randomCell][1];
        }
    }
    public class OverrideSkillTrap : Modifier 
    {
        public OverrideSkillTrap(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        public override void ActivatedModifier(Parameters x) 
        {
                x.cooldown = x.maxCooldown;
        }
    }
    public class SlowDownChipTrap : Modifier 
    {
        public SlowDownChipTrap(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        public override void ActivatedModifier(Parameters x) 
        {
            x.speed = 1;
        }
    }
    public class LoseADiamondTrap : Modifier 
    {
        public LoseADiamondTrap(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        public override void ActivatedModifier(Parameters x) 
        {
            x.playerMoney -= 3;
        }
    }
    public class LoseACoinTrap : Modifier 
    {
        public LoseACoinTrap(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        public override void ActivatedModifier(Parameters x) 
        {
            x.playerMoney --;
        }
    }
    public class WinADiamondBenefit : Modifier 
    {
        public WinADiamondBenefit(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        public override void ActivatedModifier(Parameters x)
        {
            x.playerMoney += 3;
        }
    }
    public class WinACoinBenefit : Modifier 
    {
        public WinACoinBenefit(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        public override void ActivatedModifier(Parameters x) 
        {
            x.playerMoney ++;
        }
    }
    public class PassThroughWallBenefit : Modifier 
    {
        public PassThroughWallBenefit(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        public override void ActivatedModifier(Parameters x) 
        {
            if(CanJump(x.positionActualX, x.positionActualY, x.maze.maze, Directions.Right))
            {
                x.positionActualY += 2;   
            }
            else if(CanJump(x.positionActualX, x.positionActualY, x.maze.maze, Directions.Left))
            {
                x.positionActualY -= 2;    
            }
            else if(CanJump(x.positionActualX, x.positionActualY, x.maze.maze,Directions.Up))
            {
                x.positionActualX -= 2;    
            }
            else if(CanJump(x.positionActualX, x.positionActualY, x.maze.maze,Directions.Down))
            {
                x.positionActualX += 2;    
            }
        }
        public bool CanJump(int positionActualX, int positionActualY, int[,] maze, Directions directions)
        {
            bool canJump = false;
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
            return canJump;
        }
    }
    public class SuperSpeedBenefit : Modifier 
    {
        public SuperSpeedBenefit(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        public override void ActivatedModifier(Parameters x) 
        {
            x.speed = x.speed * 2;
        }
    }
    public enum Directions
    {
        Up, Down, Left, Right,
    }
}