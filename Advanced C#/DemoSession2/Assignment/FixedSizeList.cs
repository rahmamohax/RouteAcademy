using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class FixedSizeList<T>
    {
        T[] items;
        public int Capacity { get; set; }
        public int Count { get; set; }
        public FixedSizeList(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be greater than zero.");
            items = new T[capacity];
            Capacity = capacity;
            Count = 0;
        }

        public void Add(T item) {
            if (Count > Capacity) throw new ArgumentOutOfRangeException("Unable to add new Item, you have reached your max capacity");
            else
            {
                items[Count] = item;
                Count++;
            }
        }

        //Implement a Get method that retrieves an element at a specific index in the list but throws an exception for invalid indices.

        public T Get(int index) {
            if ((index < 0) || (index >= Count)) throw new ArgumentOutOfRangeException("Invalid Index");
            return items[index];
        }
    }
}
