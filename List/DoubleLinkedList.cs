using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class DoubleLinkedList
    {
        public class DoubleNode
        {
            public int Value { get; set; }
            public DoubleNode Next { get; set; }
            public DoubleNode Prev { get; set; }

            public DoubleNode(int value)
            {
                Value = value;
                Next = null;
                Prev = null;
            }

        }

        public int Length { get; private set; }

        private DoubleNode _root;
        private DoubleNode _tail;

        public int this[int index]
        {
            get
            {
                return DoubleNodeByIndex(index).Value;
            }

            set
            {
                DoubleNodeByIndex(index).Value = value;
            }
        }

        public DoubleLinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public DoubleLinkedList(int value)
        {
            Length = 1;
            _root = new DoubleNode(value);
            _tail = _tail;
        }

        public DoubleLinkedList(int[] values)
        {
            Length = values.Length;

            if (values.Length != 0)
            {
                _root = new DoubleNode(values[0]);
                _tail = _root;
                DoubleNode tmpDoubleNode = _root;
                for (int i = 1; i < values.Length; i++)
                {
                    tmpDoubleNode = _tail;
                    _tail.Next = new DoubleNode(values[i]);
                    _tail = _tail.Next;
                    _tail.Prev = tmpDoubleNode;
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
            DoubleNode tmpDoubleNode = new DoubleNode(value);
            DoubleNode tmpPrevDoubleNode = _tail;
            if (Length!=0)
            {
            _tail.Next = tmpDoubleNode;
            _tail = _tail.Next;
            _tail.Prev = tmpPrevDoubleNode;
            }
            else
            {
                _root = tmpDoubleNode;
                _tail = _root;
            }

            Length++;
        }

        public void AddByZeroIndex(int value)
        {
            DoubleNode tmpDoubleNode = new DoubleNode(value);
            DoubleNode tmpPrevDoubleNode = _root;

            if (Length!=0)
            {
                tmpDoubleNode.Next = tmpPrevDoubleNode;
                _root = tmpDoubleNode;
                tmpPrevDoubleNode.Prev = tmpDoubleNode;
            }
            else
            {
                _root = tmpDoubleNode;
                _tail = _root;
            }

            Length++;
        }

        public void AddByIndex(int index, int value)
        {
            if (index != 0)
            {
                DoubleNode tmpDoubleNode = DoubleNodeByIndex(index - 1);
                DoubleNode insertDoubleNode = new DoubleNode(value);

                insertDoubleNode.Next = tmpDoubleNode.Next;
                insertDoubleNode.Prev = tmpDoubleNode;
                tmpDoubleNode.Next = insertDoubleNode;

                Length++;
            }
            else
            {
                AddByZeroIndex(value);
            }
        }

        public void RemoveLastElement()
        {
            if (Length == 0)
            {
                throw new ArgumentException("net elementov");
            }

            DoubleNode tmpDoubleNode = DoubleNodeByIndex(Length - 2);

            tmpDoubleNode.Next = null;
            _tail.Next = tmpDoubleNode;
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
            DoubleNode tmpNode = DoubleNodeByIndex(index - 1);

            if (index == 0)
            {
                RemoveFirst();
            }
            else if (index == Length - 1)
            {
                RemoveLastElement();
            }
            else
            {
                tmpNode.Next = tmpNode.Next.Next;
                tmpNode.Next.
            }

            Length--;
        }

        public override string ToString()
        {
            if (Length != 0)
            {
                DoubleNode current = _root;
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
            DoubleLinkedList list = (DoubleLinkedList)obj;

            if (this.Length != list.Length)
            {
                return false;
            }

            DoubleNode currentThis = this._root;
            DoubleNode currentList = list._root;

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
        private DoubleNode DoubleNodeByIndex(int index)
        {
            if (index > Length - 1)
            {
                throw new ArgumentOutOfRangeException("netu indexa");
            }

            DoubleNode firstDoubleNode = _root;
            DoubleNode enddoubleNode = _tail;
            bool indexMoreHalf = index >= Length / 2;
            int tmpIndex = Length - index;

            if (indexMoreHalf)
            {
                index = tmpIndex;
            }

            for (int i = 0; i < index-1; i++)
            {
                if (indexMoreHalf)
                {
                    enddoubleNode = enddoubleNode.Prev;
                }
                else
                {
                    firstDoubleNode = firstDoubleNode.Next;
                }
            }

            if (indexMoreHalf)
            {
                return enddoubleNode;
            }
            else
            {
                return firstDoubleNode;
            }
        }
    }
}


