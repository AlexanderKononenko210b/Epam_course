using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortAndFilterArray;
using System.Diagnostics;

namespace MSUnitFilterDigit
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
        public void MSTest_SlowFilterDigit_OutputArrayReturned_With_Valid_Data()
        {
            var arrayForTest = new int[1000000];
            Random random = new Random(0);
            for (int itemArray = 0; itemArray < arrayForTest.Length; itemArray++)
            {
                arrayForTest[itemArray] = random.Next(0, 100);
            }

            var outputArray = SortAndFilter.SlowFilterDigit(arrayForTest, 6);

            for(int itemArray = 0; itemArray < outputArray.Length; itemArray++)
            {
                Assert.IsTrue(SortAndFilter.IsDigit(outputArray[itemArray], 6));
            }
        }

        /// <summary>
        /// Test with valid data for the method QuickFilterDigit
        /// </summary>
        [TestMethod]
        public void MSTest_QuickFilterDigitinputArrayAsArgument_OutputArrayReturned_With_Valid_Data()
        {
            var arrayForTest = new int[1000000];
            Random random = new Random(0);
            for (int itemArray = 0; itemArray < arrayForTest.Length; itemArray++)
            {
                arrayForTest[itemArray] = random.Next(0, 100);
            }

            var outputArray = SortAndFilter.QuickFilterDigit(arrayForTest, 6);

            for (int itemArray = 0; itemArray < outputArray.Length; itemArray++)
            {
                Assert.IsTrue(SortAndFilter.IsDigit(outputArray[itemArray], 6));
            }
        }

        /// <summary>
        /// Test to check the execution time of methods SlowFilterDigit and QuickFilterDigit. 
        /// It is expected that the method QuickFilterDigit will be faster by the execution time.
        /// </summary>
        [TestMethod]
        public void MSTest_SlowFilterDigit_And_QuickFilterDigitinputArrayAsArgument_OutputArrayReturned_For_Measurement_Time()
        {
            var arrayForTest = new int[1000000];
            Random random = new Random(0);
            for (int itemArray = 0; itemArray < arrayForTest.Length; itemArray++)
            {
                arrayForTest[itemArray] = random.Next(0, 100);
            }

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            var outputSlowFilter = SortAndFilter.SlowFilterDigit(arrayForTest, 6);

            stopwatch.Stop();

            var slowTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();

            stopwatch.Start();

            var outputQuickFilter = SortAndFilter.QuickFilterDigit(arrayForTest, 6);

            stopwatch.Stop();

            var quickTime = stopwatch.ElapsedMilliseconds;

            Assert.IsTrue(slowTime > quickTime);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentNullException 
        /// in method SlowFilterDigit if the erenced array erence ers to null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MSTest_SlowFilterDigit_If_Input_Array_Is_Null()
        {
            int[] inputArray = null;

            var outputArray = SortAndFilter.SlowFilterDigit(inputArray, 6);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentNullException 
        /// in method QuickFilterDigit if the erenced array erence ers to null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MSTest_QuickFilterDigit_If_Input_Array_Is_Null()
        {
            int[] inputArray = null;

            var outputArray = SortAndFilter.QuickFilterDigit(inputArray, 6);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method SlowFilterDigit if the erenced array erence ers to array with 0 element.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MSTest_SlowFilterDigit_If_Input_Array_Length_Is_0()
        {
            int[] inputArray = new int[0];

            var outputArray = SortAndFilter.SlowFilterDigit(inputArray, 6);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method QuickFilterDigit if the erenced array erence ers to array with 0 element.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MSTest_QuickFilterDigit_If_Input_Array_Length_Is_0()
        {
            int[] inputArray = new int[0];

            var outputArray = SortAndFilter.QuickFilterDigit(inputArray, 6);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method SlowFilterDigit if the digit less then 0.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MSTest_SlowFilterDigit_If_Input_Number_Less_Then_0()
        {
            int number = -1;

            int[] inputArray = new int[5] { 12, 45, 6, 5, 8 };

            var outputArray = SortAndFilter.SlowFilterDigit(inputArray, number);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method QuickFilterDigit if the digit less then 0.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MSTest_QuickFilterDigit_If_Input_Number_Less_Then_0()
        {
            int number = -1;

            int[] inputArray = new int[5] { 12, 45, 6, 5, 8 };

            var outputArray = SortAndFilter.QuickFilterDigit(inputArray, number);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method SlowFilterDigit if the digit more then 10.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MSTest_SlowFilterDigit_If_Input_Number_More_Then_10()
        {
            int number = 10;

            int[] inputArray = new int[5] { 12, 45, 6, 5, 8 };

            var outputArray = SortAndFilter.SlowFilterDigit(inputArray, number);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method QuickFilterDigit if the digit more then 10.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MSTest_QuickFilterDigit_If_Input_Number_More_Then_10()
        {
            int number = 10;

            int[] inputArray = new int[5] { 12, 45, 6, 5, 8 };

            var outputArray = SortAndFilter.QuickFilterDigit(inputArray, number);
        }
    }
}
