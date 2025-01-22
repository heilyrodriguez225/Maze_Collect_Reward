using System; 
using System.Collections.Generic; 
namespace Game
{
    public class Player
    {
        public string Name { get; set; }
        public int InitialPositionX { get; set; }
        public int InitialPositionY { get; set; }
        public Chip Chip { get; set; }
        public int Money { get; set; }

        public Player( string name, int initialPositionX, int initialPositionY, Chip chip, int money)
        {
            Name = name;
            InitialPositionX = initialPositionX;
            InitialPositionY = initialPositionY;
            Chip = chip;
            Money = money;
        }
    }
}