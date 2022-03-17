using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSD_Task_05.MazeGame
{
    public struct Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsCell { get; set; }
        public bool IsVisited { get; set; }
        public bool IsKey { get; set; }
        public bool IsTorch { get; set; }
        public bool IsEnemy { get; set; }

        public Cell(int x, int y, bool isVisited = false, bool isCell = true, bool isKey = false, bool isTorch = false, bool isEnemy = false)
        {
            X = x;
            Y = y;
            IsCell = isCell;
            IsVisited = isVisited;
            IsKey = isKey;
            IsTorch = isTorch;
            IsEnemy = isEnemy;
        }
    }
}
