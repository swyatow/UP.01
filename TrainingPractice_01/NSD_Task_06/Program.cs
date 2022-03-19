using System;
using System.Text.RegularExpressions;

namespace NSD_Task_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] FIOs =
            {
                "Новоселов Святослав Дмитриевич",
                "Иванов Петр Петрович",
                "Иванов Иван Иванович",
            };
            string[] Post = 
            {
                "Программист",
                "PR-менеджер",
                "Директор",
            };

            bool exit = false;

            while (!exit)
            {
                Console.Clear();   
                Console.WriteLine("Выберите действие:\n" +
                    "\t- Добавить - Добавляет новое досье\n" +
                    "\t- Список - Выводит все досье\n" +
                    "\t- Удалить - Удаляет указанное досье\n" +
                    "\t- Поиск - Проводит поиск среди досье по фамилии\n" +
                    "\t- Выход - Завершение программы\n");
                bool repeat = true;
                while (repeat)
                {
                    switch (Console.ReadLine().ToLower())
                    {
                        case ("добавить"): { repeat = false; AddDossier(ref FIOs, ref Post); } break;
                        case ("список"): 
                            { 
                                repeat = false; 
                                Console.Clear(); 
                                ShowDossiers(ref FIOs,ref Post);
                                Console.WriteLine("Нажмите любую клавишу, чтобы перейти в меню!");
                                Console.ReadKey();
                            } break;
                        case ("удалить"): 
                            { 
                                repeat = false;
                                Console.Clear();
                                DeleteDossiers(ref FIOs, ref Post); 
                            } 
                            break;
                        case ("поиск"): 
                            { 
                                repeat = false;
                                Console.Clear();
                                Console.WriteLine("Поиск досье по фамилии.");
                                Console.WriteLine("Введите фамилию сотрудника, которого необходимо найти:");
                                string lastName = Console.ReadLine();
                                FindDossiers(ref FIOs, ref Post, lastName, out string[] finded_fios, out string[] finded_posts);
                                Console.WriteLine("Найденные сотрудники:\n");
                                ShowDossiers(ref finded_fios, ref finded_posts);
                                Console.WriteLine("Нажмите любую клавишу, чтобы перейти в меню!");
                                Console.ReadKey();
                            } 
                            break;
                        case ("выход"): { repeat = false; exit = true; } break;
                        default:
                            {
                                Console.WriteLine("Комманда не распознана. Повторите ввод!");
                            }
                            break;
                    }
                }
            }
        }

        private static void AddDossier(ref string[] fIOs,ref string[] post)
        {
            Console.Clear();
            Console.WriteLine("Добавление нового досье.");
            Console.WriteLine("Введите фамилию, имя и отчество нового сотрудника:");
            string fullName = Console.ReadLine();

            Console.WriteLine("Введите должность нового сотрудника:");
            string newPost = Console.ReadLine();

            Array.Resize(ref fIOs, fIOs.Length + 1);
            fIOs[fIOs.Length-1] = fullName;

            Array.Resize(ref post, post.Length + 1);
            post[post.Length - 1] = newPost;

            Console.WriteLine("Сотрудник добавлен!\nНажмите любую клавишу, чтобы перейти в меню!");
            Console.ReadKey();
        }

        private static void ShowDossiers(ref string[] fIOs, ref string[] post)
        {
            if(fIOs.Length > 0)
            {
                Console.WriteLine("Список досье:\n");
                for (int i = 0; i < fIOs.Length; i++)
                {
                    Console.WriteLine($"{i+1}) {fIOs[i]} - {post[i]}");
                }
            }
            else
            {
                Console.WriteLine("Список пуст!");

            }
        }

        private static void DeleteDossiers(ref string[] fIOs, ref string[] posts)
        {
            Console.WriteLine("Удаление сотрудника\nВведите фамилию сотрудника:");
            string lastName = Console.ReadLine();
            FindDossiers(ref fIOs,ref posts,lastName, out string[] finded_fios, out string[] finded_posts);
            if (finded_fios.Length > 1)
            {
                ShowDossiers(ref finded_fios, ref finded_posts);
                Console.WriteLine("Введите порядковый номер сотрудника, которого вы хотите удалить: ");
                int deletedIndex = 0;
                while (true)
                {
                    try
                    {
                        deletedIndex = int.Parse(Console.ReadLine()) - 1;
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Только число!");
                    }
                }
                int temp = Array.IndexOf(fIOs, finded_fios[deletedIndex]);
                string[] newFIOs = new string[fIOs.Length - 1];
                string[] newPosts = new string[posts.Length - 1];

                for (int i = 0; i < fIOs.Length; i++)
                {
                    if (i < temp)
                    {
                        newFIOs[i] = fIOs[i];
                        newPosts[i] = posts[i];
                    }
                    else if (i > temp)
                    {
                        newFIOs[i - 1] = fIOs[i];
                        newPosts[i - 1] = posts[i];
                    }
                }
                fIOs = newFIOs;
                posts = newPosts;

                Console.WriteLine($"Сотрудник {finded_fios[deletedIndex]} был удален!");
            }
            else if(finded_fios.Length == 1)
            {
                int temp = Array.IndexOf(fIOs, finded_fios[0]);

                string[] newFIOs = new string[fIOs.Length - 1];
                string[] newPosts = new string[posts.Length - 1];

                for (int i = 0; i < fIOs.Length; i++)
                {
                    if (i < temp)
                    {
                        newFIOs[i] = fIOs[i];
                        newPosts[i] = posts[i];
                    }
                    else if (i > temp)
                    {
                        newFIOs[i - 1] = fIOs[i];
                        newPosts[i - 1] = posts[i];
                    }
                }
                fIOs = newFIOs;
                posts = newPosts;

                Console.WriteLine($"Сотрудник {finded_fios[0]} был удален!");
            }
            else
            {
                Console.WriteLine("Сотрудников с такой фамилией не найдено!");
            }

            Console.WriteLine("\nНажмите любую клавишу, чтобы перейти в меню!");
            Console.ReadKey();
        }

        private static void FindDossiers(ref string[] fIOs, ref string[] posts, string lastName, out string[] finded_fios, out string[] finded_posts)
        {
            finded_fios = new string[] {};
            finded_posts = new string[] {};
            for (int i = 0; i < fIOs.Length; i++)
            {
                string[] splitedFio = fIOs[i].Split(" ");
                if (splitedFio[0] == lastName)
                {
                    Array.Resize(ref finded_fios, finded_fios.Length + 1);
                    finded_fios[finded_fios.Length - 1] = fIOs[i];

                    Array.Resize(ref finded_posts, finded_posts.Length + 1);
                    finded_posts[finded_posts.Length - 1] = posts[i];
                }
            }
        }
    }
}
