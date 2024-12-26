using System; 
using System.Collections.Generic; 
namespace Game
{
    public class Coin
    {
        public int Value { get; }
        public Coin()
        {
            Value = 1;
        }
    }
    public class Diamond
    {
        public int Value { get; }
        public Diamond()
        {
            Value = 3;
        }
    }
}