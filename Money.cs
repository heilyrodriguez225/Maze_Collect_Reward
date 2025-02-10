using System; 
using System.Collections.Generic; 
namespace Game
{
    public abstract class Money
    {
        public int CoordinateX { get; }
        public int CoordinateY { get; }
        protected Money(int coordinateX, int coordinateY)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }
    }
    public class Coin: Money
    {
        public int Value { get; }
        
        public Coin(int coordinateX, int coordinateY):base(coordinateX, coordinateY)
        {
            Value = 1;
        }
    }
    public class Diamond: Money
    {
        public int Value { get; }
        
        public Diamond(int coordinateX, int coordinateY): base(coordinateX, coordinateY)
        {
            Value = 3;
        }
    }
}