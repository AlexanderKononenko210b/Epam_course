using System;
using NUnit.Framework;

namespace SortAndFilterArray.Test
{
    [TestFixture]
    public class ChangeArrayOfNumbersNUnitTest
    {
        /// <summary>
        /// Test with valid data for the method ChangeArrayElements
        /// </summary>
        [Test]
        public void NUnitTest_ChangeArrayElements_With_Valid_Data()
        {
            var arrayForTest = new int[1000000];
            Random random = new Random(0);
            for (int itemArray = 0; itemArray < arrayForTest.Length; itemArray++)
            {
                arrayForTest[itemArray] = random.Next(0, 100000);
            }

            var powValue = 6;

            var condition = new FilterAndChange.ChangeNumber(powValue);

            var outputArray = FilterAndChange.ChangeArrayElements(arrayForTest, condition);

            Assert.IsTrue(FilterAndChange.IsNumberChangeHelper(arrayForTest, outputArray, condition));
        }

        /// <summary>
        /// Test method ChangeArrayElements if expected ArgumentNullException
        /// </summary>
        [Test]
        public void NUnitTest_ChangeArrayElements_Expected_ArgumentNullException()
        {
            int[] inputArray = null;

            var powValue = 6;

            var condition = new FilterAndChange.ChangeNumber(powValue);

            Assert.Throws<ArgumentNullException>(() => FilterAndChange.ChangeArrayElements(inputArray, condition));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method ChangeArrayElements if the erenced array erence ers to array with 0 element.
        /// </summary>
        [Test]
        public void NUnitTest_ChangeArrayElements_If_Input_Array_Length_Is_0()
        {
            int[] inputArray = new int[0];

            var powValue = 6;

            var condition = new FilterAndChange.ChangeNumber(powValue);

            Assert.Throws<ArgumentOutOfRangeException>(() => FilterAndChange.ChangeArrayElements(inputArray, condition));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method ChangeArrayElements if the instance class FilterArrayIntegerNumbers is null.
        /// </summary>
        [Test]
        public void NUnitTest_ChangeArrayElements_If_Input_Number_Less_Then_0()
        {
            var powValue = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => new FilterAndChange.ChangeNumber(powValue));
        }
    }
}
