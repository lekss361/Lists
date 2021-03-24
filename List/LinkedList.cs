using System;
using System.Collections.Generic;
using System.Text;

namespace List
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

    public class LinkedList
    {
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

        }

        public void AddByIndex(int index, int value)
        {

        }

        public void RemoveLastElement()
        {

        }
        public void RemoveFirstElement()
        {
            _root = _root.Next;
        }
        public void RemoveByIndex(int index)
        {
            Node current = _root;

            for (int i = 1; i < index; i++)
            {
                current = current.Next;
            }

            current.Next = current.Next.Next;

            Length--;
        }

        public void RemoveXElementsByEnd(int x)
        {

        }

        public void RemoveXElementsByStart(int x)
        {

        }

        public void ClearByIndexXElements(int x, int startPoint)
        {

        }

        public int arrayLength()
        {
            return 1;
        }

        public int FirstIndexByValue(int value)
        {
            return 1;
        }

        public void ChangeValueByIndex(int index, int value)
        {

        }

        public void Reverse()
        {

        }

        public int MaxValue()
        {
            return 1;
        }

        public int MinValue()
        {
            return 1;
        }

        public int IndexOfMaxValue()
        {
            return 1;
        }

        public int IndexOfMinValue()
        {
            return 1;
        }

        public void SortAscending()
        {

        }

        public void SortDescending()
        {

        }

        public int RemoveByValueFisrt(int value)
        {
            return 1;
        }

        public int RemoveByValueAll(int value)
        {
            return 1;
        }

        public void AddArrayListInEnd(ArrayList insertArray)
        {

        }

        public void AddArrayListByFirstIndex(ArrayList insertArray)
        {

        }

        public void AddArrayListByIndex(int index, ArrayList insertArray)
        {

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
