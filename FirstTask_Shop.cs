using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTUS_DZ_ObservableCollection
{
    public class FirstTask_Shop
    {

        ObservableCollection<FirstTask_Item> col = new ObservableCollection<FirstTask_Item>();
        private int ID_counter;
        public FirstTask_Shop(FirstTask_Customer customer) 
        { 
            col.CollectionChanged+= customer.OnItemChanged;
            Console.WriteLine($"Новый пользователь \"{customer.CustomerID}\" подписан!");


        }

        public void Add()
        { 
            FirstTask_Item item = new FirstTask_Item();
            item._Id = ID_counter++;
            item._Name = $"Товар {DateTime.Now.ToString("MMMM d, yyyy, hh:mm:ss")}";
            col.Add(item);
            Console.WriteLine($"{item._Name} добавлен. Всего товаров: {col.Count}");


        }

        public void Remove(int id)
        {
            //var newcol=col.Select(x => x._Id == id);
            bool findItem= false;
            foreach(var item in col) 
            {
                    if (item._Id == id)
                    {
                        string itemName=item._Name;
                        col.Remove(item);
                        Console.WriteLine($"{itemName} удален. Всего товаров: {col.Count}");
                        findItem=true;
                        break;
                    }
            }
            if (!findItem)
            {
                Console.WriteLine($"Товар {id} не найден. Всего товаров: {col.Count}");
            }

            if (col.Count == 0)
            { ID_counter = 0; }
            //


        }

    }
}
