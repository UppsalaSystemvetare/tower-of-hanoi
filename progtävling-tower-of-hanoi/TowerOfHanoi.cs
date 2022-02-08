using System;
using System.Collections.Generic;

namespace progtävling_tower_of_hanoi
{
    public class TowerOfHanoi
    {
        private List<Tower> towers;
        private Brick selected;
        private int boardSize;
        public int MovesMade { get; private set; }

        public TowerOfHanoi()
        {
            SetBoardSize(3);
        }

        public int[][] GetGameState()
        {
            int[][] board = new int[towers.Count + 1][];
            for (int i = 0; i < towers.Count; i++)
            {
                board[i] = towers[i].ToIntArray();
            }
            if (selected == null)
                board[towers.Count] = new int[0];
            else
                board[towers.Count] = new int[] { selected.Size };
            return board;
        }

        public bool MakeMove(int location)
        {
            if (location < 0 || location >= towers.Count)
                return false;
            if (selected == null)
            {
                if (towers[location].RemoveBrick(out selected))
                    return true;
                else
                    return false;
            }
            else
            {
                if (towers[location].PlaceBrick(selected))
                {
                    selected = null;
                    MovesMade++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool SetBoardSize(int size)
        {
            if (size < 1)
                return false;
            else
                boardSize = size;
            InitializeGame();
            return true;
        }

        public bool IsGameCompleted()
        {
            if (towers[0].IsEmpty() && towers[1].IsEmpty() && selected == null)
                return true;
            return false;
        }

        private void InitializeGame()
        {
            selected = null;
            MovesMade = 0;
            towers = new List<Tower>();
            towers.Add(new Tower(boardSize));
            towers.Add(new Tower());
            towers.Add(new Tower());
        }

        public override string ToString()
        {
            string s = "[";
            foreach (Tower t in towers)
                s += t.ToString() + ",";
            s = s.Trim(',');
            s += "]";
            return s;
        }
    }
}
