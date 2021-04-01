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
      if (Length != 0)
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

      if (Length != 0)
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


      if (index == 0)
      {

        AddByZeroIndex(value);
      }
      else if (index == Length - 1)
      {
        Add(value);
      }
      else
      {
        DoubleNode firstDoubleNode = DoubleNodeByIndex(index - 1);
        DoubleNode endDoubleNode = DoubleNodeByIndex(index);
        DoubleNode insertDoubleNode = new DoubleNode(value);

        insertDoubleNode.Next = endDoubleNode;
        insertDoubleNode.Prev = firstDoubleNode;
        firstDoubleNode.Next = insertDoubleNode;
        endDoubleNode.Prev = insertDoubleNode;
        Length++;
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
      _tail = tmpDoubleNode;
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
      DoubleNode tmpNode = DoubleNodeByIndex(index);

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
        DoubleNodeByIndex(index - 1).Next = DoubleNodeByIndex(index + 1);
        DoubleNodeByIndex(index + 1).Prev = DoubleNodeByIndex(index - 1);
        Length--;
      }
    }

    public void RemoveXElementsByEnd(int x)
    {
      if (x > Length)
      {
        throw new ArgumentException("удаление больше элементов чем в массиве");
      }

      for (int i = 0; i < x; i++)
      {
        RemoveLastElement();
      }

      if (Length == 0)
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

      if (Length == 0)
      {
        _root = null;
        _tail = null;
      }
    }

    public void ClearByIndexXElements(int count, int index)
    {
      if (index + count > Length)
      {
        throw new ArgumentException("удаление больше элементов чем в массиве");
      }

      int tmpLength = Length - count;

      while (Length != tmpLength)
      {
        RemoveByIndex(index);
      }
    }

    public int firstIndexByValue(int value)
    {
      int index = -1;
      for (int i = 0; i < Length; i++)
      {
        if (value == DoubleNodeByIndex(i).Value)
        {
          index = i;
          break;
        }
      }

      return index;
    }

    public void Revers()
    {
      DoubleNode current = _root;
      DoubleNode tmpDoubleNode = new DoubleNode(0);

      while (current.Next != null)
      {
        tmpDoubleNode = current.Next;
        current.Next = tmpDoubleNode.Next;
        tmpDoubleNode.Next = _root;
        _root = tmpDoubleNode;

      }

      DoubleLinkedList tmpdoubleLinkedList = new DoubleLinkedList(DoubleLinkedListTomMassInt());
      _root = tmpdoubleLinkedList._root;
      _tail = tmpdoubleLinkedList._tail;
    }

    private int[] DoubleLinkedListTomMassInt()
    {
      int[] tmpArray = new int[Length];
      for (int i = 0; i < Length; i++)
      {
        tmpArray[i]=DoubleNodeByIndex(i).Value;
      }
      return tmpArray;
    }

    public int MaxValue()
    {
      if (Length == 0)
      {
        throw new ArgumentNullException("лист не имеет элементов");
      }

      int maxValue = DoubleNodeByIndex(0).Value;

      for (int i = 1; i < Length; i++)
      {
        if (maxValue < DoubleNodeByIndex(i).Value)
        {
          maxValue = DoubleNodeByIndex(i).Value;
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

      int minValue = DoubleNodeByIndex(0).Value;

      for (int i = 1; i < Length; i++)
      {
        if (minValue > DoubleNodeByIndex(i).Value)
        {
          minValue = DoubleNodeByIndex(i).Value;
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

      int maxValue = DoubleNodeByIndex(0).Value;
      int tmpindex = 0;

      for (int i = 0; i < Length; i++)
      {
        if (maxValue < DoubleNodeByIndex(i).Value)
        {
          maxValue = DoubleNodeByIndex(i).Value;
          tmpindex = i;
        }
      }

      return tmpindex;
    }

    public int IndexOfMinValue()
    {
      if (Length == 0)
      {
        throw new ArgumentNullException("лист не имеет элементов");
      }

      int minValue = DoubleNodeByIndex(0).Value;

      for (int i = 0; i < Length; i++)
      {
        if (minValue > DoubleNodeByIndex(i).Value)
        {
          minValue = i;
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

          if (DoubleNodeByIndex(j + 1).Value < DoubleNodeByIndex(j).Value)
          {
            tmp = DoubleNodeByIndex(j).Value;
            DoubleNodeByIndex(j).Value = DoubleNodeByIndex(j + 1).Value;
            DoubleNodeByIndex(j + 1).Value = tmp;
          }
        }
      }
    }

    public void SortDescending()
    {
      for (int i = 1; i < Length; i++)
      {
        for (int j = 0; j < Length - i; j++)
        {
          int tmp;

          if (DoubleNodeByIndex(j + 1).Value > DoubleNodeByIndex(j).Value)
          {
            tmp = DoubleNodeByIndex(j).Value;
            DoubleNodeByIndex(j).Value = DoubleNodeByIndex(j + 1).Value;
            DoubleNodeByIndex(j + 1).Value = tmp;
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
      for (int i = 1; i < Length; i++)
      {
        if (DoubleNodeByIndex(i).Value == value)
        {
          RemoveByIndex(i);

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
        if (DoubleNodeByIndex(i).Value == value)
        {
          RemoveByIndex(i);
          count++;
          i--;
        }

      }

      return count;
    }

    public void AddLinkedListInEnd(DoubleLinkedList insertLinkedList)
    {
      AddLinkedListByIndex(Length, insertLinkedList);
    }

    public void AddArrayListByZeroIndex(DoubleLinkedList insertLinkedList)
    {
      AddLinkedListByIndex(0, insertLinkedList);
    }

    public void AddLinkedListByIndex(int index, DoubleLinkedList insertLinkedList)
    {
      Length += insertLinkedList.Length;
      DoubleNode tmpNode = DoubleNodeByIndex(index);
      int[] tmpArray = new int[Length];
      DoubleNodeByIndex(index - 1).Next = insertLinkedList._root;

      DoubleNodeByIndex(index + insertLinkedList.Length - 1).Next = tmpNode;

      for (int i = 0; i < Length; i++)
      {
        tmpArray[i] = DoubleNodeByIndex(i).Value;
      }
      DoubleLinkedList tmpLinkedList = new DoubleLinkedList(tmpArray);

      _root = tmpLinkedList._root;
      _tail = tmpLinkedList._tail;

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

      currentThis = _tail;
      currentList = list._tail;

      while (!(currentThis is null))
      {
        if (currentThis.Value != currentList.Value)
        {
          return false;
        }

        currentList = currentList.Prev;
        currentThis = currentThis.Prev;
      }
      return true;
    }

    private DoubleNode DoubleNodeByIndex(int index)
    {
      if (index > Length - 1)
      {
        throw new ArgumentOutOfRangeException("netu indexa");
      }
      DoubleNode tmpDoubleNode = new DoubleNode(0);
      bool indexMoreHalf = index >= Length / 2;

      if (indexMoreHalf)
      {
        tmpDoubleNode = _tail;
        for (int i = 0; i < Length - index - 1; i++)
        {
          tmpDoubleNode = tmpDoubleNode.Prev;
        }
      }
      else
      {
        tmpDoubleNode = _root;
        for (int i = 0; i < index; i++)
        {
          tmpDoubleNode = tmpDoubleNode.Next;
        }
      }
      return tmpDoubleNode;
    }
  }
}


