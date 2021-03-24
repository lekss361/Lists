using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class LinkedList
    {
        public class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }

            public Node(int value)
            {
                Value = value;
                Next = null;
            }

        }

        public int Length { get; private set; }
        public int this[int index]
        {
            get
            {
                Node current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
                return current.Value;
            }

            set
            {
                Node current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }

                current.Value = value;
            }
        }

        private Node _root;
        private Node _tail;

        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public LinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }

        public LinkedList(int[] values)
        {
            //if(values is null)

            Length = values.Length;

            if (values.Length != 0)
            {
                _root = new Node(values[0]);
                _tail = _root;

                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new Node(values[i]);
                    _tail = _tail.Next;
                }
            }
            else
            {
                _root = null;
                _tail = null;
            }
        }

        public void Add(int value)
        {
            Length++;
            _tail.Next = new Node(value);
            _tail = _tail.Next;
        }

        public void AddByZeroIndex(int value)
        {
            Node tmpNode = _root;
            _root = new Node(value);
            _root.Next = tmpNode;
            Length++;
        }
        public void AddByIndex(int index, int value)
        {
            Node tmpNode = _root;
            for (int i = 0; i < index; i++)
            {
                tmpNode = tmpNode.Next;
            }
            Node AdNode = tmpNode;
            tmpNode.Next = AdNode;
            tmpNode = new Node(value);
        }

        public void RemoveLastElement()
        {
            Node tmpNode = _root;
            for (int i = 0; i < Length-2; i++)
            {
                tmpNode = tmpNode.Next;
            }
            tmpNode.Next = null;
            _tail.Next = tmpNode;

            Length--;
        }
        public void RemoveFirst()
        {
            _root = _root.Next;
        }

        public void RemoveByIndex(int index)
        {
            Node tmpAarray = _root;

            for (int i = 1; i < index; i++)
            {
                tmpAarray = tmpAarray.Next;
            }

            tmpAarray.Next = tmpAarray.Next.Next;

            Length--;
        }

        public void RemoveXElementsByEnd(int x)
        {
            Node tmpArray = _root;
            for (int i = 0; i < Length-x-1; i++)
            {
                tmpArray = tmpArray.Next;
            }
            _tail.Next = tmpArray;
            tmpArray.Next = null;

            Length -= x;
        }

        public void RemoveXElementsByStart(int x)
        {
            Node tmpArray = _root;
            for (int i = 0; i < x; i++)
            {
                tmpArray = tmpArray.Next;
            }

            _root = tmpArray;

            Length -= x;
        }

        public void ClearByIndexXElements(int x, int startPoint)
        {
            Node tmpNode = _root;
            Node tmpNodeFirst = _root;
            Node tmpNodeEnd = _root;
            for (int i = 0; i < startPoint + x; i++)
            {
                tmpNode = tmpNode.Next;
                if (i==startPoint-1)
                {
                    tmpNodeFirst = tmpNode;
                }
                else if(i==startPoint+x-1)
                {
                    tmpNodeEnd = tmpNode;
                }
            }
            tmpNodeFirst.Next = tmpNodeEnd;

            if (x+startPoint==Length)
            {
                tmpNodeFirst = null;
                _tail = tmpNodeFirst;
            }

            Length -= x;
        }
        public override string ToString()
        {
            if (Length != 0)
            {
                Node current = _root;
                string s = current.Value + " ";

                while (!(current.Next is null))
                {
                    current = current.Next;
                    s += current.Value + " ";
                }

                return s;
            }
            else
            {
                return String.Empty;
            }
        }

        public override bool Equals(object obj)
        {
            LinkedList list = (LinkedList)obj;

            if (this.Length != list.Length)
            {
                return false;
            }

            Node currentThis = this._root;
            Node currentList = list._root;

            do
            {
                if (currentThis.Value != currentList.Value)
                {
                    return false;
                }
                currentList = currentList.Next;
                currentThis = currentThis.Next;
            }
            while (!(currentThis.Next is null));

            return true;
        }
    }
}
