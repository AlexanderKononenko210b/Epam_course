using System;
using NUnit.Framework;
using System.Diagnostics;
using SortAndFilterArray;

namespace NUnitTestFilterDigit
{
    /// <summary>
    /// Class for test SlowFilterDigit and QuickFilterDigit with NUnitTest
    /// </summary>
    [TestFixture]
    public class FilterDigitNUnitTest
    {
        /// <summary>
        /// Test with valid data for the method SlowFilterDigit
        /// </summary>
        [Test]
        public void NUnitTest_SlowFilterDigit_With_Valid_Data()
        {
            var arrayForTest = new int[1000000];
            Random random = new Random(0);
            for (int itemArray = 0; itemArray < arrayForTest.Length; itemArray++)
            {
                arrayForTest[itemArray] = random.Next(0, 100);
            }

            var outputArray = SortAndFilter.SlowFilterDigit(arrayForTest, 6);

            for (int itemArray = 0; itemArray < outputArray.Length; itemArray++)
            {
                Assert.IsTrue(SortAndFilter.IsDigit(outputArray[itemArray], 6));
            }
        }

        /// <summary>
        /// Test with valid data for the method QuickFilterDigit
        /// </summary>
        [Test]
        public void NUnitTest_QuickFilterDigit_With_Valid_Data()
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
        [Test]
        public void NUnitTest_SlowFilterDigit_And_QuickFilterDigit_Measurement_Time()
        {
            var arrayForTest = new int[1000000];
            Random random = new Random(0);
            for (int itemArray = 0; itemArray < arrayForTest.Length; itemArray++)
            {
                arrayForTest[itemArray] = random.Next(0, 100);
            }

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            var outputArrayQuick = SortAndFilter.SlowFilterDigit(arrayForTest, 6);

            stopwatch.Stop();

            var slowTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();

            stopwatch.Start();

            var outputArraySlow = SortAndFilter.QuickFilterDigit(arrayForTest, 6);

            stopwatch.Stop();

            var quickTime = stopwatch.ElapsedMilliseconds;

            Assert.IsTrue(slowTime > quickTime);
        }

        /// <summary>
        /// Test method SlowFilterDigit if expected ArgumentNullException
        /// </summary>
        /// <param name="inputArray">input array</param>
        /// <param name="digit">digit</param>
        [TestCase(null, 10)]
        public void NUnitTest_SlowFilterDigit_Expected_ArgumentNullException(int[] inputArray, int digit)
            => Assert.Throws<ArgumentNullException>(() => SortAndFilter.SlowFilterDigit(inputArray, digit));

        /// <summary>
        /// Test method QuickFilterDigit if expected ArgumentNullException
        /// </summary>
        /// <param name="inputArray">input array</param>
        /// <param name="digit">digit</param>
        [TestCase(null, 10)]
        public void NUnitTest_QuickFilterDigit_Expected_ArgumentNullException(int[] inputArray, int digit)
            => Assert.Throws<ArgumentNullException>(() => SortAndFilter.QuickFilterDigit(inputArray, digit));

        /// <summary>
        /// Test method SlowFilterDigit if expected ArgumentOutOfRangeException
        /// </summary>
        /// <param name="inputArray">input array</param>
        /// <param name="digit">digit</param>
        [TestCase(new int[0], -1)]
        [TestCase(new int[5] { 12, 45, 6, 5, 8 }, -1)]
        [TestCase(new int[5] { 12, 45, 6, 5, 8 }, 10)]
        public void NUnitTest_SlowFilterDigit_Expected_ArgumentOutOfRangeException(int[] inputArray, int digit)
            => Assert.Throws<ArgumentOutOfRangeException>(() => SortAndFilter.SlowFilterDigit(inputArray, digit));

        /// <summary>
        /// Test method QuickFilterDigit if expected ArgumentOutOfRangeException
        /// </summary>
        /// <param name="inputArray">input array</param>
        /// <param name="digit">digit</param>
        [TestCase(new int[0], -1)]
        [TestCase(new int[5] { 12, 45, 6, 5, 8 }, -1)]
        [TestCase(new int[5] { 12, 45, 6, 5, 8 }, 10)]
        public void NUnitTest_QuickFilterDigit_Expected_ArgumentOutOfRangeException(int[] inputArray, int digit)
            => Assert.Throws<ArgumentOutOfRangeException>(() => SortAndFilter.QuickFilterDigit(inputArray, digit));
    }
}
