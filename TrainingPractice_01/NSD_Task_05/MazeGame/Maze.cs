using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSD_Task_05.MazeGame
{
    internal class Maze
    {
        public readonly Cell[,] Cells;
        private int Width;
        private int Height;
        public Stack<Cell> Path = new Stack<Cell>();
        public List<Cell> Neighbours = new List<Cell>();
        public Random rnd = new Random();
        public Cell Start;
        public Cell Finish;
        public Maze(int width, int height)
        {
            Start = new Cell(1, 1, true, true);
            Finish = new Cell(width - 2, height - 2, true, true);
            Width = width;
            Height = height;
            Cells = new Cell[width, height];
            for (var i = 0; i < width; i++)
                for (var j = 0; j < height; j++)
                    //если ячейка нечетная по i и по j и не выходит за пределы лабиринта
                    if ((i % 2 != 0 && j % 2 != 0) && (i < Width - 1 && j < Height - 1))
                    {
                        Cells[i, j] = new Cell(i, j); //то это клетка (по умолчанию)
                    }
                    else
                    {
                        Cells[i, j] = new Cell(i, j, false, false); //иначе это стенка
                    }
            Path.Push(Start);
            Cells[Start.X, Start.Y] = Start;
        }
        public void CreateMaze()
        {
            Cells[Start.X, Start.Y] = Start;
            while (Path.Count != 0)
            {
                Neighbours.Clear();
                GetNeighbours(Path.Peek());
                if (Neighbours.Count != 0)
                {
                    Cell nextCell = ChooseNeighbour(Neighbours);
                    RemoveWall(Path.Peek(), nextCell);
                    nextCell.IsVisited = true; //делаем текущую клетку посещенной
                    Cells[nextCell.X, nextCell.Y].IsVisited = true; //и в общем массиве
                    Path.Push(nextCell); //затем добавляем её в стек
                }
                else
                {
                    Path.Pop();
                }
            }
        }

        private void GetNeighbours(Cell localcell) //получаем соседа текущей клетки
        {
            int x = localcell.X;
            int y = localcell.Y;
            int distance = 2;
            Cell[] possibleNeighbours = new[] //список всех возможных соседeй
            {
                new Cell(x, y - distance),
                new Cell(x + distance, y),
                new Cell(x, y + distance),
                new Cell(x - distance, y)
            };
            for (int i = 0; i < 4; i++) //проверяем все 4 направления
            {
                Cell curNeighbour = possibleNeighbours[i];
                //если сосед не выходит за стенки лабиринта, а также он клетка и не посещен
                if ((curNeighbour.X > 0 && curNeighbour.X < Width && curNeighbour.Y > 0 && curNeighbour.Y < Height)
                    && (Cells[curNeighbour.X, curNeighbour.Y].IsCell && !Cells[curNeighbour.X, curNeighbour.Y].IsVisited))
                {
                    Neighbours.Add(curNeighbour);
                }
            }
        }

        private Cell ChooseNeighbour(List<Cell> neighbours) //выбор случайного соседа
        {
            int rand_index = rnd.Next(neighbours.Count);
            return neighbours[rand_index];
        }

        private void RemoveWall(Cell first, Cell second)
        {
            int xDiff = second.X - first.X;
            int yDiff = second.Y - first.Y;
            int addX = (xDiff != 0) ? xDiff / Math.Abs(xDiff) : 0; // Узнаем направление удаления стены
            int addY = (yDiff != 0) ? yDiff / Math.Abs(yDiff) : 0;
            // Координаты удаленной стены
            Cells[first.X + addX, first.Y + addY].IsCell = true; //обращаем стену в клетку
            Cells[first.X + addX, first.Y + addY].IsVisited = true; //и делаем ее посещенной
            second.IsVisited = true; //делаем клетку посещенной
            Cells[second.X, second.Y] = second;
        }

        //Случайное расположение ключей в клетках (усли они есть)
        public void SetKeys(int keys_count)
        {
            while (keys_count > 0)
            {
                int i = rnd.Next(0, Width);
                int j = rnd.Next(0, Height);
                if (Cells[i, j].IsCell)
                {
                    Cells[i, j].IsKey = true;
                    keys_count--;
                }
            }
        }

        //Рассчет количества и расстановка факелов по лабиринту
        public void SetTorches(out int torches_count)
        {
            rnd = new Random();
            torches_count = rnd.Next(1, 4);
            if (Width > 30 || Height > 30)
            {
                torches_count = rnd.Next(2, 7);
            }
            else if (Width > 50 || Height > 50)
            {
                torches_count = rnd.Next(3, 9);
            }
            var temp = torches_count;
            while (temp > 0)
            {
                int i = rnd.Next(0, Width);
                int j = rnd.Next(0, Height);
                if (Cells[i, j].IsCell && !Cells[i, j].IsKey)
                {
                    Cells[i, j].IsTorch = true;
                    temp--;
                }
            }
        }

        //Рассчет количества и расстановка врагов по лабиринту
        public void SetEnemies()
        {
            rnd = new Random();
            int enemies_count = rnd.Next(4);
            while (enemies_count > 0)
            {
                int i = rnd.Next(0, Width);
                int j = rnd.Next(0, Height);
                if (Cells[i, j].IsCell && !Cells[i, j].IsKey)
                {
                    Cells[i, j].IsEnemy = true;
                    enemies_count--;
                }
            }
        }

        //Передвижение врагов в случайном направлении
        public void MoveEnemies()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (Cells[i, j].IsEnemy)
                    {
                        bool IsMoved = false;
                        rnd = new Random();
                        while (!IsMoved)
                        {
                            //directions = { "up", "right", "down", "left" };
                            int direction = rnd.Next(4);

                            switch (direction)
                            {
                                case 1:
                                    {
                                        if (Cells[i - 1, j].IsCell)
                                        {
                                            Cells[i, j].IsEnemy = false;
                                            Cells[i - 1, j].IsEnemy = true;
                                            IsMoved = true;
                                        }
                                    }
                                    break;
                                case 2:
                                    {
                                        if (Cells[i, j + 1].IsCell)
                                        {
                                            Cells[i, j].IsEnemy = false;
                                            Cells[i, j + 1].IsEnemy = true;
                                            IsMoved = true;
                                        }
                                    }
                                    break;
                                case 3:
                                    {
                                        if (Cells[i + 1, j].IsCell)
                                        {
                                            Cells[i, j].IsEnemy = false;
                                            Cells[i + 1, j].IsEnemy = true;
                                            IsMoved = true;
                                        }
                                    }
                                    break;
                                case 4:
                                    {
                                        if (Cells[i, j - 1].IsCell)
                                        {
                                            Cells[i, j].IsEnemy = false;
                                            Cells[i, j - 1].IsEnemy = true;
                                            IsMoved = true;
                                        }
                                    }
                                    break;
                            }
                        
                        }
                    }
                }
            }
        }
    }
}