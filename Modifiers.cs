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
        public abstract void ActivatedModifier(Parameters x, Player player);
    }
    public class MoveToARandomCellTrap : Modifier 
    {
        public MoveToARandomCellTrap(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        public override void ActivatedModifier(Parameters x, Player player) 
        {
            Random random = new Random();
            int randomCell = random.Next(x.PathCells.Count); 
            x.positionActualX = x.PathCells[randomCell][0];
            x.positionActualY = x.PathCells[randomCell][1];
            player.PositionX = x.positionActualX;
            player.PositionY = x.positionActualY;
        }
    }
    public class OverrideSkillTrap : Modifier 
    {
        public OverrideSkillTrap(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        public override void ActivatedModifier(Parameters x, Player player) 
        {
            x.cooldown = x.maxCooldown;
            player.Chip.Cooldown = x.cooldown;
        }
    }
    public class SlowDownChipTrap : Modifier 
    {
        public SlowDownChipTrap(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        public override void ActivatedModifier(Parameters x, Player player) 
        {
            x.speed = 1;
            player.Chip.Speed = x.speed;
        }
    }
    public class LoseADiamondTrap : Modifier 
    {
        public LoseADiamondTrap(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        public override void ActivatedModifier(Parameters x, Player player) 
        {
            x.playerMoney -= 3;
            player.Money = x.playerMoney;
        }
    }
    public class LoseACoinTrap : Modifier 
    {
        public LoseACoinTrap(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        public override void ActivatedModifier(Parameters x, Player player) 
        {
            x.playerMoney --;
            player.Money = x.playerMoney;
        }
    }
    public class WinADiamondBenefit : Modifier 
    {
        public WinADiamondBenefit(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        public override void ActivatedModifier(Parameters x, Player player)
        {
            x.playerMoney += 3;
            player.Money = x.playerMoney;
        }
    }
    public class WinACoinBenefit : Modifier 
    {
        public WinACoinBenefit(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        public override void ActivatedModifier(Parameters x, Player player) 
        {
            x.playerMoney ++;
            player.Money = x.playerMoney;
        }
    }
    public class DismissSpeedAndDuplicateMoneyBenefit : Modifier 
    {
        public DismissSpeedAndDuplicateMoneyBenefit(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        public override void ActivatedModifier (Parameters x, Player player) //Dismiss Speed And Duplicate Money
        {
            x.speed = 1;
            x.playerMoney *= 2;
            player.Chip.Speed = x.speed;
            player.Money = x.playerMoney;
        }
    }
    public class SuperSpeedBenefit : Modifier 
    {
        public SuperSpeedBenefit(int coordinateX, int coordinateY) : base (coordinateX, coordinateY){}
        public override void ActivatedModifier(Parameters x, Player player) 
        {
            x.speed = x.speed * 2;
            player.Chip.Speed = x.speed;
        }
    }
}