using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace List.Tests
{
  class DoubleLinkedListTests
  {
    [TestCase(5, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5 })]
    [TestCase(8, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 8 })]
    [TestCase(7, new int[] { }, new int[] { 7 })]
    public void AddTest(int value, int[] array, int[] expectedArray)
    {
      DoubleLinkedList actual = new DoubleLinkedList(array);
      DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

      actual.Add(value);

      Assert.AreEqual(expected, actual);
    }

    [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 2, 1, 2, 3 })]
    [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { 3, 1, 2, 3 })]
    [TestCase(new int[] { }, 4, new int[] { 4 })]
    public void AddByZeroIndexTest(int[] actualAr, int value, int[] arExpected)
    {
      DoubleLinkedList actual = new DoubleLinkedList(actualAr);
      DoubleLinkedList expected = new DoubleLinkedList(arExpected);

      actual.AddByZeroIndex(value);

      Assert.AreEqual(expected, actual);
    }

    [TestCase(3, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 5, 4, 5 })]
    [TestCase(0, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 1, 2, 3, 4, 5 })]
    [TestCase(4, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 5 })]
    [TestCase(0, 5, new int[] { }, new int[] { 5 })]
    public void AddByIndexTest(int index, int value, int[] array, int[] expectedArray)
    {
      DoubleLinkedList actual = new DoubleLinkedList(array);
      DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

      actual.AddByIndex(index, value);

      Assert.AreEqual(expected, actual);
    }

    [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
    public void RemoveLastElementTest(int[] array, int[] expectedArray)
    {
      DoubleLinkedList actual = new DoubleLinkedList(array);
      DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

      actual.RemoveLastElement();

      Assert.AreEqual(expected, actual);
    }

    [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
    public void RemoveFirstTest(int[] array, int[] expectedArray)
    {
      DoubleLinkedList actual = new DoubleLinkedList(array);
      DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

      actual.RemoveFirst();

      Assert.AreEqual(expected, actual);
    }

    [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
    [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 4, 5 })]
    [TestCase(4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
    public void RemoveByIndexTest(int index, int[] array, int[] expectedArray)
    {
      DoubleLinkedList actual = new DoubleLinkedList(array);
      DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

      actual.RemoveByIndex(index);

      Assert.AreEqual(expected, actual);
    }

    [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3 })]
    [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
    [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
    public void RemoveXElementsByEndTest(int x, int[] array, int[] expectedArray)
    {
      DoubleLinkedList actual = new DoubleLinkedList(array);
      DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

      actual.RemoveXElementsByEnd(x);

      Assert.AreEqual(expected, actual);
    }

    [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5 })]
    [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
    [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
    public void RemoveXElementsByStartTest(int x, int[] array, int[] expectedArray)
    {
      DoubleLinkedList actual = new DoubleLinkedList(array);
      DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

      actual.RemoveXElementsByStart(x);

      Assert.AreEqual(expected, actual);
    }

    [TestCase(3, 3, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 1, 2, 3, 7, 8, 9 })]
    [TestCase(4, 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 5, 6, 7, 8, 9 })]
    [TestCase(2, 7, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
    public void ClearByIndexXElementsTest(int x, int index, int[] array, int[] expectedArray)
    {
      DoubleLinkedList actual = new DoubleLinkedList(array);
      DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

      actual.ClearByIndexXElements(x, index);

      Assert.AreEqual(expected, actual);
    }

    [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
    [TestCase(new int[] { 1, 4, 6, 2, 5, 4 }, new int[] { 4, 5, 2, 6, 4, 1 })]
    public void ReverseTest(int[] array, int[] expectedAr)
    {
      DoubleLinkedList actual = new DoubleLinkedList(array);
      DoubleLinkedList expected = new DoubleLinkedList(expectedAr);

      actual.Revers();

      Assert.AreEqual(expected, actual);
    }

    [TestCase(4, new int[] { 3, 4, 6, 4, 2, 5, 4 }, new int[] { 3, 6, 2, 5 }, 3)]
    [TestCase(4, new int[] { 4, 4, 4 }, new int[] { }, 3)]
    public void RemoveByValueAllTest(int value, int[] array, int[] expectedArray, int expectedCount)
    {
      LinkedList actual = new LinkedList(array);
      LinkedList expected = new LinkedList(expectedArray);

      int actualCount = actual.RemoveByValueAll(value);

      Assert.AreEqual(expected, actual);
      Assert.AreEqual(expectedCount, actualCount);
    }

    [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })] // что тут должно быт на первом месте, тот массив в который мы вставляем или тот, который передаем?
    public void AddArrayListInEndTest(int[] array, int[] insertArray, int[] expectedArray)
    {
      LinkedList actual = new LinkedList(array);
      LinkedList expected = new LinkedList(expectedArray);
      LinkedList insert = new LinkedList(insertArray);

      actual.AddLinkedListInEnd(insert);

      Assert.AreEqual(expected, actual);
    }

    [TestCase(2, new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 5, 6, 7, 8, 9, 10, 3, 4 })]
    [TestCase(3, new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 5, 6, 7, 8, 9, 10, 4 })]
    [TestCase(3, new int[] { 1, 2, 3, 4, 5, 6, }, new int[] { 9, 9, 9 }, new int[] { 1, 2, 3, 9, 9, 9, 4, 5, 6, })]
    public void AddArrayListByIndexTest(int index, int[] array, int[] insertArray, int[] expectedArray)
    {
      LinkedList actual = new LinkedList(array);
      LinkedList expected = new LinkedList(expectedArray);
      LinkedList insert = new LinkedList(insertArray);

      actual.AddLinkedListByIndex(index, insert);

      Assert.AreEqual(expected, actual);
    }

  }
}
