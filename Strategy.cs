using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    using System;

    namespace lab4
    {
        // Общий интерфейс алгоритмов сортировки
        public interface ISortingStrategy
        {
            void Sort(int[] array);
        }

        // Первая стратегия — пузырьковая сортировка
        public class BubbleSortStrategy : ISortingStrategy
        {
            public void Sort(int[] array)
            {
                Console.WriteLine("Пузырьковая сортировка.");

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j] > array[j + 1])
                        {
                            int temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }
        }

        // Вторая стратегия — быстрая сортировка
        public class QuickSortStrategy : ISortingStrategy
        {
            public void Sort(int[] array)
            {
                Console.WriteLine("Быстрая сортировка.");
                QuickSort(array, 0, array.Length - 1);
            }

            private void QuickSort(int[] array, int left, int right)
            {
                if (left >= right)
                {
                    return;
                }

                int pivot = array[right];
                int boundary = left;

                for (int j = left; j < right; j++)
                {
                    if (array[j] < pivot)
                    {
                        int temp = array[boundary];
                        array[boundary] = array[j];
                        array[j] = temp;

                        boundary++;
                    }
                }

                int pivotTemp = array[boundary];
                array[boundary] = array[right];
                array[right] = pivotTemp;

                QuickSort(array, left, boundary - 1);
                QuickSort(array, boundary + 1, right);
            }
        }

        // Контекст — использует выбранную стратегию
        public class Sorter
        {
            private ISortingStrategy strategy;

            public Sorter(ISortingStrategy strategy)
            {
                this.strategy = strategy;
            }

            public void SetStrategy(ISortingStrategy strategy)
            {
                this.strategy = strategy;
            }

            public void SortArray(int[] array)
            {
                strategy.Sort(array);
            }
        }
    }
}
