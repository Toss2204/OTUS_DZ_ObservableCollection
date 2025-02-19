using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTUS_DZ_ObservableCollection
{
    public class SecondTask_Biblio
    {
        public ConcurrentDictionary<string, int> cd_List = new();
        public bool Add(string bookName) 
        {

            return cd_List.TryAdd(bookName, 0);
            
        }

        public void ShowList() 
        {
            foreach (var item in cd_List)
            {
                Console.WriteLine($"{item.Key} - {item.Value}%");
            }
        }

        //public void ReadingProcess()
        //{
        //    foreach (var item in cd_List)
        //    {
        //        int newValue = item.Value + 1;
        //        cd_List.TryUpdate(item.Key, newValue, item.Value);

        //        if (item.Value >= 100)
        //        {
        //            int removeValue1;
        //            string removeKey = item.Key;
        //            if (cd_List.TryRemove(item.Key, out removeValue1))
        //            {
        //                Console.WriteLine($"Удалена книга {removeKey}, т.к. она прочитана от корки до корки");
        //                break;
        //            }
        //        }
        //    }
        //    Thread.Sleep(1000);


        //}
    }
}
