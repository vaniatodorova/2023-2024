using System;
using System.Collections.Generic;

namespace HashTable
{
    public class HashTable<TKey, TValue>
    {
        private const int Capacity = 1000;
        private LinkedList<KeyValuePair<TKey, TValue>>[] items;

        public HashTable()
        {
            items = new LinkedList<KeyValuePair<TKey, TValue>>[Capacity];
        }

        public void Add(TKey key, TValue value)
        {
            int hash = GetHash(key);
            if (items[hash] == null)
                items[hash] = new LinkedList<KeyValuePair<TKey, TValue>>();

            items[hash].AddLast(new KeyValuePair<TKey, TValue>(key, value));
        }

        public TValue Get(TKey key)
        {
            int hash = GetHash(key);
            if (items[hash] != null)
            {
                foreach (var pair in items[hash])
                {
                    if (pair.Key.Equals(key))
                        return pair.Value;
                }
            }
            throw new KeyNotFoundException();
        }

        private int GetHash(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % Capacity;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of HashTable
            HashTable<string, int> hashTable = new HashTable<string, int>();

            // Add some key-value pairs
            hashTable.Add("one", 1);
            hashTable.Add("two", 2);
            hashTable.Add("three", 3);

            // Retrieve values using Get method
            Console.WriteLine("Value for key 'one': " + hashTable.Get("one"));
            Console.WriteLine("Value for key 'two': " + hashTable.Get("two"));
            Console.WriteLine("Value for key 'three': " + hashTable.Get("three"));

            // Trying to retrieve a value for a non-existing key
            try
            {
                Console.WriteLine("Value for key 'four': " + hashTable.Get("four"));
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Key 'four' not found.");
            }
        }
    }
}
