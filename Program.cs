using lab4.lab4;
using System;

namespace lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Strategy: ");

            int[] array1 = { 5, 3, 8, 4, 2 };
            int[] array2 = { 5, 3, 8, 4, 2 };

            Sorter sorter = new Sorter(new BubbleSortStrategy());

            Console.WriteLine("До: " + string.Join(", ", array1));
            sorter.SortArray(array1);
            Console.WriteLine("После: " + string.Join(", ", array1));

            Console.WriteLine();

            sorter.SetStrategy(new QuickSortStrategy());

            Console.WriteLine("До: " + string.Join(", ", array2));
            sorter.SortArray(array2);
            Console.WriteLine("После: " + string.Join(", ", array2));

            Console.WriteLine();

            Console.WriteLine("Chain of Responsibility: ");

            IHandler handlerA = new ConcreteHandlerA();
            IHandler handlerB = new ConcreteHandlerB();

            handlerA.SetNextHandler(handlerB);

            Console.WriteLine("Запрос типа A:");
            handlerA.HandleRequest(new Request(RequestType.TypeA));

            Console.WriteLine();
            Console.WriteLine("Запрос типа B:");
            handlerA.HandleRequest(new Request(RequestType.TypeB));

            Console.WriteLine();
            Console.WriteLine("Запрос типа C:");
            handlerA.HandleRequest(new Request(RequestType.TypeC));

            Console.WriteLine();

            Console.WriteLine("Iterator: ");

            string[] fruits = { "Яблоко", "Груша", "Апельсин" };
            IIterator<string> iterator = new ArrayIterator<string>(fruits);

            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }

            Console.WriteLine("Остались элементы: " + iterator.HasNext());

            try
            {
                iterator.Next();
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine("Повторный вызов Next: " + exception.Message);
            }
        }
    }
}
