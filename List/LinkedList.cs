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

        //9
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

            Length -= x-1;
        }

        //10
        public int ReturnLength()
        {
            return Length;
        }

        //11
        public void AccessByIndex()
        {
            
        }

        //14
        public void Revers()
        {
                Node Current = _root;
                Node tmpNode = new Node(1);

            while (Current.Next != null)
            {
                tmpNode = Current.Next;
                Current.Next = tmpNode.Next;
                tmpNode.Next = _root;
                _root = tmpNode;
            }
        }
        //15
        public int MaxValue()
        {
            int maxValue = NodeByIndex(0).Value;

            for (int i = 1; i < Length; i++)
            {
                if (maxValue<NodeByIndex(i).Value)
                {
                    maxValue = NodeByIndex(i).Value;
                }
            }

            return maxValue;
        }

        public int MinValue()
        {
            int minValue = NodeByIndex(0).Value;

            for (int i = 1; i < Length; i++)
            {
                if (minValue > NodeByIndex(i).Value)
                {
                    minValue = NodeByIndex(i).Value;
                }
            }

            return minValue;
        }

        public int IndexOfMaxValue()
        {
            int maxValue = NodeByIndex(0).Value;

            for (int i = 0; i < Length; i++)
            {
                if (maxValue > NodeByIndex(i).Value)
                {
                    maxValue = i-1;
                }
            }

            return maxValue;
        }

        public int IndexOfMinValue()
        {
            int minValue = NodeByIndex(0).Value;

            for (int i = 0; i < Length; i++)
            {
                if (minValue < NodeByIndex(i).Value)
                {
                    minValue = i-2;
                }
            }

            return minValue;
        }

        public int RemoveByValueFisrt(int value)
        {
            int index = -1;
            Length--;
            for (int i = 1; i < Length; i++)
            {
                if (NodeByIndex(i).Value==value)
                {
                    NodeByIndex(i - 1).Next = NodeByIndex(i).Next;
                    return index;
                }
                
            }
            return index;
        }

        public int RemoveByValueAll(int value)
        {
            int count = 0;
            
            for (int i = 1; i < Length; i++)
            {
                if (NodeByIndex(i).Value == value)
                {
                    NodeByIndex(i - 1).Next = NodeByIndex(i).Next;
                    count++;
                    Length--;
                }

            }

            return count;
        }

        public void AddLinkedListInEnd(LinkedList insertLinkedList)
        {
            AddLinkedListByIndex(Length, insertLinkedList);
        }

         public void AddArrayListByZeroIndex(LinkedList insertLinkedList)
        {
            AddLinkedListByIndex(0, insertLinkedList);
        }

        public void AddLinkedListByIndex(int index, LinkedList insertLinkedList)
        {
            Length += insertLinkedList.Length;
            Node tmpNode = NodeByIndex(index);
            NodeByIndex(index-1).Next =insertLinkedList._root;

            NodeByIndex(index+insertLinkedList.Length-1).Next = tmpNode;
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
        private Node NodeByIndex(int index)
        {
            Node tmpNode = _root;

            for (int i = 0; i < index; i++)
            {
                tmpNode = tmpNode.Next;
            }
            return tmpNode;
        }
    }
}
