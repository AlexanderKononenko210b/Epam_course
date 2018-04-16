using System;
using NUnit.Framework;

namespace SortAndFilterArray.Test
{
    /// <summary>
    /// Test in general method for change array using interface
    /// </summary>
    [TestFixture]
    public class InterfaceChangeArrayOfNumbersNUnitTest
    {
        /// <summary>
        /// Test with valid data for the method ChangeArrayElements using interface
        /// </summary>
        [Test]
        public void NUnitTest_Interface_ChangeArrayElements_With_Valid_Data()
        {
            var arrayForTest = new int[1000000];
            Random random = new Random(0);
            for (int itemArray = 0; itemArray < arrayForTest.Length; itemArray++)
            {
                arrayForTest[itemArray] = random.Next(0, 100000);
            }

            var powValue = 6;

            var condition = new FilterAndChange.ChangeNumber(powValue);

            var index = 0;

            foreach (int item in arrayForTest.ChangeArrayElements(condition))
            {
                Assert.IsTrue(FilterAndChange.IsNumberChangeHelper(arrayForTest[index++], item, condition));
            }
        }

        /// <summary>
        /// Test method ChangeArrayElements if expected ArgumentNullException
        /// </summary>
        [Test]
        public void NUnitTest_Interface_ChangeArrayElements_Expected_ArgumentNullException()
        {
            int[] inputArray = null;

            var powValue = 6;

            var condition = new FilterAndChange.ChangeNumber(powValue);

            Assert.Throws<ArgumentNullException>(() => inputArray.ChangeArrayElements(condition));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method ChangeArrayElements if the erenced array erence ers to array with 0 element.
        /// </summary>
        [Test]
        public void NUnitTest_Interface_ChangeArrayElements_If_Input_Array_Length_Is_0()
        {
            int[] inputArray = new int[0];

            var powValue = 6;

            var condition = new FilterAndChange.ChangeNumber(powValue);

            Assert.Throws<ArgumentOutOfRangeException>(() => inputArray.ChangeArrayElements(condition));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method ChangeArrayElements if the instance class FilterArrayIntegerNumbers is null.
        /// </summary>
        [Test]
        public void NUnitTest_Interface_ChangeArrayElements_If_Input_Number_Less_Then_0()
        {
            var powValue = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => new FilterAndChange.ChangeNumber(powValue));
        }
    }
}
