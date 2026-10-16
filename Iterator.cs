using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{

    // Интерфейс итератора
    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
    }

    // Итератор для последовательного обхода массива
    public class ArrayIterator<T> : IIterator<T>
    {
        private readonly T[] items;
        private int position;

        public ArrayIterator(T[] items)
        {
            this.items = items;
            position = 0;
        }

        public bool HasNext()
        {
            return position < items.Length;
        }

        public T Next()
        {
            if (!HasNext())
            {
                throw new InvalidOperationException(
                    "Элементы закончились.");
            }

            return items[position++];
        }
    }
}

