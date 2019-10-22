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
            get
            {
                if(index > _count || index < 0) throw new IndexOutOfRangeException();
                return _items[index];
            }
            set
            {

                if (index > _count || index < 0) throw new IndexOutOfRangeException();
                _items[index] = value;
            }
        }

        public int Count => _count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (_count == _items.Length)
            {
                GrowArray();
            }
            _items[_count++] = item;
        }

        public void Clear()
        {
            _items = new T[0];
            _count = 0;
        }

        public bool Contains(T item) => IndexOf(item) != -1;

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(_items, 0, array, 0, _count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < _count; i++)
            {
                yield return _items[i];
            }
        }

        public int IndexOf(T item)
        {
            for(int i = 0; i < _count; i++)
            {
                if (_items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index >= _count) throw new IndexOutOfRangeException();
            if (_items.Length == _count)
            {
                GrowArray();
            }

            Array.Copy(_items, index, _items, index + 1, _count - index);

            _items[index] = item;

            _count++;
        }

        public bool Remove(T item)
        {
            for(int i = 0; i < _count; i++)
            {
                if (_items[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count) throw new IndexOutOfRangeException();
            Array.Copy(_items, index, _items, index + 1, _count - index);
            _count--;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
