using System;

namespace ConsoleApp2
{
    internal class Program
    {
        class CustomCollection<T>
        {
            T[] items;
            int count;

            public CustomCollection(int length)
            {
                items = new T[length];
                count = 0;
            }

            public void addItem(T item)
            {
                if (count == items.Length)
                {
                    Array.Resize(ref items, items.Length + 1);
                }

                items[count] = item;
                count++;
            }
            public T getItemById(int index)
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException("Неправильний індес");
                }
                return items[index];
            }
            public void removeItemById(int index)
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException("Неправильний індес");
                }

                T[] newItems = new T[items.Length];
                int newindex = 0;

                for (int i = 0; i < items.Length; i++) {
                    if (i != index)
                    {
                        newItems[newindex] = items[i];
                        newindex++;
                    }
                }

                count--;
                items = newItems;
            }

            public void show()
            {
                foreach (var item in items)
                {
                    if (item != null)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int lenght = 5;

            CustomCollection<int> intCollection = new CustomCollection<int>(lenght);
            for (int i = 0; i < lenght; i++)
            {
                intCollection.addItem(i);
            }
            intCollection.removeItemById(3);
            intCollection.show();
            Console.WriteLine(intCollection.getItemById(2));

           CustomCollection<string> stringCollection = new CustomCollection<string>(lenght);
           stringCollection.addItem("hello");
           stringCollection.addItem("world");
           stringCollection.removeItemById(1);
           stringCollection.show();
        }
    }
}
