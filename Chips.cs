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
            public override void UseSkill(Parameters x, Player player) // Pass Through Wall 
            {
                if(CanJump(x.positionActualX, x.positionActualY, x.maze.maze, Directions.Right))
                {
                    x.positionActualY += 2; 
                    player.PositionY = x.positionActualY;  
                }
                else if(CanJump(x.positionActualX, x.positionActualY, x.maze.maze, Directions.Left))
                {
                    x.positionActualY -= 2;
                    player.PositionY = x.positionActualY;     
                }
                else if(CanJump(x.positionActualX, x.positionActualY, x.maze.maze, Directions.Up))
                {
                    x.positionActualX -= 2;  
                    player.PositionX = x.positionActualX;   
                }
                else if(CanJump(x.positionActualX, x.positionActualY, x.maze.maze, Directions.Down))
                {
                    x.positionActualX += 2;  
                    player.PositionX = x.positionActualX;   
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
