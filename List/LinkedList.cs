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
            Node tmpNode = new Node(value);

            if (Length!=0)
            {
                NodeByIndex(Length - 1).Next = tmpNode;
            }
            else
            {
                _root = tmpNode ;
            }

            _tail = tmpNode;
            Length++;
        }

        public void AddByZeroIndex(int value)
        {
            LinkedList linkedList = new LinkedList(value);
            Node tmpNode = _root;
            _root = new Node(value);

            if (Length!=0)
            {
                _root.Next = tmpNode;
            }
            else
            {
                _tail = _root;
            }

            Length++;
        }
        public void AddByIndex(int index, int value)
        {
            if (index!=0)
            {
                Node tmpNode = NodeByIndex(index-1);
                Node insertNode = new Node(value);

                insertNode.Next = tmpNode.Next;
                tmpNode.Next = insertNode;
                Length++;
            }
            else
            {
                AddByZeroIndex(value);
            }
        }

        public void RemoveLastElement()
        {
            if (Length==0)
            {
                throw new ArgumentException("net elementov");
            }

            Node tmpNode = NodeByIndex(Length-2);

            tmpNode.Next = null;
            _tail.Next = tmpNode;
            Length--;
        }
        public void RemoveFirst()
        {
            if (Length == 0)
            {
                throw new ArgumentException("net elementov");
            }

            _root = _root.Next;
            Length--;
        }

        public void RemoveByIndex(int index)
        {
            Node tmpNode = NodeByIndex(index-1);

            if (index==0)
            {
                _root = _root.Next;
            }
            else if(index==Length-1)
            {
               _tail=NodeByIndex(Length - 1).Next = null;
            }
            else
            {
                tmpNode.Next = tmpNode.Next.Next;
            }

            Length--;
        }

        public void RemoveXElementsByEnd(int x)
        {
            if ( x > Length)
            {
                throw new ArgumentException("удаление больше элементов чем в массиве");
            }

            for (int i = 0; i < x; i++)
            {
                RemoveLastElement();
            }

            if (Length==0)
            {
                _root = null;
                _tail = null;
            }
        }

        public void RemoveXElementsByStart(int x)
        {
            if (x > Length)
            {
                throw new ArgumentException("удаление больше элементов чем в массиве");
            }

            for (int i = 0; i < x; i++)
            {
                RemoveFirst();
            }

            if (Length==0)
            {
                _root = null;
                _tail = null;
            }
        }

        //9
        public void ClearByIndexXElements(int x, int startPoint)
        {
            if (startPoint + x > Length)
            {
                throw new ArgumentException("удаление больше элементов чем в массиве");
            }

            int tmpLength = Length-x;

            do
            {
                int i = startPoint;
                RemoveByIndex(i);
            } while (Length != tmpLength);
             
            
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
            if (Length==0)
            {
                throw new ArgumentNullException("лист не имеет элементов");
            }

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
            if (Length == 0)
            {
                throw new ArgumentNullException("лист не имеет элементов");
            }

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
            if (Length == 0)
            {
                throw new ArgumentNullException("лист не имеет элементов");
            }

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
            if (Length == 0)
            {
                throw new ArgumentNullException("лист не имеет элементов");
            }

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

        public void SortAscending()
        {
            for (int i = 1; i < Length; i++)
            {
                for (int j = 0; j < Length - i; j++)
                {
                    int tmp;

                    if (NodeByIndex(j + 1).Value < NodeByIndex(j).Value)
                    {
                        tmp = NodeByIndex(j).Value;
                        NodeByIndex(j).Value = NodeByIndex(j + 1).Value;
                        NodeByIndex(j + 1).Value = tmp;
                    }
                }
            }
        } //19

        public void SortDescending()
        {
            for (int i = 1; i < Length; i++)
            {
                for (int j = 0; j < Length - i; j++)
                {
                    int tmp;

                    if (NodeByIndex(j + 1).Value > NodeByIndex(j).Value)
                    {
                        tmp = NodeByIndex(j).Value;
                        NodeByIndex(j).Value = NodeByIndex(j + 1).Value;
                        NodeByIndex(j + 1).Value = tmp;
                    }
                }
            }
        }

            public int RemoveByValueFisrt(int value)
        {
            if (Length == 0)
            {
                throw new ArgumentNullException("лист не имеет элементов");
            }

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
            if (Length == 0)
            {
                throw new ArgumentNullException("лист не имеет элементов");
            }

            int count = 0;
            
            for (int i = 0; i < Length; i++)
            {
                if (NodeByIndex(i).Value == value)
                {
                    if (i==0)
                    {
                        _root = _root.Next;
                    }
                    else
                    {
                        NodeByIndex(i - 1).Next = NodeByIndex(i).Next;
                    }
                    
                    count++;
                    Length--;
                    i--;
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
            int[] tmpArray= new int[Length];
            NodeByIndex(index-1).Next =insertLinkedList._root;

            NodeByIndex(index+insertLinkedList.Length-1).Next = tmpNode;

            for (int i = 0; i < Length; i++)
            {
                tmpArray[i] = NodeByIndex(i).Value;
            }
            LinkedList tmpLinkedList = new LinkedList(tmpArray);

            _root = tmpLinkedList._root;
            _tail = tmpLinkedList._tail;

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

            while (!(currentThis is null))
            {
                if (currentThis.Value != currentList.Value)
                {
                    return false;
                }
                currentList = currentList.Next;
                currentThis = currentThis.Next;
            }

            return true;
        }
        private Node NodeByIndex(int index)
        {
            if (index>Length-1)
            {
                throw new ArgumentOutOfRangeException("netu indexa");
            }
            Node tmpNode = _root;

            for (int i = 0; i < index; i++)
            {
                tmpNode = tmpNode.Next;
            }
            return tmpNode;
        }
    }
}
