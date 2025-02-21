using System;
using System.Collections.Immutable;
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

            //Thread ProcessOfReading = new Thread(() => ReadingProcess(biblio));
            //ProcessOfReading.Start();

            SecondTask(biblio);

            Console.WriteLine();
            Console.WriteLine(new string('-', Console.WindowWidth));

            ThirdTask();
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

        public static async Task SecondTask(SecondTask_Biblio biblio)
        {
            Console.WriteLine();
            Console.WriteLine("Второе задание");
            Console.WriteLine();

            //SecondTask_Biblio biblio = new SecondTask_Biblio();
            Task.Run(() =>
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
            });



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

        public static void ThirdTask()
        {
            Console.WriteLine();
            Console.WriteLine("Третье задание");
            Console.WriteLine();

            ImmutableList<string> startList = [];

            List<string> text = new List<string>
            {

                "Вот дом,\r\nКоторый построил Джек.",
                "\nА это пшеница,\r\nКоторая в темном чулане хранится\r\nВ доме,\r\nКоторый построил Джек.",
                "\nА это веселая птица-синица,\r\nКоторая часто ворует пшеницу,\r\nКоторая в темном чулане хранится\r\nВ доме,\r\nКоторый построил Джек.",
                "\nВот кот,\r\nКоторый пугает и ловит синицу,\r\nКоторая часто ворует пшеницу,\r\nКоторая в темном чулане хранится\r\nВ доме,\r\nКоторый построил Джек.",
                "\nВот пес без хвоста,\r\nКоторый за шиворот треплет кота,\r\nКоторый пугает и ловит синицу,\r\nКоторая часто ворует пшеницу,\r\nКоторая в темном чулане хранится\r\nВ доме,\r\nКоторый построил Джек.",
                "\nА это корова безрогая,\r\nЛягнувшая старого пса без хвоста,\r\nКоторый за шиворот треплет кота,\r\nКоторый пугает и ловит синицу,\r\nКоторая часто ворует пшеницу,\r\nКоторая в темном чулане хранится\r\nВ доме,\r\nКоторый построил Джек.",
                "\nА это старушка, седая и строгая,\r\nКоторая доит корову безрогую,\r\nЛягнувшую старого пса без хвоста,\r\nКоторый за шиворот треплет кота,\r\nКоторый пугает и ловит синицу,\r\nКоторая часто ворует пшеницу,\r\nКоторая в темном чулане хранится\r\nВ доме,\r\nКоторый построил Джек.",
                "\nА это ленивый и толстый пастух,\r\nКоторый бранится с коровницей строгою,\r\nКоторая доит корову безрогую,\r\nЛягнувшую старого пса без хвоста,\r\nКоторый за шиворот треплет кота,\r\nКоторый пугает и ловит синицу,\r\nКоторая часто ворует пшеницу,\r\nКоторая в темном чулане хранится\r\nВ доме,\r\nКоторый построил Джек.",
                "\nВот два петуха,\r\nКоторые будят того пастуха,\r\nКоторый бранится с коровницей строгою,\r\nКоторая доит корову безрогую,\r\nЛягнувшую старого пса без хвоста,\r\nКоторый за шиворот треплет кота,\r\nКоторый пугает и ловит синицу,\r\nКоторая часто ворует пшеницу,\r\nКоторая в темном чулане хранится\r\nВ доме,\r\nКоторый построил Джек."
             };

            Part1 part1 = new Part1(text[0]);
            Part2 part2 = new Part2(text[1]);
            Part3 part3 = new Part3(text[2]);
            Part4 part4 = new Part4(text[3]);
            Part5 part5 = new Part5(text[4]);
            Part6 part6 = new Part6(text[5]);
            Part7 part7 = new Part7(text[6]);
            Part8 part8 = new Part8(text[7]);
            Part9 part9 = new Part9(text[8]);

            part1.AddPart(startList);
            part2.AddPart(part1.Poem);
            part3.AddPart(part2.Poem);
            part4.AddPart(part3.Poem);
            part5.AddPart(part4.Poem);
            part6.AddPart(part5.Poem);
            part7.AddPart(part6.Poem);
            part8.AddPart(part7.Poem);
            part9.AddPart(part8.Poem);

            Console.WriteLine($"Вывожу стартовый список: {Formatted(startList)}");
            Console.WriteLine(Formatted(part1.Poem));
            Console.WriteLine(Formatted(part2.Poem));
            Console.WriteLine(Formatted(part3.Poem));
            Console.WriteLine(Formatted(part4.Poem));
            Console.WriteLine(Formatted(part5.Poem));
            Console.WriteLine(Formatted(part6.Poem));
            Console.WriteLine(Formatted(part7.Poem));
            Console.WriteLine(Formatted(part8.Poem));
            Console.WriteLine(Formatted(part9.Poem));
            Console.WriteLine($"И вновь вывожу стартовый список: {Formatted(startList)}");
        }



        public static string Formatted(IEnumerable<string> a)
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.WriteLine();
            return $"[{string.Join(",", a)}]";
        }

        //public static void ReadingProcess(SecondTask_Biblio biblio)
        //{
        //    while (true)
        //    {
        //        foreach (var item in biblio.cd_List)
        //        {
        //            int newValue = item.Value + 1;
        //            biblio.cd_List.TryUpdate(item.Key, newValue, item.Value);

        //            if (item.Value >= 100)
        //            {
        //                int removeValue1;
        //                string removeKey = item.Key;
        //                if (biblio.cd_List.TryRemove(item.Key, out removeValue1))
        //                {
        //                    Console.WriteLine($"Удалена книга {removeKey}, т.к. она прочитана от корки до корки");
        //                    break;
        //                }
        //            }
        //        }
        //        Thread.Sleep(1000);

        //    }
        //}
    }
    }