using System;
using System.Collections;
using System.Linq;

namespace GenericList
{
    public class DynamicList<T> : IDynamicList<T>, IEnumerable
    {
        private T[] list;

        public DynamicList()
        {
            list = new T[0];
        }

        public int Count
        {
            get
            {
                return list.Length;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > list.Length)
                    throw new IndexOutOfRangeException();

                return list[index];
            }
            set
            {
                if (index < 0 || index > list.Length)
                    throw new IndexOutOfRangeException();

                list[index] = value;
            }
        }

        public void Add(T item)
        {
            Array.Resize<T>(ref list, list.Length + 1);
            list[list.Length - 1] = item;
        }

        public bool Remove(T itemToRemove)
        {
            list = list.Where(val => !val.Equals(itemToRemove)).ToArray();
            return true;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > list.Length)
                throw new IndexOutOfRangeException();
        }

        public void Clear()
        {
            Array.Resize<T>(ref list, 0);
        }

        public IEnumerator GetEnumerator()
        {
            return this.list.GetEnumerator();
        }
    }
}
