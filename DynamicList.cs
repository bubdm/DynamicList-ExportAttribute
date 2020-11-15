using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericList
{
    [ExportClass]
    public class DynamicList<T> : IDynamicList<T>, IEnumerable
    {
        private T[] list;

        public DynamicList()
        {
            list = new T[0];
        }

        public DynamicList(IEnumerable<T> collection)
        {
            list = new T[0];
            foreach(var item in collection)
            {
                this.Add(item);
            }
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
                if (index < 0 || index >= list.Length)
                    throw new IndexOutOfRangeException();

                return list[index];
            }
            set
            {
                if (index < 0 || index >= list.Length)
                    throw new IndexOutOfRangeException();

                list[index] = value;
            }
        }

        public void Add(T item)
        {
            Array.Resize<T>(ref list, list.Length + 1);
            list[list.Length - 1] = item;
        }

        public void Remove(T itemToRemove)
        {
            list = list.Where(item => !item.Equals(itemToRemove)).ToArray();
        }

        public void RemoveAt(int itemIndex)
        {
            if (itemIndex < 0 || itemIndex >= list.Length)
                throw new IndexOutOfRangeException();

            list = list.Where((item, index) => index != itemIndex).ToArray();
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
