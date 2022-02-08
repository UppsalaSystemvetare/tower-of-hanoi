using System;
using System.Collections.Generic;

namespace progtävling_tower_of_hanoi
{
    public class Tower
    {
        private List<Brick> bricks;

        public Tower()
        {
            bricks = new List<Brick>();
        }

        public Tower(int size)
        {
            bricks = new List<Brick>();
            for (int i = size - 1; i >= 0; i--)
            {
                bricks.Add(new Brick(i));
            }
        }

        public bool PlaceBrick(Brick brick)
        {
            if (bricks.Count == 0)
            {
                bricks.Add(brick);
                return true;
            }
            else if (brick.Size < bricks[bricks.Count - 1].Size)
            {
                bricks.Add(brick);
                return true;
            }
            return false;
        }

        public bool RemoveBrick(out Brick brick)
        {
            if (bricks.Count == 0)
            {
                brick = null;
                return false;
            }
            else
            {
                brick = bricks[bricks.Count - 1];
                bricks.Remove(brick);
                return true;
            }
        }
        public int[] ToIntArray()
        {
            int[] result = new int[bricks.Count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = bricks[i].Size;
            }
            return result;
        }

        public bool IsEmpty()
        {
            if (bricks.Count == 0)
                return true;
            return false;
        }
        public override string ToString()
        {
            string s = "[";
            foreach (Brick b in bricks)
                s += b.ToString() + ",";
            s = s.Trim(',');
            s += "]";
            return s;
        }
    }
}
