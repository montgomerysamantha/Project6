using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The class for finding the prime numbers between the bounds
/// specified by the user. Implements the Sieve of Eratosthenes.
/// </summary>
namespace Project6
{
    class SieveList : IEnumerable<int>
    {
        private Node _head;
        private Node _tail;
        private int _size;

        public SieveList()
        {
            _head = null;
            _tail = null;
            _size = 0;
        }

        public int Count
        {
            get
            {
                return _size;
            }
        }

        /// <summary>
        /// Finds the primes for the specified bounds.
        /// </summary>
        public void FindPrimes()
        {
            int bound = _tail.Data;

            Node factor = _head;
            while (factor != null && factor.Data <= Math.Sqrt(bound))
            {
                Node prev = factor;
                Node step = prev.Next;
                while (step != null)
                {
                    if (step.Data % factor.Data == 0)
                    {
                        prev.Next = step.Next;
                        if (prev.Next == null) _tail = prev;
                    }
                    prev = prev.Next;
                    if (prev != null) step = prev.Next;
                    else step = null;
                }
                factor = factor.Next;
            }
        }

        /// <summary>
        /// Builds a linked list of all of the prime numbers.
        /// </summary>
        /// <param name="bound">how large the list is</param>
        public void BuildList(int bound)
        {
            if (Count != 0)
            {
                throw new InvalidOperationException();
            }
            else if (bound <= 1)
            {
                throw new ArgumentException();
            }
            else
            {
                Node cur = new Node(2);
                _head = cur;
                _tail = cur;

                for (int i = 3; i <= bound; i++)
                {
                    cur.Next = new Project6.SieveList.Node(i);
                    cur = cur.Next;
                }
                _tail = cur;
                _size = bound - 1;
            }
        }

        /// <summary>
        /// Shortens the list by only allowing numbers greater than the lower parameter.
        /// </summary>
        /// <param name="lower">the lower bound for our primes</param>
        public void TrimList(int lower)
        {
            //go through linked list
            Node temp = _head;
            while (_head != null)
            {
                if (_head.Data < lower)
                {
                    _head = _head.Next;
                }
                else
                {
                    return;
                }
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new SieveEnumerator(_head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class SieveEnumerator : IEnumerator<int>
        {
            private Node _cur;

            public SieveEnumerator(Node n)
            {
                _cur = new Node(0);
                _cur.Next = n;
            }

            public int Current
            {
                get
                {
                    return _cur.Data;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
                //do nothing
            }

            public bool MoveNext()
            {
                if (_cur == null) return false;
                _cur = _cur.Next;
                return (_cur != null);
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// The Node inner structure of the linked SieveList we are building.
        /// </summary>
        private class Node
        {
            private int _data;
            private Node _next;

            public Node(int d)
            {
                _data = d;
                _next = null;
            }

            public int Data
            {
                get
                {
                    return _data;
                }
            }

            public Node Next
            {
                get
                {
                    return _next;
                }
                set
                {
                    _next = value;
                }
            }
        }
    }
}
