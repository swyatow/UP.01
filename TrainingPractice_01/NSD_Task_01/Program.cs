using System;
using System.Collections.Generic;

namespace NSD_Task_01
{
    internal class Program
    {
        public static Random rnd = new Random();

        public static int UserGold = 1;
        public static int CrystalsCount;
        public static int CrystalCost = rnd.Next(15, 150);
        public static int CrystalsPlayerCanBuy = 0;

        public delegate void CheckPurchuase();
        private static Dictionary<bool, CheckPurchuase> checks = new Dictionary<bool, CheckPurchuase>
            {
                {true, PurchuaseSuccess},
                {false, PurchuaseFailed},
            };

        static void Main(string[] args)
        {
            StartDialog();

            CheckPurchuase check;
            bool checkPurchuase = CrystalsCount * CrystalCost <= UserGold;
            check = checks[checkPurchuase];

            check();

            Console.ReadKey();
        }

        private static void StartDialog()
        {
            Console.WriteLine("Добро пожаловать в Магазин \"У Гнома\". " +
                "Для начала, скажите, сколько у Вас имеется золота?");
            while (true)
            {
                try
                {
                    UserGold = int.Parse(Console.ReadLine());
                    if (UserGold < 0)
                    {
                        Console.WriteLine("У Вас не может быть отрицательного количества золота!");
                    }
                    else break;

                }
                catch
                {
                    Console.WriteLine("Что-то я вас не пойму, попробуйте еще раз...");
                }
                
            }
            Console.WriteLine("Отлично! Я могу предложить Вам наш лучший товар - кристаллы! " +
                $"Стоймость каждого - всего {CrystalCost} золота." +
                "\nИтак, сколько кристалов Вы бы хотели приобрести?");
            while (true)
            {
                try
                {
                    CrystalsCount = int.Parse(Console.ReadLine());
                    if (CrystalsCount < 0)
                    {
                        Console.WriteLine("Вы не можете купить отрицательное количество золота!");
                    }
                    else break;
                }
                catch
                {
                    Console.WriteLine("Что-то я вас не пойму, попробуйте еще раз...");
                }
            }
        }

        private static void PurchuaseSuccess()
        {
            Console.WriteLine($"Поздравляем с приобретением {CrystalsCount} кристалов!" +
                $"\nУ Вас осталось {UserGold - CrystalsCount * CrystalCost} золота.");
        }

        private static void PurchuaseFailed()
        {
            Console.WriteLine($"Сожалеем, но Вам не хватает {CrystalsCount * CrystalCost - UserGold} золота для приобретения {CrystalsCount} кристалов!" +
                $"\nВаше золото {UserGold}.");
        }
    }
}
