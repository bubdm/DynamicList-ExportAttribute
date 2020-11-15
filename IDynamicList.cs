using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    public interface IDynamicList<T>
    {
        int Count { get;}
        T this[int index]{ get; set; }

        void Add(T item);
        bool Remove(T item);
        void RemoveAt(int index);
        void Clear();
    }
}
