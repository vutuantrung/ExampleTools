using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Part1
{
    public class ArrayList<T> : IList<T>
    {
        int _count;
        T[] _items;

        public ArrayList() 
            : this(0)
        {
        }

        public ArrayList(int length)
        {
            if (length < 0) throw new ArgumentException("Invalid length.");
            _items = new T[length];
        }

        private void GrowArray()
        {
            int newLength = _items.Length == 0 ? 16 : _items.Length << 1;
            T[] newArr = new T[newLength];
            _items.CopyTo(newArr, 0);
            _items = newArr;
        }

        public T this[int index]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > _count) throw new IndexOutOfRangeException();
            if (_items.Length == _count)
            {
                GrowArray();
            }


        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
