using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTUS_DZ_ObservableCollection
{
    public class FirstTask_Customer
    {
        public string CustomerID { get; set; }

        public void OnItemChanged(object? sender,
            NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine($"ADDED: new items ");//= {Formatted(e.NewItems)}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine($"REMOVE: deleted items ");//= {Formatted(e.OldItems)}");

                    break;
                //case NotifyCollectionChangedAction.Replace:
                //    Console.WriteLine($"REPLACE: from = {Formatted(e.OldItems)}, to from = {Formatted(e.NewItems)}");

                //    break;
                //case NotifyCollectionChangedAction.Reset:
                //    Console.WriteLine("CLEAR");
                //    break;
            }

        }

        private static string Formatted(IList? values)
        {
            if (values == null)
            {
                return "[]";
            }
            //var a = new object[values.Count];
            //values.CopyTo(a, 0);
            //return $"[{string.Join(",", a)}]";


            StringBuilder builder = new StringBuilder();
            //foreach (var val in values as List<FirstTask_Item>)
            //{
        
            //    builder.Append(val._Name).Append("|");
            //}

            return builder.ToString();
            

        }
    }
}
