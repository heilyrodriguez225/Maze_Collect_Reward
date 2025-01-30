using System; 
using System.Collections.Generic; 
using System.Threading;
namespace Game
{
    public abstract class Chip
    {
        public string Name { get; set; }
        public int Speed { get; set; } //velocidad
        public int Cooldown { get; set; } //enfriamiento

        public Chip(string name, int speed, int cooldown)
        {
            Name = name;
            Speed = speed;
            Cooldown = cooldown;
        }
        public abstract void UseSkill(Parameters x);
       
        public virtual void ReduceCooldown(Player currentPlayer, bool GameOver, int Cooldown, bool itsYourTurn) //una vez que el jugador halla jugado cooldown-1
        {
            while(!GameOver)
            {
                if (currentPlayer.Chip.Cooldown > 0) 
                { 
                    currentPlayer.Chip.Cooldown--;
                }
            }
        }
    }
    public class BlueChip : Chip
    {
        public BlueChip(string name, int speed, int cooldown) : base(name, speed, cooldown){}
        int count = 3;
        int speedRound;
        public override void UseSkill(Parameters x) // SuperSpeed
        {
             if(Cooldown == 0)
            { 
                if (x.round != speedRound + count)
                {
                x.speed = x.speed * 2;
                }
            }
        }
    }
    public class RedChip : Chip
    {
        public RedChip(string name, int speed, int cooldown) : base(name, speed, cooldown){}
        public override void UseSkill(Parameters x) // Pass Through Wall 
        {
            if(Cooldown == 0)
            {
                if(CanJump(0, x.positionActualX, x.positionActualY, x.maze.maze, Directions.Right))
                {
                    x.positionActualY += 2;   
                }
                else if(CanJump(0, x.positionActualX, x.positionActualY, x.maze.maze, Directions.Left))
                {
                    x.positionActualY -= 2;    
                }
                else if(CanJump(0, x.positionActualX, x.positionActualY, x.maze.maze, Directions.Up))
                {
                    x.positionActualX -= 2;    
                }
                else if(CanJump(0, x.positionActualX, x.positionActualY, x.maze.maze, Directions.Down))
                {
                    x.positionActualX += 2;    
                }
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
    public class YellowChip : Chip
    {
        public YellowChip(string name, int speed, int cooldown) : base(name, speed, cooldown){}
        public override void UseSkill(Parameters x) // Move To A Random Cell
        {
            if(Cooldown == 0)
            {
                Random random = new Random();
                int randomCell = random.Next(x.PathCells.Count); 
                x.positionActualX = x.PathCells[randomCell][0];
                x.positionActualY = x.PathCells[randomCell][1];
            }
        }
    }
    public class OrangeChip : Chip
    {
        public OrangeChip(string name, int speed, int cooldown) : base(name, speed, cooldown){}
        int diamond = 3;
        public override void UseSkill(Parameters x) //Win A Diamond
        {
            if(Cooldown == 0)
            {
                x.playerMoney = x.playerMoney + diamond;
            }
        }
    }
    public class PurpleChip : Chip
    {
        public PurpleChip(string name, int speed, int cooldown) : base(name, speed, cooldown){}
         int coin = 1;
        public override void UseSkill(Parameters x) // WinACoin
        {
            if(Cooldown == 0)
            {
                x.playerMoney = x.playerMoney + coin;
            }
        }
    }
}
