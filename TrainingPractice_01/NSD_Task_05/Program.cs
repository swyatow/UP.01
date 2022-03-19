using System;
using System.Collections.Generic;
using NSD_Task_05.MazeGame;

namespace NSD_Task_05
{
    internal class Program
    {
        public static int width;
        public static int height;
        public static bool exit = false;
        public static bool IsKeysMode = false;
        public static int KeysAll = 0;
        public static int TorchesCount = 0;
        public static bool IsFogOfWarMode = false;
        public static int FieldOfView = 3;
        public static bool IsEnemiesMode = false;
        public static int Health;
        public static int RemainingHealth;


        public delegate void FovOrNotMode(Maze maze, Cell user);
        public static FovOrNotMode SelectedMode;
        private static Dictionary<string, FovOrNotMode> modes = new Dictionary<string, FovOrNotMode>
            {
                {"д", WriteMazeFOW},
                {"н", WriteMaze},
            };


        static void Main(string[] args)
        {
            while (!exit)
            {
                Health = 3;
                RemainingHealth = Health;
                bool win = false;
                Cell user = new Cell(1, 1, true);
                Maze maze;

                StartMethod();

                #region настройка размеров лабиринта
                if (width % 2 == 0 && height % 2 != 0)
                {
                    width--;
                }
                else if (height % 2 == 0 && width % 2 != 0)
                {
                    height--;
                }
                else if (width % 2 == 0 && height % 2 == 0)
                {
                    width--;
                    height--;
                }
                maze = new Maze(width, height);
                #endregion

                Console.ForegroundColor = ConsoleColor.White;
                Console.CursorVisible = false;

                //генерация лабиринта и отображение его в первозданном виде
                maze.CreateMaze();
                if (KeysAll > 0)
                {
                    maze.SetKeys(KeysAll);
                }
                if (IsFogOfWarMode)
                {
                    maze.SetTorches(out TorchesCount);
                }
                if (IsEnemiesMode)
                {
                    maze.SetEnemies();
                }
                SelectedMode(maze,user);

                //game loop
                while (!win)
                {
                    //Передвижение врагов
                    maze.MoveEnemies();

                    ConsoleKeyInfo key;
                    key = Console.ReadKey();

                    Console.SetCursorPosition(0, 0);
                    //проверка какую клавишу нажали и передвижение героя
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            {
                                if (maze.Cells[user.X - 1, user.Y].IsCell)
                                {
                                    user.X -= 1;
                                }
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            {
                                if (maze.Cells[user.X + 1, user.Y].IsCell)
                                {

                                    user.X += 1;
                                }
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            {
                                if (maze.Cells[user.X, user.Y - 1].IsCell)
                                {
                                    user.Y -= 1;
                                }
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            {
                                if (maze.Cells[user.X, user.Y + 1].IsCell)
                                {
                                    user.Y += 1;
                                }
                            }
                            break;
                    }
                    SelectedMode(maze, user);

                    //Проверка попадания на клетку к врагу
                    if(maze.Cells[user.X, user.Y].IsEnemy)
                    {
                        RemainingHealth--;
                    }
                    //Проверка условия поражения
                    if (RemainingHealth <= 0)
                    {
                        LoseMethod();
                        break;
                    }
                    //Проверка условия победы
                    if (user.X == maze.Finish.X && user.Y == maze.Finish.Y)
                    {
                        if (IsKeysMode)
                        {
                            if (KeysAll == 0)
                            {
                                win = true;
                            }
                        }
                        else
                        {
                            win = true;
                        }
                    }
                }
                if(win) FinMethod();
            }
        }

        //Проверка введенных чисел
        private static void CheckInput(out int result, int minValue, string minValueExceptionText)
        {
            while (true)
            {
                try
                {
                    result = int.Parse(Console.ReadLine());
                    if (result < minValue)
                    {
                        Console.WriteLine(minValueExceptionText);
                    }
                    else break;
                }
                catch
                {
                    Console.WriteLine("Только число!");
                }
            }
        }

        //начало игры ввод значений для генерации лабиринта
        private static void StartMethod()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Добрo пожаловать в Лабиринт!");

            Console.WriteLine("Выберите ширину вашего лабиринта: ");
            CheckInput(out height, 10, "Слишком маленький лабиринт!");
            

            Console.WriteLine("Выберите высоту вашего лабиринта: ");
            CheckInput(out width, 10, "Слишком маленький лабиринт!");

            Console.WriteLine("Выбирите количество ключей, которые необходимо собрать, чтобы выйти из лабиринта\n(Если хотите играть без ключей, напишите 0):");
            CheckInput(out KeysAll, 0, "Не может быть отрицательное количество ключей!");
            if (KeysAll > 0)
            {
                IsKeysMode = true;
            }

            Console.Write("Включить режим \"Туман войны\"? (д/н) ");

            string UserAnswer = "";
            while (true)
            {
                try
                {
                    UserAnswer = Console.ReadLine();
                    SelectedMode = modes[UserAnswer];
                    break;
                }
                catch
                {
                    Console.WriteLine("Только символы 'д' и 'н'! Повторите ввод!");
                }
            }
            
            IsFogOfWarMode = UserAnswer == "д" ? true : false;

            Console.Write("Включить режим \"С врагами\"? (д/н) ");
            IsEnemiesMode = Console.ReadLine() == "д" ? true : false;

            Console.Clear();

        }

        //конец игры, игрок дошел до конца
        private static void FinMethod()
        {
            Console.Clear();
            Console.SetCursorPosition(30, 10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Поздравляю! Вы прошли лабиринт. Хотите повторить? (д/н)");
            Console.SetCursorPosition(60, 11);
            exit = Console.ReadLine() == "д" ? false : true;
            Console.Clear();
        }

        //Конец игры, игрок убит
        private static void LoseMethod()
        {
            Console.Clear();
            Console.SetCursorPosition(20, 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Сожалеем, но Вы проиграли. В следующий раз у Вас точно все получится! Хотите повторить? (д/н)");
            Console.SetCursorPosition(60, 11);
            exit = Console.ReadLine() == "д" ? false : true;
            Console.Clear();
        }

        //вывод обновленного лабиринта на экран
        private static void WriteMaze(Maze maze, Cell user)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (i == user.X && j == user.Y)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("U");
                    }
                    else if (maze.Cells[i, j].IsEnemy)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("E");
                    }
                    else if (i == maze.Finish.X && j == maze.Finish.Y)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("░");
                    }
                    else if (!maze.Cells[i, j].IsCell)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("█");
                    }
                    else if (maze.Cells[i, j].IsKey)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("K");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("\n");
            }

            //проверка дополнительной логики игры
            if (KeysAll > 0)
            {
                //Проверка что ключ собран
                if (maze.Cells[user.X, user.Y].IsKey)
                {
                    KeysAll--;
                    maze.Cells[user.X, user.Y].IsKey = false;
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(height + 3, 1);
            Console.Write($"Осталось жизней: [{WriteRemainingHealth()}]");

            Console.SetCursorPosition(height / 4, width + 2);
            Console.Write($"Осталось собрать {KeysAll} ключей и {TorchesCount} факелов");

        }

        //вывод обновленного лабиринта в режиме туман войны
        private static void WriteMazeFOW(Maze maze, Cell user)
        {
            int XLeft = user.X - FieldOfView;
            int YLeft = user.Y - FieldOfView;
            int XRight = user.X + FieldOfView;
            int YRight = user.Y + FieldOfView;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if ((i >= XLeft && i <= XRight) && (j >= YLeft && j <= YRight))
                    {
                        if (i == user.X && j == user.Y)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("U");
                        }
                        else if (maze.Cells[i, j].IsEnemy)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("E");
                        }
                        else if (i == maze.Finish.X && j == maze.Finish.Y)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("░");
                        }
                        else if (!maze.Cells[i, j].IsCell)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("█");
                        }
                        else if (maze.Cells[i, j].IsTorch)
                        {
                            Console.Write("T");
                        }
                        else if (maze.Cells[i, j].IsKey)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("K");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("▒");
                    }
                }
                Console.Write("\n");
            }

            //проверка дополнительной логики игры
            if (KeysAll > 0)
            {
                //Проверка что ключ собран
                if (maze.Cells[user.X, user.Y].IsKey)
                {
                    KeysAll--;
                    maze.Cells[user.X, user.Y].IsKey = false;
                }
            }
            if (maze.Cells[user.X, user.Y].IsTorch)
            {
                FieldOfView++;
                TorchesCount--;
                maze.Cells[user.X, user.Y].IsTorch = false;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(height + 3, 1);
            Console.Write($"Осталось жизней: [{WriteRemainingHealth()}]");

            Console.SetCursorPosition(height / 4, width + 2);
            Console.Write($"Осталось собрать {KeysAll} ключей и {TorchesCount} факелов");
        }

        private static string WriteRemainingHealth()
        {
            var tempRemainingHealth = RemainingHealth;
            string healthBar = "";
            for(int i = 0; i < tempRemainingHealth; i++)
            {
                healthBar += "█";
            }
            for (int i = RemainingHealth; i < Health; i++)
            {
                healthBar += "_";
            }

            return healthBar;
        }
    }
}
