using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTUS_DZ_ObservableCollection
{
    internal class Part3
    {
        public ImmutableList<string> Poem { get; set; }

        private readonly string Text;
        public Part3(string text) { Text = text; }
        public void AddPart(IList<string> col)
        {
            var l1 = (ImmutableList<string>)col;

            var newList = l1.Add(Text);

            Poem = newList;
        }
    }
}
