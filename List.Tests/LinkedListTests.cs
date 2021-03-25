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
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

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

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 4, 6, 2, 5, 4 }, new int[] { 4, 5, 2, 6, 4, 1 })]
        public void ReverseTest(int[] array, int[] expectedAr)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedAr);

            actual.Revers();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 4, 6, 2, 5, 4 }, 6)]
        public void MaxValueTest(int[] array, int expected)
        {
            LinkedList tmpArray = new LinkedList(array);

            int actual = tmpArray.MaxValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 4, 6, 2, 5, 4 }, 2)]
        public void MinValueTest(int[] array, int expected)
        {
            LinkedList tmpArray = new LinkedList(array);

            int actual = tmpArray.MinValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 4, 6, 2, 5, 4 }, 2)]
        public void IndexOfMaxValueTest(int[] array, int expected)
        {
            LinkedList tmpArray = new LinkedList(array);

            int actual = tmpArray.IndexOfMaxValue();

            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { 3, 4, 6, 2, 5, 4 }, 3)]
        public void IndexOfMinValueTest(int[] array, int expected)
        {
            LinkedList tmpArray = new LinkedList(array);

            int actual = tmpArray.IndexOfMinValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, new int[] { 3, 4, 6, 2, 5, 4 }, new int[] { 3, 6, 2, 5, 4 })]
        public void RemoveByValueFisrtTest(int value, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveByValueFisrt(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, new int[] { 3, 4, 6, 4, 2, 5, 4 }, new int[] { 3, 6, 2, 5 }, 3)]
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
