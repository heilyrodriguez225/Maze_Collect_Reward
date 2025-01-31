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
    public class DismissSpeedAndDuplicateMoneyBenefit : Modifier 
    {
        public DismissSpeedAndDuplicateMoneyBenefit(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        public override void ActivatedModifier (Parameters x) //Dismiss Speed And Duplicate Money
        {
            x.speed = 1;
            x.playerMoney *= 2;
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
}