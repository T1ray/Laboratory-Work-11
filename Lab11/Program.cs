using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using static AdditionalFunctions.AdditionalFunctions;
using Lab10;

namespace Lab11
{
    class Program
    {
        static void Task1()
        {
            Console.WriteLine("Задание 1: Неуниверсальная коллекция Queue");
            
            Queue queue = new Queue();
            
            queue.Enqueue(new MusicalInstrument("Скрипка", 1));
            queue.Enqueue(new Guitar(6, 2));
            queue.Enqueue(new ElectricGuitar("фиксированный источник питания", 6, 3));
            queue.Enqueue(new Piano(88, "октавная", 4));
            foreach (var instrument in queue)
            {
                Console.WriteLine(instrument);
            }
            Console.WriteLine("Элементы добавлены в очередь.");
            Console.WriteLine("---");
            
            queue.Dequeue();
            foreach (var instrument in queue)
            {
                Console.WriteLine(instrument);
            }
            Console.WriteLine("Первый элемент удален.");
            Console.WriteLine("---");
            
            // Запрос 1: Среднее количество струн у гитар
            int totalNumberStrings = 0;
            int numberGuitars = 0;

            foreach (var instrument in queue)
            {
                if (instrument is Guitar guitar)
                {
                    totalNumberStrings += guitar.NumberStrings;
                    numberGuitars++;
                }
            }
            Console.WriteLine("Среднее количество струн у гитар: ");
            Console.Write(numberGuitars > 0 ? (double)totalNumberStrings / numberGuitars : 0 + "\n");
            Console.WriteLine("---");

            // Запрос 2: Общее количество струн на всех электрогитарах с фиксированным источником питания
            totalNumberStrings = 0;

            foreach (var instrument in queue)
            {
                ElectricGuitar? electricGuitar = instrument as ElectricGuitar;
                if (electricGuitar != null && electricGuitar.PowerSource.ToLower() == "фиксированный источник питания")
                {
                    totalNumberStrings += electricGuitar.NumberStrings;
                }
            }
            Console.WriteLine($"Общее количество струн на всех электрогитарах с фиксированным источником питания: {totalNumberStrings}");
            Console.WriteLine("---");

            // Запрос 3: Максимальное число с октавной раскладкой клавиш
            int maxNumberKeys = 0;

            foreach (var instrument in queue)
            {
                if (instrument.GetType() == typeof(Piano))
                {
                    Piano piano = (Piano)instrument;
                    if (piano.KeyLayout == "октавная" && piano.NumberKeys > maxNumberKeys)
                    {
                        maxNumberKeys = piano.NumberKeys;
                    }
                }
            }
            Console.WriteLine($"Максимальное число с октавной раскладкой клавиш: {maxNumberKeys}");
            Console.WriteLine("---");
            
            Console.WriteLine("Все элементы коллекции:");
            foreach (var obj in queue)
            {
                Console.WriteLine(obj.ToString());
            }
            Console.WriteLine("---");
            
            Queue clonedQueue = (Queue)queue.Clone();
            Console.WriteLine("Коллекция(очередь) клонирована");
            
            ArrayList tempList = new ArrayList(queue);
            tempList.Sort();
            Console.WriteLine("Коллекция отсортирована (временный список):");
            foreach (object obj in tempList)
            {
                Console.WriteLine(obj.ToString());
            }

            MusicalInstrument searchInstrument = new Guitar(6, 2);
            bool found = queue.Contains(searchInstrument);
            Console.WriteLine(found
                ? $"Элемент {searchInstrument} найден в очереди"
                : $"Элемент {searchInstrument} не найден в очереди");
        }
        
