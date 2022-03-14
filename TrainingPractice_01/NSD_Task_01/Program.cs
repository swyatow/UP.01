using System;

namespace NSD_Task_01
{
    internal class Program
    {
        public static int UserGold;
        public static int CrystalsCount;
        public static int CrystalCost = 15;
        public static int CrystalsPlayerCanBuy = 0;


        static void Main(string[] args)
        {
            StartDialog();

            while (CrystalsCount * CrystalCost <= UserGold)
            {
                PurchuaseSuccess();
                break;
            }
            while (CrystalsCount * CrystalCost > UserGold)
            {
                PurchuaseFailed();
                break;
            }
        }

        private static void StartDialog()
        {
            Console.WriteLine("Добро пожаловать в Магазин \"У Гнома\". Для начала, скажите, сколько у Вас имеется золота?");
            while (true)
            {
                try
                {
                    UserGold = int.Parse(Console.ReadLine());
                    break;
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
                    break;
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
