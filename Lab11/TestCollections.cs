using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10;

namespace Lab11
{
    public class TestCollections
    {
        private Queue<Guitar> col1;
        private Queue<string> col2;
        private SortedSet<MusicalInstrument> col3;
        private SortedSet<string> col4;

        private Guitar first;
        private Guitar middle;
        private Guitar last;
        private Guitar notInCollection;

        public TestCollections(int count = 1000)
        {
            col1 = new Queue<Guitar>();
            col2 = new Queue<string>();
            col3 = new SortedSet<MusicalInstrument>();
            col4 = new SortedSet<string>();

            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                Guitar g = new Guitar(rand.Next(4, 17), i);
                g.Name = $"Гитара{i}";

                if (i == 0) first = (Guitar)g.Clone();
                if (i == count / 2) middle = (Guitar)g.Clone();
                if (i == count - 1) last = (Guitar)g.Clone();

                col1.Enqueue(g);
                col2.Enqueue(g.ToString());
                col3.Add(g.GetBase);
                col4.Add(g.ToString());
            }

            notInCollection = new Guitar(6, 1000) { Name = "Гитара1000" };
        }

        public void MeasureSearchTimes()
        {
            Console.WriteLine("Задание 3: Измерение времени поиска");

            // Поиск в Queue<Guitar>
            MeasureSearchQueueGuitar(first, "Первый элемент");
            MeasureSearchQueueGuitar(middle, "Средний элемент");
            MeasureSearchQueueGuitar(last, "Последний элемент");
            MeasureSearchQueueGuitar(notInCollection, "Элемент вне коллекции");

            // Поиск в Queue<string>
            MeasureSearchQueueString(first, "Первый элемент");
            MeasureSearchQueueString(middle, "Средний элемент");
            MeasureSearchQueueString(last, "Последний элемент");
            MeasureSearchQueueString(notInCollection, "Элемент вне коллекции");

            // Поиск в SortedSet<MusicalInstrument>
            MeasureSearchSortedSetGuitar(first, "Первый элемент");
            MeasureSearchSortedSetGuitar(middle, "Средний элемент");
            MeasureSearchSortedSetGuitar(last, "Последний элемент");
            MeasureSearchSortedSetGuitar(notInCollection, "Элемент вне коллекции");

            // Поиск в SortedSet<string>
            MeasureSearchSortedSetString(first, "Первый элемент");
            MeasureSearchSortedSetString(middle, "Средний элемент");
            MeasureSearchSortedSetString(last, "Последний элемент");
            MeasureSearchSortedSetString(notInCollection, "Элемент вне коллекции");
        }

        private void MeasureSearchQueueGuitar(Guitar searchedElement, string elementDescription)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                col1.Contains(searchedElement);
            }
            sw.Stop();
            double averageTicks = (double)sw.ElapsedTicks / 1000;
            Console.WriteLine($"Queue<Guitar> - {elementDescription}: {averageTicks} тиков");
        }

        private void MeasureSearchQueueString(Guitar searchedElement, string elementDescription)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                col2.Contains(searchedElement.ToString());
            }
            sw.Stop();
            double averageTicks = (double)sw.ElapsedTicks / 1000;
            Console.WriteLine($"Queue<string> - {elementDescription}: {averageTicks} тиков");
        }

        private void MeasureSearchSortedSetGuitar(Guitar searchedElement, string elementDescription)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                col3.Contains(searchedElement.GetBase);
            }
            sw.Stop();
            double averageTicks = (double)sw.ElapsedTicks / 1000;
            Console.WriteLine($"SortedSet<MusicalInstrument> - {elementDescription}: {averageTicks} тиков");
        }

        private void MeasureSearchSortedSetString(Guitar searchedElement, string elementDescription)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                col4.Contains(searchedElement.ToString());
            }
            sw.Stop();
            double averageTicks = (double)sw.ElapsedTicks / 1000;
            Console.WriteLine($"SortedSet<string> - {elementDescription}: {averageTicks} тиков");
        }
    }
}