        static void Task2()
        {
            Console.WriteLine("Задание 2: Обобщенная коллекция SortedSet<MusicalInstrument>");
            
            SortedSet<MusicalInstrument> instrumentSet = new SortedSet<MusicalInstrument>();
            
            instrumentSet.Add(new Guitar(6, 5));
            instrumentSet.Add(new ElectricGuitar("фиксированный источник питания", 6, 3));
            instrumentSet.Add(new Piano(88, "октавная", 7));
            instrumentSet.Add(new MusicalInstrument("Флейта", 8));
            foreach (var instrument in instrumentSet)
            {
                Console.WriteLine(instrument);
            }
            Console.WriteLine("Элементы добавлены в SortedSet.");
            Console.WriteLine("---");
            
            MusicalInstrument toRemove = new Guitar(6, 5);
            instrumentSet.Remove(toRemove);
            foreach (var instrument in instrumentSet)
            {
                Console.WriteLine(instrument);
            }
            Console.WriteLine("Элемент удален.");
            Console.WriteLine("---");
            
            // Запрос 1: Среднее количество струн у гитар
            int totalNumberStrings = 0;
            int numberGuitars = 0;

            foreach (var instrument in instrumentSet)
            {
                if (instrument is Guitar guitar)
                {
                    totalNumberStrings += guitar.NumberStrings;
                    numberGuitars++;
                }
            }
            Console.Write("Среднее количество струн у гитар: ");
            Console.WriteLine(numberGuitars > 0 ? (double)totalNumberStrings / numberGuitars : 0);
            
            // Запрос 2: Общее количество струн на всех электрогитарах с фиксированным источником питания
            totalNumberStrings = 0;

            foreach (var instrument in instrumentSet)
            {
                ElectricGuitar? electricGuitar = instrument as ElectricGuitar;
                if (electricGuitar != null && electricGuitar.PowerSource.ToLower() == "фиксированный источник питания")
                {
                    totalNumberStrings += electricGuitar.NumberStrings;
                }
            }
            Console.WriteLine($"Общее количество струн на всех электрогитарах с фиксированным источником питания: {totalNumberStrings}");
            
            // Запрос 3: Максимальное число с октавной раскладкой клавиш
            int maxNumberKeys = 0;

            foreach (var instrument in instrumentSet)
            {
                if (instrument.GetType() == typeof(Piano))
                {
                    Piano piano = (Piano)instrument;
                    if (piano.KeyLayout == "октавная" && piano.NumberKeys > maxNumberKeys)
                    {
                        maxNumberKeys = piano.NumberKeys;
                    }
                }
            }
            Console.WriteLine($"Максимальное число с октавной раскладкой клавиш: {maxNumberKeys}");
            
            Console.WriteLine("Все элементы коллекции (отсортированы по имени):");
            foreach (MusicalInstrument mi in instrumentSet)
            {
                Console.WriteLine(mi);
            }
            
            SortedSet<MusicalInstrument> clonedSet = new SortedSet<MusicalInstrument>(instrumentSet);
            foreach (var instrument in clonedSet)
            {
                Console.WriteLine(instrument);
            }
            
            MusicalInstrument searchInstrument = new ElectricGuitar("батарейки", 7, 6);
            bool found = instrumentSet.Contains(searchInstrument);
            Console.WriteLine(found
                ? $"Элемент {searchInstrument} найден"
                : "Элемент не найден 1");
        }
        
        static void Task3()
        {
            TestCollections test = new TestCollections();

            test.MeasureSearchTimes();
        }

        static void Menu()
        {
            Console.WriteLine("1. Выполнить 1-ую часть");
            Console.WriteLine("2. Выполнить 2-ую часть");
            Console.WriteLine("3. Выполнить 3-ую часть");
        }
        
        static void Main(string[] args)
        {
            while (true)
            {
                Menu();
                TextSeparator();
                Console.Write("Выберите пункт меню: ");
                string input = Console.ReadLine();
                TextSeparator();
                switch (input)
                {
                    case "1":
                        Task1();
                        break;
                    case "2":
                        Task2();
                        break;
                    case "3":
                        Task3();
                        break;
                }
                TextSeparator();
            }
        }
    }
}