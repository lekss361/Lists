using NUnit.Framework;

namespace List.Tests
{
    public class ArrayListTests
    {

        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 2, 1, 2, 3 })]

        public void AddInZeroIndexTest(int[] actualAr, int value, int[] arExpected)
        {
            ArrayList actual = new ArrayList(actualAr);
            ArrayList expected = new ArrayList(arExpected);

            actual.AddByZeroIndex(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 5)]
        public void AddByIndexTest(int index, int value)
        {
            ArrayList actual = new ArrayList(new int[] { 1, 2, 3, 4, 5 });
            actual.AddByIndex(index, value);
            ArrayList expected = new ArrayList(new int[] { 1, 2, 3, 5, 4, 5 });
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2)]
        public void RemoveByIndexTest(int index)
        {
            ArrayList actual = new ArrayList(new int[] { 1, 2, 3, 4, 5 });
            actual.RemoveByIndex(index);
            ArrayList expected = new ArrayList(new int[] { 1, 2, 4, 5 });
            Assert.AreEqual(expected, actual);
        }

        //[TestCase]
        //public void DownSizeTest()
        //{
        //  ArrayList actual = new ArrayList(new int[] { 1, 2, 3 });

        //  actual.Add(3);
        //  actual.Add(4);

        //  actual.Add(5);

        //  actual.Add(6);

        //  actual.RemoveByIndex(0);
        //  actual.RemoveByIndex(0);
        //  actual.RemoveByIndex(0);
        //  actual.RemoveByIndex(0);

        //  actual.DownSize();

        //  Assert.AreEqual(actual.Capacity, 4);
        //}

        [TestCase(3)]
        public void ClearLastXTest(int startIndex)
        {
            ArrayList actual = new ArrayList(new int[] { 1, 2, 3, 4, 5 });
            actual.ClearLastX(startIndex);
            ArrayList expected = new ArrayList(new int[] { 1, 2, });
            Assert.AreEqual(expected, actual);
        }
        [TestCase(6, 2)]
        [TestCase(4, 1)]
        [TestCase(5, 4)]
        public void FirstIndexByValueTest(int key, int expected)
        {
            ArrayList ar = new ArrayList(new int[] { 1, 4, 6, 2, 5, 4 });
            int actual = ar.FirstIndexByValue(key);
            Assert.AreEqual(expected, actual);

        }
        [TestCase(new int[] { 1, 4, 6, 2, 5, 4 }, new int[] { 4, 5, 2, 6, 4, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        public void ReverseTest(int[] array, int[] expectedAr)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedAr);

            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 4, 6, 2, 5, 4 }, 6)]
        public void MaxValueTest(int[] array, int expected)
        {
            ArrayList tmpArray = new ArrayList(array);

            int actual = tmpArray.MaxValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 4, 6, 2, 5, 4 }, 2)]
        public void MinValueTest(int[] array, int expected)
        {
            ArrayList tmpArray = new ArrayList(array);

            int actual = tmpArray.MinValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 4, 6, 2, 5, 4 }, 2)]
        public void IndexOfMaxValueTest(int[] array, int expected)
        {
            ArrayList tmpArray = new ArrayList(array);

            int actual = tmpArray.IndexOfMaxValue();

            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { 3, 4, 6, 2, 5, 4 }, 3)]
        public void IndexOfMinValue(int[] array, int expected)
        {
            ArrayList tmpArray = new ArrayList(array);

            int actual = tmpArray.IndexOfMinValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 4, 6, 2, 5, 4 }, new int[] { 2, 3, 4, 4, 5, 6 })]
        public void SortAscendingTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.SortAscending();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 4, 6, 2, 5, 4 }, new int[] { 6, 5, 4, 4, 3, 2 })]
        public void SortDescendingTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.SortDescending();

            Assert.AreEqual(expected, actual);
        }
        [TestCase(4, new int[] { 3, 4, 6, 2, 5, 4 }, new int[] { 3, 6, 2, 5, 4 })]
        public void RemoveByValueFisrtTest(int value, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.RemoveByValueFisrt(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, new int[] { 3, 4, 6, 4,  2, 5, 4 }, new int[] { 3, 6, 2, 5 } , 3)]
        public void RemoveByValueAllTest(int value, int[] array, int[] expectedArray, int expectedCount)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            int actualCount = actual.RemoveByValueAll(value);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedCount, actualCount);

        }

        [TestCase( new int[] { 1,2,3,4 }, new int[] { 5,6,7,8,9,10 }, new int[] { 1,2,3,4,5,6,7,8,9,10 })] // что тут должно быт на первом месте, тот массив в который мы вставляем или тот, который передаем?
        public void AddArrayListInEndTest( int[] array, int[] insertArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList insert = new ArrayList(insertArray);

            actual.AddArrayListInEnd(insert);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 5, 6, 7, 8, 9, 10, 3 , 4 })]
        [TestCase(3, new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 5, 6, 7, 8, 9, 10, 4 })]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5, 6,  }, new int[] { 9,9,9 }, new int[] { 1, 2, 3, 9,9,9, 4, 5, 6,  })]
        public void AddArrrayListAtIndexTest(int index, int[] array , int[] insertArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList insert = new ArrayList(insertArray);

             actual.AddArrrayListAtIndex(index, insert);

            Assert.AreEqual(expected, actual);
        }


    }
} 