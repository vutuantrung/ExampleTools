using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoExercices
{
    public class Node
    {
        Node _next;
        int _value;

        public Node(int value)
        {
            _value = value;
        }
        public Node Next
        {
            get { return _next; }
            set { _next = value; }
        }
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
