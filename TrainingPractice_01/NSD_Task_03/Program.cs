using System;

namespace NSD_Task_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string secret_message = "Поздравляем! Вы открыли Секретное сообщение!";
            string password = "password";

            int count_of_tries = 1;

            while (count_of_tries <= 3)
            {
                Console.WriteLine("Введите параоль");
                if(Console.ReadLine() == password)
                {
                    Console.WriteLine(secret_message);
                    break;
                }else
                {
                    Console.WriteLine($"Пароль не верный! Осталось {3 - count_of_tries} попыток.\nПосле трех попыток, программа будет закрыта1");
                    count_of_tries++;
                }
            }
        }
    }
}
