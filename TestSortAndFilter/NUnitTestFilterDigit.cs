using System;
using NUnit.Framework;
using System.Diagnostics;
using SortAndFilterArray;

namespace NUnitTestFilterDigit
{
    [TestFixture]
    public class NUnitTestFilterDigit
    {
        /// <summary>
        /// input array
        /// </summary>
        private int[] _inputArray;

        /// <summary>
        /// output array
        /// </summary>
        private int[] _outputArray;

        /// <summary>
        /// field type stopwatch
        /// </summary>
        private Stopwatch _watch = new Stopwatch();

        /// <summary>
        /// Method initialize for create input array
        /// </summary>
        [SetUp]
        public void Initialize()
        {
            var arrayForTest = new int[100000];
            Random random = new Random(0);
            for (int itemArray = 0; itemArray < arrayForTest.Length; itemArray++)
            {
                arrayForTest[itemArray] = random.Next(0, 100);
            }
            _inputArray = arrayForTest;
        }

        /// <summary>
        /// Test with valid data for the method SlowFilterDigit
        /// </summary>
        [Test]
        public void NUnitTest_SlowFilterDigit_InputArrayAsArgument_OutputArrayReturned_With_Valid_Data()
        {
            _outputArray = SortAndFilter.SlowFilterDigit(_inputArray, 6);

            for (int itemArray = 0; itemArray < _outputArray.Length; itemArray++)
            {
                Assert.IsTrue(SortAndFilter.IsDigit(_outputArray[itemArray], 6));
            }
        }

        /// <summary>
        /// Test with valid data for the method QuickFilterDigit
        /// </summary>
        [Test]
        public void NUnitTest_QuickFilterDigit_InputArrayAsArgument_OutputArrayReturned_With_Valid_Data()
        {
            _outputArray = SortAndFilter.QuickFilterDigit(_inputArray, 6);

            for (int itemArray = 0; itemArray < _outputArray.Length; itemArray++)
            {
                Assert.IsTrue(SortAndFilter.IsDigit(_outputArray[itemArray], 6));
            }
        }

        /// <summary>
        /// Test to check the execution time of methods SlowFilterDigit and QuickFilterDigit. 
        /// It is expected that the method QuickFilterDigit will be faster by the execution time.
        /// </summary>
        [Test]
        public void NUnitTest_SlowFilterDigit_And_QuickFilterDigit_InputArrayAsArgument_OutputArrayReturned_For_Measurement_Time()
        {
            _watch.Reset();
            _watch.Start();
            var _outputSlowFilter = SortAndFilter.SlowFilterDigit(_inputArray, 6);
            _watch.Stop();
            var slowTime = _watch.ElapsedMilliseconds;
            _watch.Reset();
            _watch.Start();
            var _outputQuickFilter = SortAndFilter.SlowFilterDigit(_inputArray, 6);
            _watch.Stop();
            var quickTime = _watch.ElapsedMilliseconds;
            Assert.IsTrue(slowTime > quickTime);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentNullException 
        /// in method SlowFilterDigit if the referenced array reference refers to null.
        /// </summary>
        [Test]
        public void NUnitTest_SlowFilterDigit_If_Input_Array_Is_Null()
        {
            this._inputArray = null;

            Assert.Throws<ArgumentNullException>(() => SortAndFilter.SlowFilterDigit(_inputArray, 6));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentNullException 
        /// in method QuickFilterDigit if the referenced array reference refers to null.
        /// </summary>
        [Test]
        public void NUnitTest_QuickFilterDigit_If_Input_Array_Is_Null()
        {
            _inputArray = null;

            Assert.Throws<ArgumentNullException>(() => SortAndFilter.QuickFilterDigit(_inputArray, 6));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method SlowFilterDigit if the referenced array reference refers to array with 0 element.
        /// </summary>
        [Test]
        public void NUnitTest_SlowFilterDigit_If_Input_Array_Length_Is_0()
        {
            _inputArray = new int[0];

            Assert.Throws<ArgumentOutOfRangeException>(() => SortAndFilter.SlowFilterDigit(_inputArray, 6));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method QuickFilterDigit if the referenced array reference refers to array with 0 element.
        /// </summary>
        [Test]
        public void NUnitTest_QuickFilterDigit_If_Input_Array_Length_Is_0()
        {
            _inputArray = new int[0];

            Assert.Throws<ArgumentOutOfRangeException>(() => SortAndFilter.QuickFilterDigit(_inputArray, 6));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method SlowFilterDigit if the digit less then 0.
        /// </summary>
        [Test]
        public void NUnitTest_SlowFilterDigit_If_Input_Number_Less_Then_0()
        {
            int number = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => SortAndFilter.SlowFilterDigit(_inputArray, number));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method QuickFilterDigit if the digit less then 0.
        /// </summary>
        [Test]
        public void NUnitTest_QuickFilterDigit_If_Input_Number_Less_Then_0()
        {
            int number = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => SortAndFilter.QuickFilterDigit(_inputArray, number));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method SlowFilterDigit if the digit more then 10.
        /// </summary>
        [Test]
        public void NUnitTest_SlowFilterDigit_If_Input_Number_More_Then_10()
        {
            int number = 10;

            Assert.Throws<ArgumentOutOfRangeException>(() => SortAndFilter.SlowFilterDigit(_inputArray, number));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method QuickFilterDigit if the digit more then 10.
        /// </summary>
        [Test]
        public void NUnitTest_QuickFilterDigit_If_Input_Number_More_Then_10()
        {
            int number = 10;

            Assert.Throws<ArgumentOutOfRangeException>(() => SortAndFilter.QuickFilterDigit(_inputArray, number));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method SlowFilterDigit if the digit more then Int.MaxValue.
        /// </summary>
        [Test]
        public void NUnitTest_SlowFilterDigit_If_Input_Number_More_Then_MaxValue()
        {
            Random random = new Random(0);

            Assert.Throws<ArgumentOutOfRangeException>(() => SortAndFilter.SlowFilterDigit(_inputArray, random.Next(20000000, 200000000)));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method QuickFilterDigit if the digit more then Int.MaxValue.
        /// </summary>
        [Test]
        public void NUnitTest_QuickFilterDigit_If_Input_Number_More_Then_Int_MaxValue()
        {
            Random random = new Random(0);

            Assert.Throws<ArgumentOutOfRangeException>(() => SortAndFilter.QuickFilterDigit(_inputArray, random.Next(20000000, 200000000)));
        }

        /// <summary>
        /// /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method SlowFilterDigit if the digit less then Int.MinValue.
        /// </summary>
        /// </summary>
        [Test]
        public void NUnitTest_SlowFilterDigit_If_Input_Number_Less_Then_Int_MinValue()
        {
            Random random = new Random(0);

            Assert.Throws<ArgumentOutOfRangeException>(() => SortAndFilter.SlowFilterDigit(_inputArray, random.Next(20000000, 200000000)));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method QuickFilterDigit if the digit less then Int.MinValue.
        /// </summary>
        [Test]
        public void NUnitTest_QuickFilterDigit_If_Input_Number_Less_Then_MinValue()
        {
            Random random = new Random(0);

            Assert.Throws<ArgumentOutOfRangeException>(() => SortAndFilter.QuickFilterDigit(_inputArray, random.Next(-20000000, -200000000)));
        }
    }
}
