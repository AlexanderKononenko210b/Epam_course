using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortAndFilterArray;
using System.Diagnostics;

namespace MSUnitFilterDigit
{
    [TestClass]
    public class MSUnitTestFilterDigit
    {
        /// <summary>
        /// input array
        /// </summary>
        private int[] _inputArray;

        /// <summary>
        /// field type stopwatch
        /// </summary>
        private Stopwatch _watch = new Stopwatch();

        /// <summary>
        /// Constructor for create instance of MSUnitTestFilterDigit class
        /// </summary>
        public MSUnitTestFilterDigit()
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
        [TestMethod]
        public void MsTest_SlowFilterDigit_InputArrayAsArgument_OutputArrayReturned_With_Valid_Data()
        {
            SortAndFilter.SlowFilterDigit(ref _inputArray, 6);

            for(int itemArray = 0; itemArray < _inputArray.Length; itemArray++)
            {
                Assert.IsTrue(SortAndFilter.IsDigit(_inputArray[itemArray], 6));
            }
        }

        /// <summary>
        /// Test with valid data for the method QuickFilterDigit
        /// </summary>
        [TestMethod]
        public void MsTest_QuickFilterDigit_InputArrayAsArgument_OutputArrayReturned_With_Valid_Data()
        {
            SortAndFilter.QuickFilterDigit(ref _inputArray, 6);

            for (int itemArray = 0; itemArray < _inputArray.Length; itemArray++)
            {
                Assert.IsTrue(SortAndFilter.IsDigit(_inputArray[itemArray], 6));
            }
        }

        /// <summary>
        /// Test to check the execution time of methods SlowFilterDigit and QuickFilterDigit. 
        /// It is expected that the method QuickFilterDigit will be faster by the execution time.
        /// </summary>
        [TestMethod]
        public void MsTest_SlowFilterDigit_And_QuickFilterDigit_InputArrayAsArgument_OutputArrayReturned_For_Measurement_Time()
        {
            _watch.Reset();
            _watch.Start();
            SortAndFilter.SlowFilterDigit(ref _inputArray, 6);
            _watch.Stop();
            var slowTime = _watch.ElapsedMilliseconds;
            _watch.Reset();
            _watch.Start();
            SortAndFilter.SlowFilterDigit(ref _inputArray, 6);
            _watch.Stop();
            var quickTime = _watch.ElapsedMilliseconds;
            Assert.IsTrue(slowTime > quickTime);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentNullException 
        /// in method SlowFilterDigit if the referenced array reference refers to null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MsTest_SlowFilterDigit_If_Input_Array_Is_Null()
        {
            this._inputArray = null;

            SortAndFilter.SlowFilterDigit(ref _inputArray, 6);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentNullException 
        /// in method QuickFilterDigit if the referenced array reference refers to null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MsTest_QuickFilterDigit_If_Input_Array_Is_Null()
        {
            _inputArray = null;

            SortAndFilter.QuickFilterDigit(ref _inputArray, 6);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method SlowFilterDigit if the referenced array reference refers to array with 0 element.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MsTest_SlowFilterDigit_If_Input_Array_Length_Is_0()
        {
            _inputArray = new int[0];

            SortAndFilter.SlowFilterDigit(ref _inputArray, 6);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method QuickFilterDigit if the referenced array reference refers to array with 0 element.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MsTest_QuickFilterDigit_If_Input_Array_Length_Is_0()
        {
            _inputArray = new int[0];

            SortAndFilter.QuickFilterDigit(ref _inputArray, 6);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method SlowFilterDigit if the digit less then 0.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MsTest_SlowFilterDigit_If_Input_Number_Less_Then_0()
        {
            int number = -1;

            SortAndFilter.SlowFilterDigit(ref _inputArray, number);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method QuickFilterDigit if the digit less then 0.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MsTest_QuickFilterDigit_If_Input_Number_Less_Then_0()
        {
            int number = -1;

            SortAndFilter.QuickFilterDigit(ref _inputArray, number);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method SlowFilterDigit if the digit more then 10.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MsTest_SlowFilterDigit_If_Input_Number_More_Then_10()
        {
            int number = 10;

            SortAndFilter.SlowFilterDigit(ref _inputArray, number);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method QuickFilterDigit if the digit more then 10.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MsTest_QuickFilterDigit_If_Input_Number_More_Then_10()
        {
            int number = 10;

            SortAndFilter.QuickFilterDigit(ref _inputArray, number);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method SlowFilterDigit if the digit more then Int.MaxValue.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MsTest_SlowFilterDigit_If_Input_Number_More_Then_MaxValue()
        {
            Random random = new Random(0);

            SortAndFilter.SlowFilterDigit(ref _inputArray, random.Next(20000000, 200000000));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method QuickFilterDigit if the digit more then Int.MaxValue.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MsTest_QuickFilterDigit_If_Input_Number_More_Then_Int_MaxValue()
        {
            Random random = new Random(0);

            SortAndFilter.QuickFilterDigit(ref _inputArray, random.Next(20000000, 200000000));
        }

        /// <summary>
        /// /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method SlowFilterDigit if the digit less then Int.MinValue.
        /// </summary>
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MsTest_SlowFilterDigit_If_Input_Number_Less_Then_Int_MinValue()
        {
            Random random = new Random(0);

            SortAndFilter.SlowFilterDigit(ref _inputArray, random.Next(20000000, 200000000));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method QuickFilterDigit if the digit less then Int.MinValue.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MsTest_QuickFilterDigit_If_Input_Number_Less_Then_MinValue()
        {
            Random random = new Random(0);

            SortAndFilter.QuickFilterDigit(ref _inputArray, random.Next(-20000000, -200000000));
        }
    }
}
