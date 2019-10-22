using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Part1
{
    public class DequeOptimized<T>
    {
        T[] _items;

        int _size;

        int _tail;

        int _head;

        public DequeOptimized()
        {
            _items = new T[0];
            _size = 0;
            _head = 0;
        }

        public void AllocateNewArray(int startingIndex)
        {
            int newLength = _size == 0 ? 4 : _size * 2;

            T[] newArray = new T[newLength];

            if (_size == 0)
            {
                _head = 0;
                _tail = -1;
            }
            else
            {
                int idx = startingIndex;
                if (_head > _tail)
                {
                    // Copy "tail" part (from 0 -> _tail)
                    for (int i = 0; i < _tail; i++)
                    {
                        newArray[idx] = _items[i];
                        idx++;
                    }

                    // Copy "head" part (from _head -> _size)
                    for (int i = _head; i < _size; i++)
                    {
                        newArray[idx] = _items[i];
                        idx++;
                    }
                }
                else
                {
                    for (int i = 0; i < _size; i++)
                    {
                        newArray[idx] = _items[i];
                        idx++;
                    }
                }

                _head = startingIndex;
                _tail = idx - 1;
            }

            _items = newArray;
        }

        public void EnqueueFirst(T item)
        {
            if (_size > _items.Length)
            {
                AllocateNewArray(1);
            }

            _head = _head > 0 ? _head - 1 : _items.Length - 1;
            _items[_head] = item;

            _size++;
        }

        public void EnqueueLast(T item)
        {
            if(_size > _items.Length)
            {
                AllocateNewArray(0);
            }

            if(_tail == _items.Length)
            {
                _tail = 0;
            }
            else
            {
                _tail--;
            }

            _items[_tail] = item;
            _size++;
        }

        public T DequeueFirst()
        {
            if (_size == 0) throw new InvalidOperationException("The deque is empty.");
            T item = _items[_head];

            if (_head >= _items.Length - 1)
            {
                _head = 0;
            }
            else
            {
                _head++;
            }

            _size--;
            return item;
        }

        public T DequeueLast()
        {
            if (_size == 0) throw new InvalidOperationException("The deque is empty.");
            T item = _items[_tail];

            if (_tail == 0)
            {
                _tail = _items.Length;
            }
            else
            {
                _tail--;
            }

            _size--;
            return item;
        }

        public T PeekFirst()
        {
            if (_size == 0) throw new InvalidOperationException("The deque is empty.");
            return _items[_head];
        }

        public T PeekLast()
        {
            if (_size == 0) throw new InvalidOperationException("The deque is empty.");
            return _items[_tail];
        }

        public int Count => _size;
    }
}