using System;

namespace OTUS_DZ_ObservableCollection
{
    internal class Program
    {
        static void Main()
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
    }
}
