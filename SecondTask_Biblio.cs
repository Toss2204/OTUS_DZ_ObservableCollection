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

        
    }
}
