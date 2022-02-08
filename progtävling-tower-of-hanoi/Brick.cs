using System;
namespace progtävling_tower_of_hanoi
{
    public class Brick
    {
        public int Size { get; private set; }

        public Brick(int size)
        {
            Size = size;
        }
        public override string ToString()
        {
            return Size.ToString();
        }
    }
}
