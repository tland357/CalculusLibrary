using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculusCS
{
    public class SimpleTree<T>
    {
        public List<SimpleTree<T>> Children;
        public T Item;
        public void Traverse(Action<T> callback)
        {
            callback(Item);
            foreach (var Child in Children)
            {
                Child.Traverse(callback);
            }
        }
    }
}
