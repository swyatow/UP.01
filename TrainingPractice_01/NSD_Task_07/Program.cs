using System;

namespace NSD_Task_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] oldArray = new int[10];
            int[] newArray;

            Console.WriteLine("Старый массив:");
            for (int i = 0; i < oldArray.Length; i++)
            {
                oldArray[i] = random.Next(0,1000);
                Console.Write(oldArray[i] + " ");
            }
            Console.WriteLine("\nНовый массив:");
            newArray = Shuffle(oldArray, random);
            for (int i = 0; i < newArray.Length; i++)
            {
                Console.Write(newArray[i] + " ");
            }
            Console.ReadKey();
        }

        public static int[] Shuffle(int[] oldArray, Random rnd)
        {
            for (int i = oldArray.Length - 1; i >= 1; i--)
            {
                int j = rnd.Next(i + 1);
                int temp = oldArray[j];
                oldArray[j] = oldArray[i];
                oldArray[i] = temp;
            }

            return oldArray;
        }
    }
}
