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
        public abstract void UseSkill();

        public virtual void ReduceCooldown(Player currentPlayer, bool GameOver, int Cooldown) //una vez que el jugador halla jugado cooldown-1
        {
            while(!GameOver)
            {

            }
        }
        
    }
    public class BlueChip : Chip
    {
        public BlueChip(string name, int speed, int cooldown) : base(name, speed, cooldown){}
        public override void UseSkill() // SuperSpeed
        {
            throw new NotImplementedException();
        }
        int count = 3;
        int speedRound;
        public void UseSkill(int speed, int round)
        {
             if(Cooldown == 0)
            { 
                if (round != speedRound + count)
                {
                speed = speed * 2;
                }
            }
        }
    }
    public class RedChip : Chip
    {
        public RedChip(string name, int speed, int cooldown) : base(name, speed, cooldown){}
        public override void UseSkill() // Pass Through Wall
        {
            throw new NotImplementedException();
        }
        /*public void UseSkill() 
        {
            if(Cooldown == 0)
            {
                //Logica de la habilidad
            }
        }*/
    }
    public class YellowChip : Chip
    {
        public YellowChip(string name, int speed, int cooldown) : base(name, speed, cooldown){}
        public override void UseSkill() // Move To A Random Cell
        {
            throw new NotImplementedException();
        }
        public  void UseSkill(int positionActualX, int positionActualY, List<int[]> PathCells)
        {
            if(Cooldown == 0)
            {
                Random random = new Random();
                int randomCell = random.Next(PathCells.Count); 
                positionActualX = PathCells[randomCell][0];
                positionActualY = PathCells[randomCell][1];
            }
        }
    }
    public class OrangeChip : Chip
    {
        public OrangeChip(string name, int speed, int cooldown) : base(name, speed, cooldown){}
        public override void UseSkill() //Win A Diamond
        {
            throw new NotImplementedException();
        }
        int diamond = 3;
        public void UseSkill(int playerMoney) 
        {
            if(Cooldown == 0)
            {
                playerMoney = playerMoney + diamond;
            }
        }
    }
    public class PurpleChip : Chip
    {
        public PurpleChip(string name, int speed, int cooldown) : base(name, speed, cooldown){}
         public override void UseSkill() // WinACoin
         {
            throw new NotImplementedException();
         }
         int coin = 1;
        public void UseSkill(int playerMoney) 
        {
            if(Cooldown == 0)
            {
                playerMoney = playerMoney + coin;
            }
        }
    }
}
