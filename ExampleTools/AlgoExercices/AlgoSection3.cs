using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoExercices
{
    public class Ex1_3
    {
        int MAX = 100;

        int _minValue, _actualValue, _count;

        int[] _arr;

        public int Length => _count;

        public Ex1_3()
        {
            _arr = new int[MAX];
        }

        public void Push(int value)
        {
            if (_count >= MAX) throw new OutOfMemoryException("Array reach maximum numer of elements.");

            if (_count == 0)
            {
                _arr[_count] = value;
                _actualValue = value;
                _minValue = value;
                _count++;
                return;
            }

            if (value < _minValue)
            {
                _arr[_count] = 2 * value - _minValue;
                _minValue = value;
            }
            else
            {
                _arr[_count] = value;
            }

            _arr[_count] = value;
            _actualValue = value;

            _count++;
        }

        public void Pop()
        {
            if (_count <= 0) throw new OutOfMemoryException("Array has no elements.");

            if (_count == 1)
            {
                _actualValue = _arr[_count - 1];
                _minValue = _arr[_count - 1];
                return;
            }

            if (_arr[_count - 1] < _minValue)
            {
                _minValue = 2 * _minValue - _arr[_count - 1];
            }
            _actualValue = (_arr[_count - 1] + _minValue) / 2;

            _count--;
        }

        public int MostTop() => _actualValue;

        public int Min => _minValue;

        public void Clear()
        {
            _count = 0;
            _minValue = 0;
            _actualValue = 0;
            _arr = new int[MAX];
        }
    }

    public class Ex2_3
    {
        int _count, _countSStack;

        static int MAX_SOUS_STACK, MAX_STACK;

        SousStack[] _arrSStack;

        public Ex2_3(int maxSousStack)
        {
            _countSStack = 0;
            _arrSStack = new SousStack[_countSStack];
            MAX_SOUS_STACK = maxSousStack;
            MAX_STACK = 10;
        }

        private class SousStack
        {
            int _count;

            int[] _arr;

            int _minValue, _actualValue;

            public SousStack()
            {
                _arr = new int[MAX_SOUS_STACK];
            }

            public void Push(int value)
            {
                if (_count >= MAX_SOUS_STACK) throw new IndexOutOfRangeException("Stack reach maximum numer of elements.");

                if (_count == 0)
                {
                    _arr[_count] = value;
                    _actualValue = value;
                    _minValue = value;
                    _count++;
                    return;
                }

                if (value < _minValue)
                {
                    _arr[_count] = 2 * value - _minValue;
                    _minValue = value;
                }
                else
                {
                    _arr[_count] = value;
                }

                _arr[_count] = value;
                _actualValue = value;

                _count++;
            }

            public void Pop()
            {
                if (_count <= 0) throw new IndexOutOfRangeException("Stack has no elements.");

                if (_count == 1)
                {
                    _actualValue = _arr[_count - 1];
                    _minValue = _arr[_count - 1];
                    return;
                }

                if (_arr[_count - 1] < _minValue)
                {
                    _minValue = 2 * _minValue - _arr[_count - 1];
                }
                _actualValue = (_arr[_count - 1] + _minValue) / 2;

                _count--;
            }

            public int MostTop() => _actualValue;

            public int Min => _minValue;
        }

        public void Push(int value)
        {
            if (_count / MAX_SOUS_STACK == MAX_STACK) throw new IndexOutOfRangeException("Stack reach maximum elements.");

            if (_count < MAX_SOUS_STACK)
            {
                _countSStack = 0;
            }
            else
            {
                if (_count % MAX_SOUS_STACK == 0)
                {
                    _countSStack = (int)_countSStack / MAX_SOUS_STACK + 1;
                    _arrSStack[_countSStack] = new SousStack();
                }
            }

            _arrSStack[_countSStack].Push(value);

            _count++;
        }

        public void Pop()
        {
            if (_count == 0) throw new IndexOutOfRangeException("Stack has no elements.");

            if (_count < MAX_SOUS_STACK)
            {
                _countSStack = 0;
            }
            else
            {
                if (_count % MAX_SOUS_STACK == 0)
                {
                    _countSStack = _countSStack < 0 ? 0 : (int)_countSStack / MAX_SOUS_STACK - 1;
                }
            }

            _arrSStack[_countSStack].Pop();

            _count--;
        }

        public int MostTop() => _arrSStack[_countSStack].MostTop();

        public int Min
        {
            get
            {
                int minVal = _arrSStack[0].Min;
                for (int i = 1; i < _countSStack; i++)
                {
                    if (_arrSStack[i].Min < minVal)
                    {
                        minVal = _arrSStack[i].Min;
                    }
                }

                return minVal;
            }
        }

        public void Clear()
        {
            _count = 0;
            _countSStack = 0;
            MAX_SOUS_STACK = 0;
            MAX_STACK = 0;
            _arrSStack = new SousStack[_countSStack];
        }
    }

    public class Ex3_3
    {
        SousStack _pushStack;

        SousStack _popStack;

        public Ex3_3()
        {
            _pushStack = new SousStack();
            _popStack = new SousStack();
        }

        public void Enqueue(int value)
        {
            _pushStack.Push(value);
        }

        public void Dequeue()
        {
            _popStack.Pop();
        }

        private void PushToPopStack()
        {
            _popStack = new SousStack();
            while(_pushStack.Count > 0)
            {
                _popStack.Push(_popStack.TopMost());
                _popStack.Pop();
            }
        }

        public int GetFront()
        {
            if (_popStack.Count == 0) throw new ArgumentException("Queue has no element.");
            return _popStack.TopMost();
        }

        private class SousStack
        {
            int MAX_SOUS_STACK = 100;

            int _count;

            int[] _arr;

            int _minValue, _actualValue;

            public SousStack()
            {
                _arr = new int[MAX_SOUS_STACK];
            }

            public void Push(int value)
            {
                if (_count >= MAX_SOUS_STACK) throw new IndexOutOfRangeException("Stack reach maximum numer of elements.");

                if (_count == 0)
                {
                    _arr[_count] = value;
                    _actualValue = value;
                    _minValue = value;
                    _count++;
                    return;
                }

                if (value < _minValue)
                {
                    _arr[_count] = 2 * value - _minValue;
                    _minValue = value;
                }
                else
                {
                    _arr[_count] = value;
                }

                _arr[_count] = value;
                _actualValue = value;

                _count++;
            }

            public void Pop()
            {
                if (_count <= 0) throw new IndexOutOfRangeException("Stack has no elements.");

                if (_count == 1)
                {
                    _actualValue = _arr[_count - 1];
                    _minValue = _arr[_count - 1];
                    return;
                }

                if (_arr[_count - 1] < _minValue)
                {
                    _minValue = 2 * _minValue - _arr[_count - 1];
                }
                _actualValue = (_arr[_count - 1] + _minValue) / 2;

                _count--;
            }

            public int TopMost() => _actualValue;

            public int Min => _minValue;

            public int Count => _count;
        }
    }

    public class Ex4_3
    {
        SousStack _stack;

        SousStack _bufferStack;

        public Ex4_3()
        {
            _stack = new SousStack();
            _bufferStack = new SousStack();
        }

        public void Push(int value)
        {
            if(_stack.Count == 0)
            {
                _stack.Push(value);
                return;
            }

            _bufferStack = new SousStack();
            while(_stack.Count > 0)
            {
                if(_stack.TopMost() < value)
                {
                    _bufferStack.Push(_stack.TopMost());
                    _stack.Pop();
                }
            }

            _stack.Push(value);
            if(_bufferStack.Count > 0)
            {
                _stack.Push(_bufferStack.TopMost());
                _bufferStack.Pop();
            }
        }

        public void Pop()
        {
            _stack.Pop();
        }

        public int Peek() => _stack.TopMost();

        public bool isEmpty => _stack.Count == 0;

        private class SousStack
        {
            int MAX_SOUS_STACK = 100;

            int _count;

            int[] _arr;

            int _minValue, _actualValue;

            public SousStack()
            {
                _arr = new int[MAX_SOUS_STACK];
            }

            public void Push(int value)
            {
                if (_count >= MAX_SOUS_STACK) throw new IndexOutOfRangeException("Stack reach maximum numer of elements.");

                if (_count == 0)
                {
                    _arr[_count] = value;
                    _actualValue = value;
                    _minValue = value;
                    _count++;
                    return;
                }

                if (value < _minValue)
                {
                    _arr[_count] = 2 * value - _minValue;
                    _minValue = value;
                }
                else
                {
                    _arr[_count] = value;
                }

                _arr[_count] = value;
                _actualValue = value;

                _count++;
            }

            public void Pop()
            {
                if (_count <= 0) throw new IndexOutOfRangeException("Stack has no elements.");

                if (_count == 1)
                {
                    _actualValue = _arr[_count - 1];
                    _minValue = _arr[_count - 1];
                    return;
                }

                if (_arr[_count - 1] < _minValue)
                {
                    _minValue = 2 * _minValue - _arr[_count - 1];
                }
                _actualValue = (_arr[_count - 1] + _minValue) / 2;

                _count--;
            }

            public int TopMost() => _actualValue;

            public int Min => _minValue;

            public int Count => _count;
        }
    }

    public class Ex5_3
    {

        public Ex5_3()
        {

        }

        public void Enqueue(Animal animal)
        {

        }

        public Animal DequeueAny()
        {
            throw new NotImplementedException();
        }

        public Dog DequeueDog()
        {
            throw new NotImplementedException();
        }

        public Cat DequeueCat()
        {
            throw new NotImplementedException();
        }
    }

    public class Animal
    {

    }

    public class Dog : Animal
    {

    }

    public class Cat : Animal
    {

    }
}
