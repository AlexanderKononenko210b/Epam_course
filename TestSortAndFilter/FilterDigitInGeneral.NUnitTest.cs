using System;
using NUnit.Framework;
using SortAndFilterArray;

namespace TestSortAndFilter
{
    [TestFixture]
    public class FilterDigitInGeneralNUnitTest
    {
        /// <summary>
        /// Test with valid data for the method SlowFilterDigit
        /// </summary>
        [Test]
        public void NUnitTest_FilterDigit_In_General_With_Valid_Data()
        {
            var arrayForTest = new int[1000000];
            Random random = new Random(0);
            for (int itemArray = 0; itemArray < arrayForTest.Length; itemArray++)
            {
                arrayForTest[itemArray] = random.Next(0, 100000);
            }

            var filter = 6;

            var filterPredicate = new FilterAndChange.FilterArrayIntegerNumbers(filter);

            foreach (int item in arrayForTest.FilterDigit(filterPredicate.IsMatch))
            {
                Assert.IsTrue(FilterAndChange.FilterInGeneralHelper(item, filterPredicate.IsMatch));
            }
        }

        /// <summary>
        /// Test method FilterDigit if expected ArgumentNullException
        /// </summary>
        [Test]
        public void NUnitTest_FilterDigit_In_General_Expected_ArgumentNullException()
        {
            int[] inputArray = null;

            var filter = 6;

            var filterPredicate = new FilterAndChange.FilterArrayIntegerNumbers(filter);

            Assert.Throws<ArgumentNullException>(() => FilterAndChange.FilterDigit(inputArray, filterPredicate));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method FilterDigit if the erenced array erence ers to array with 0 element.
        /// </summary>
        [Test]
        public void NUnitTest_FilterDigit_In_General_If_Input_Array_Length_Is_0()
        {
            int[] inputArray = new int[0];

            var filter = 6;

            var filterPredicate = new FilterAndChange.FilterArrayIntegerNumbers(filter);

            Assert.Throws<ArgumentOutOfRangeException>(() => FilterAndChange.FilterDigit(inputArray, filterPredicate));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method FilterDigit if the instance class FilterArrayIntegerNumbers is null.
        /// </summary>
        [Test]
        public void NUnitTest_FilterDigit_InGeneral_If_Input_Number_Less_Then_0()
        {
            var filter = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => new FilterAndChange.FilterArrayIntegerNumbers(filter));
        }
    }
}
