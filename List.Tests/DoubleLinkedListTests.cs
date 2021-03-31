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

    [TestCase(0,new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
    [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] {1, 2, 4, 5 })]
    [TestCase(4, new int[] { 1, 2, 3, 4, 5 }, new int[] {1, 2, 3, 4 })]
    public void RemoveByIndexTest(int index,int[] array, int[] expectedArray)
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

    [TestCase(3, 3, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 1, 2,3, 6, 7, 8, 9 })]
    [TestCase(4, 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 5, 6, 7, 8, 9 })]
    [TestCase(2, 7, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 1, 2, 3, 4, 5,6,7 })]
    public void ClearByIndexXElementsTest(int x, int index, int[] array, int[] expectedArray)
    {
      DoubleLinkedList actual = new DoubleLinkedList(array);
      DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

      actual.ClearByIndexXElements(x, index);

      Assert.AreEqual(expected, actual);
    }

  }
}
