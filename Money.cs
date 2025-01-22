using System; 
using System.Collections.Generic; 
namespace Game
{
    public class Coin
    {
        public int CoordinateX { get; }
        public int CoordinateY { get; }
        public int Value { get; }
        
        public Coin(int coordinateX, int coordinateY)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            Value = 1;
        }
    }
    public class Diamond
    {
        public int CoordinateX { get; }
        public int CoordinateY { get; }
        public int Value { get; }
        
        public Diamond(int coordinateX, int coordinateY)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            Value = 3;
        }
    }
}