using System;

namespace NSD_Task_01
{
    internal class Program
    {
        public static int user_gold;
        public static int crystals_count;
        public static int crystal_cost = 15;
        public static int crystals_player_can_buy = 0;

        public delegate void Delegate();

        static void Main(string[] args)
        {
            Delegate del;
            StartDialog();
            
            del = (crystals_count * crystal_cost) <= user_gold ? PurchuaseSuccess : PurchuaseFailed;

            del();
        }

        private static void StartDialog()
        {
            Console.WriteLine("Добро пожаловать в Магазин \"У Гнома\". Для начала, скажите, сколько у Вас имеется золота?");
            user_gold = int.Parse(Console.ReadLine());
            Console.WriteLine("Отлично! Я могу предложить Вам наш лучший товар - кристаллы! " +
                $"Стоймость каждого - всего {crystal_cost} золота." +
                "\nИтак, сколько кристалов Вы бы хотели приобрести?");
            crystals_count = int.Parse(Console.ReadLine());
        }

        private static void PurchuaseSuccess()
        {
            Console.WriteLine($"Поздравляем с приобретением {crystals_count} кристалов!" +
                $"\nУ Вас осталось {user_gold - crystals_count * crystal_cost} золота.");
        }

        private static void PurchuaseFailed()
        {
            Console.WriteLine($"Сожалеем, но у Вас не хватает {crystals_count * crystal_cost - user_gold} золота на приобретение {crystals_count} кристалов!" +
                $"\nВаше золото {user_gold}.");
        }
    }
}
