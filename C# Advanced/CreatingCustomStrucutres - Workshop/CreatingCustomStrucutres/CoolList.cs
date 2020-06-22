
using System;
using Microsoft.VisualBasic;

namespace CreatingCustomStrucutres
{
    public class CoolList<T>
    {
        private int capacity;
        private T[] data;
        public int Count { get; private set; }

        public CoolList():
            this(4)
        {
        }

        public CoolList(int capacity)
        {
            this.capacity = capacity;
            this.data = new T[capacity];
        }

        public void Add(T element)
        {
            if (this.Count == data.Length - 1)
            {
                Resize();
            }

            data[this.Count] = element;
            this.Count++;
        }

        public void Swap(int index, int index2)
        {
            this.ValidateIndex(index);
            this.ValidateIndex(index2);
            var temp = this.data[index];
            this.data[index] = this.data[index2];
            this.data[index2] = temp;
        }

        public T RemoveAt(int index)
        {
            if (this.Count == this.capacity/2)
            {
                Shrink();
            }
            this.ValidateIndex(index);
            var removed = this.data[index];
            for (int i = index + 1; i < this.Count; i++)
            {
                this.data[i - 1] = this.data[i];
            }

            this.Count--;
            return removed;
        }

        public void Clear()
        {
            this.data = new T[this.capacity];
            this.Count = 0;
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.data[index];
            }
            set 
            {
                this.ValidateIndex(index);
                this.data[index] = value;
            }
        }

        private void Shrink()
        {
            var resizedData = new T[capacity / 2];
            this.capacity /= 2;
            for (int i = 0; i < resizedData.Length; i++)
            {
                resizedData[i] = this.data[i];
            }

            this.data = resizedData;
        }
        private void Resize()
        {
            var resizedData = new T[capacity * 2];
            this.capacity *= 2;
            for (int i = 0; i < this.data.Length; i++)
            {
                resizedData[i] = this.data[i];
            }

            this.data = resizedData;
        }
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
        }
    }
}
