using System;
using System.Globalization;

namespace OTUS_DZ_ObservableCollection
{
    internal class Program
    {
        
        public static void Main()
        {

            FirstTask();
            Console.WriteLine();
            Console.WriteLine(new string('-', Console.WindowWidth));


            SecondTask_Biblio biblio = new SecondTask_Biblio();

            Thread ProcessOfReading = new Thread(() => ReadingProcess(biblio));
            ProcessOfReading.Start();
            
            SecondTask(biblio);
            //SecondTask();
            Console.WriteLine();
            Console.WriteLine(new string('-', Console.WindowWidth));

        }

        public static void FirstTask()
        {
            Console.WriteLine("Первое задание");
            Console.WriteLine();

            FirstTask_Customer customer = new FirstTask_Customer();
            customer.CustomerID = "Покупатель 1";
            FirstTask_Shop shop = new FirstTask_Shop(customer);

            while (true)
            {

                StartMessage();
                string word = Console.ReadLine();



                if (string.IsNullOrEmpty(word))
                {
                    Console.WriteLine(" Не шути со мной!");
                    continue;
                }
                else
                {
                    if (word.ToLower() == "x")
                    {
                        break;
                    }

                    if (word.ToLower() == "a")
                    {
                        shop.Add();

                    }
                    if (word.ToLower() == "d")
                    {
                        Console.WriteLine("     Введите число ID для удаления товара");

                        string wordDel = Console.ReadLine();

                        bool result = int.TryParse(wordDel, out var number);
                        if (result)
                        {
                            shop.Remove(number);
                        }
                        else
                        {
                            Console.WriteLine("Введите число!");
                        }

                    }




                }


            }
            //while (/*Console.ReadKey().Key != ConsoleKey.X*/);
        }
        public static void StartMessage()
        {
            Console.WriteLine(" Введите A для добавления нового товара");
            Console.WriteLine(" Введите D для удаления товара");
            Console.WriteLine(" Чтобы выйти нажмите X");
        }

        public static void SecondTask(SecondTask_Biblio biblio)
        {
            Console.WriteLine("Второе задание");
            Console.WriteLine();

            //SecondTask_Biblio biblio = new SecondTask_Biblio();




            while (true)
            {

                StartMessage2();
                string word = Console.ReadLine();

                //Thread ProcessOfReading = new Thread(biblio.ReadingProcess);
                //ProcessOfReading.Start();


                if (string.IsNullOrEmpty(word))
                {
                    Console.WriteLine(" Не шути со мной!");
                    continue;
                }
                else
                {
                    if (word.ToLower() == "3")
                    {
                        break;
                    }

                    if (word.ToLower() == "1")
                    {
                        Console.WriteLine("     Введите название книги");

                        string wordName = Console.ReadLine();

                        if (string.IsNullOrEmpty(wordName))
                        {
                            Console.WriteLine(" Не шути со мной! Вводи название.");
                            continue;
                        }

                        if (biblio.Add(wordName))
                        {
                            Console.WriteLine("  Книга добавлена!");
                        }
                        else
                        {
                            Console.WriteLine("  Книга НЕ добавлена! ДУБЛЬ!");
                        }

                    }
                    if (word.ToLower() == "2")
                    {
                        biblio.ShowList();

                    }

                }


            }

        }

        public static void StartMessage2()
        {

            Console.WriteLine(" Введите 1 - добавить книгу");
            Console.WriteLine(" Введите 2 - вывести список непрочитанного");
            Console.WriteLine(" Введите 3 - выйти");
        }

        public static void ReadingProcess(SecondTask_Biblio biblio)
        {
            while (true)
            {
                foreach (var item in biblio.cd_List)
                {
                    int newValue = item.Value + 1;
                    biblio.cd_List.TryUpdate(item.Key, newValue, item.Value);

                    if (item.Value >= 100)
                    {
                        int removeValue1;
                        string removeKey = item.Key;
                        if (biblio.cd_List.TryRemove(item.Key, out removeValue1))
                        {
                            Console.WriteLine($"Удалена книга {removeKey}, т.к. она прочитана от корки до корки");
                            break;
                        }
                    }
                }
                Thread.Sleep(1000);

            }
        }
    }
}