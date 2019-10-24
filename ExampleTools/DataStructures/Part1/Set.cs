using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Part1
{
    public class Set<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        int _count;

        private readonly List<T> _items;

        public Set()
        {
            _items = new List<T>();
        }

        public Set(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public void Add(T item)
        {
            if (Contains(item))
            {
                throw new InvalidOperationException("item already exists in Set.");
            }
            _items.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach(T item in items)
            {
                Add(item);
            }
        }

        public bool Remove(T item) => _items.Remove(item);

        public bool Contains(T item) => _items.Contains(item);

        public int Count => _count;

        public Set<T> Union(Set<T> other)
        {
            Set<T> union = new Set<T>(_items);
            foreach(T item in _items)
            {
                if (!other.Contains(item))
                {
                    union.Add(item);
                }
            }
            return union;
        }

        public Set<T> Intersection(Set<T> other)
        {
            Set<T> intersection = new Set<T>();
            foreach(T item in _items)
            {
                if (other._items.Contains(item))
                {
                    intersection.Add(item);
                }
            }

            return intersection;
        }

        public Set<T> Difference(Set<T> other)
        {
            Set<T> difference = new Set<T>(_items);
            foreach(T item in other._items)
            {
                difference.Remove(item);
            }

            return difference;
        }

        public Set<T> SymetricDifference(Set<T> other)
        {
            Set<T> union = Union(other);
            Set<T> intersection = Intersection(other);
            return union.Difference(intersection);
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
