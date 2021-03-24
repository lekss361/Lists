using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;


namespace List.Tests
{
    class LinkedListTests
    {
        [TestCase(5, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5 })]
        public void AddTest(int value, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 2, 1, 2, 3 })]
        public void AddByZeroIndexTest(int[] actualAr, int value, int[] arExpected)
        {
            LinkedList actual = new LinkedList(actualAr);
            LinkedList expected = new LinkedList(arExpected);

            actual.AddByZeroIndex(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 5, 4, 5 })]
        public void AddByIndexTest(int index, int value, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        public void RemoveLastElementTest(int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveLastElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        public void RemoveFirstElementTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.RemoveFirstElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 4, 5 })]
        public void RemoveByIndexTest(int index, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3 })]
        public void RemoveXElementsByEndTest(int x, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveXElementsByEnd(x);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5 })]
        public void RemoveXElementsByStartTest(int x, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveXElementsByStart(x);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, 3, new int[] { 1, 2, 3, 4,5,6,7,8,9 }, new int[] { 1, 2, 3, 4, 8, 9 })]
        public void ClearByIndexXElements(int x, int startPoint, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.ClearByIndexXElements(x, startPoint);

            Assert.AreEqual(expected, actual);
        }
    }
}
