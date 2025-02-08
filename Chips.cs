using System; 
using System.Collections.Generic; 
using System.Threading;
namespace Game
{
    public abstract class Chip
    {
        public string Name { get; set; }
        public int Speed { get; set; } 
        public int Cooldown { get; set; } 
        public int MaxCooldown { get; set; }
        public Chip(string name, int speed, int cooldown, int maxCooldown)
        {
            Name = name;
            Speed = speed;
            Cooldown = cooldown;
            MaxCooldown = maxCooldown;
        }
        public abstract void UseSkill(Parameters x, Player player);
    }
    public class OrangeChip : Chip
    {
        public OrangeChip(string name, int speed, int cooldown, int maxCooldown) : base(name, speed, cooldown, maxCooldown){}
        public override void UseSkill(Parameters x, Player player) // SuperSpeed
        {
            x.speed = x.speed * 2;
            player.Chip.Speed = x.speed;
        }
    }
    public class PinkChip : Chip
    {
        public PinkChip(string name, int speed, int cooldown, int maxCooldown) : base(name, speed, cooldown, maxCooldown){}
        public override void UseSkill (Parameters x, Player player) //Dismiss Speed And Duplicate Money
        {
            x.speed = 1;
            x.playerMoney *= 2;
            player.Chip.Speed = x.speed;
            player.Money = x.playerMoney;
        }
    }
    public class BrownChip : Chip
    {
        public BrownChip(string name, int speed, int cooldown, int maxCooldown) : base(name, speed, cooldown, maxCooldown){}
        public override void UseSkill(Parameters x, Player player) // Move To A Random Cell
        {
            Random random = new Random();
            int randomCell = random.Next(x.PathCells.Count); 
            x.positionActualX = x.PathCells[randomCell][0];
            x.positionActualY = x.PathCells[randomCell][1];
            player.PositionX = x.positionActualX;
            player.PositionY = x.positionActualY;
        }            
    }
    public class GreenChip : Chip
    {
        public GreenChip(string name, int speed, int cooldown, int maxCooldown) : base(name, speed, cooldown, maxCooldown){}
        public override void UseSkill(Parameters x, Player player) //Win A Diamond
        {
            x.playerMoney += 3;
            player.Money = x.playerMoney;
        }
    }
    public class WhiteChip : Chip
    {
        public WhiteChip(string name, int speed, int cooldown, int maxCooldown) : base(name, speed, cooldown, maxCooldown){}
        public override void UseSkill(Parameters x, Player player) // WinACoin
        {
            x.playerMoney ++;
            player.Money = x.playerMoney;
        }
    }
    public enum Directions
    {
        Right,
        Left,
        Up,
        Down,
    }
}
