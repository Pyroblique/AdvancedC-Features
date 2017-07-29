using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generics
{
    [System.Serializable]
    public class CustomList<T>
    {
        public T[] list;
        public T[] list1;
        public T[] list2;
        public int capacity { get; }
        public int amount { get; private set; }
        public CustomList(int capacity)
        {
            list = new T[capacity + 1];
        }
        public T this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }

        // Adds item to the end of CustomList<T>
        public void Add(T item)
        {
            // Create a new array of capacity +1
            T[] cache = new T[amount + 1];
            // Copy all existing items to new array
            // If list has been initialized
            if (list != null)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    cache[i] = list[i];
                }
            }
            // Place new item at end index
            cache[amount] = item;
            // Replace old array with new array
            list = cache;
            // Increment amount
            amount++;
        }

        // Add all elements from another collection
        public void AddRange(T item)
        {
            // Create a new list
            list1 = new T[capacity + 1];
            // Add to new list
            if (list1 != null)
            {
                for (int i = 0; i < list2.Length; i++)
                {
                    list1[i] = list2[i];
                }
            }
        }

        // Check if conditions are true
        static bool isPositiveInt(int i)
        {
            return i > 0;
        }

        static void Main(string[] args)
        {
            List<int> intList = new List<int>() { 10, 20, 30, 40 };

            bool res = intList.TrueForAll(isPositiveInt);

        }
    }
}

