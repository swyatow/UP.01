using System;

namespace NSD_Task_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string secretMessage = "Поздравляем! Вы открыли Секретное сообщение!";
            string password = "password";

            int countOfTries = 1;

            while (countOfTries <= 3)
            {
                Console.WriteLine("Введите параоль");
                if(Console.ReadLine() == password)
                {
                    Console.WriteLine(secretMessage);
                    break;
                }else
                {
                    Console.WriteLine($"Пароль не верный! Осталось {3 - countOfTries} попыток.\nПосле трех попыток, программа будет закрыта!");
                    countOfTries++;
                }
            }
        }
    }
}
