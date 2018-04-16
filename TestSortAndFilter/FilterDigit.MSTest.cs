using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using SortAndFilterArray;

namespace SortAndFilterArray.Test
{
    /// <summary>
    /// Class for test SlowFilterDigit and QuickFilterDigit with MSUnitTest
    /// </summary>
    [TestClass]
    public class FilterDigitMSTest
    {
        /// <summary>
        /// Test with valid data for the method SlowFilterDigit
        /// </summary>
        [TestMethod]
        public void MSTest_FilterDigit_With_Valid_Data()
        {
            var arrayForTest = new int[1000000];
            Random random = new Random(0);
            for (int itemArray = 0; itemArray < arrayForTest.Length; itemArray++)
            {
                arrayForTest[itemArray] = random.Next(0, 100);
            }

            var filter = 222;

            var filterPredicate = new FilterAndChange.FilterArrayIntegerNumbers(filter);

            foreach (int item in arrayForTest.FilterDigit(filterPredicate))
            {
                Assert.IsTrue(FilterAndChange.IsNumberFilterHelper(item, filterPredicate));
            }
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentNullException 
        /// in method FilterDigit if the erenced array erence ers to null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MSTest_FilterDigit_Expected_ArgumentNullException()
        {
            int[] inputArray = null;

            var filter = 6;

            var filterPredicate = new FilterAndChange.FilterArrayIntegerNumbers(filter);

            foreach (int item in inputArray.FilterDigit(filterPredicate))
            {
                Assert.IsTrue(FilterAndChange.IsNumberFilterHelper(item, filterPredicate));
            }
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method FilterDigit if the erenced array erence ers to array with 0 element.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MSTest_FilterDigit_If_Input_Array_Length_Is_0()
        {
            int[] inputArray = new int[0];

            var filter = 6;

            var filterPredicate = new FilterAndChange.FilterArrayIntegerNumbers(filter);

            foreach (int item in inputArray.FilterDigit(filterPredicate))
            {
                Assert.IsTrue(FilterAndChange.IsNumberFilterHelper(item, filterPredicate));
            }
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method FilterDigit if the instance class FilterArrayIntegerNumbers is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MSTest_FilterDigit_If_Input_Number_Less_Then_0()
        {
            var filter = -1;

            var filterPredicate = new FilterAndChange.FilterArrayIntegerNumbers(filter);
        }
    }
}
