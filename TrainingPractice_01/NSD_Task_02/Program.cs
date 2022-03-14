using System;

namespace NSD_Task_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text;
            while (true)
            {
                Console.Write("Введите exit, чтобы выйти: ");
                text = Console.ReadLine();
                if (text == "exit") break;
            }
        }
    }
}
