using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortAndFilterArray;

namespace TestSortAndFilter
{
    /// <summary>
    /// Class for test sort and filter methods
    /// </summary>
    [TestClass]
    public class MSUnitTestSort
    {
        private int[] _inputArray;

        /// <summary>
        /// Constructor for create instance of MSUnitTestSort class
        /// </summary>
        public MSUnitTestSort()
        {
            var arrayForTest = new int[100000];
            Random random = new Random(0);
            for(int itemArray = 0; itemArray < arrayForTest.Length; itemArray++)
            {
                arrayForTest[itemArray] = random.Next(0, 100);
            }
            _inputArray = arrayForTest;
        }

        /// <summary>
        /// Test with valid data for the method QuickSort
        /// </summary>
        [TestMethod]
        public void QuickSort_InputArrayAsArgument_InputArrayReturned_With_Valid_Data()
        {
            SortAndFilter.QuickSort(ref _inputArray);

            Assert.IsTrue(SortAndFilter.IsSort(ref _inputArray, TypeSortArray.Descend));

        }

        /// <summary>
        /// Test with valid data for the method MergeSort
        /// </summary>
        [TestMethod]
        public void MergeSort_InputArrayAsArgument_InputArrayReturned_With_Valid_Data()
        {
            _inputArray.CopyTo(_inputArray, 0);

            SortAndFilter.MergeSort(ref _inputArray);

            Assert.IsTrue(SortAndFilter.IsSort(ref _inputArray, TypeSortArray.Ascend));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentNullException 
        /// in method QuickSort if the referenced array reference refers to null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_If_Input_Array_Is_Null()
        {
            _inputArray = null;

            SortAndFilter.QuickSort(ref _inputArray);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentNullException 
        /// in method MergeSort if the referenced array reference refers to null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_If_Input_Array_Is_Null()
        {
            _inputArray = null;

            SortAndFilter.MergeSort(ref _inputArray);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method QuickSort if the referenced array reference refers to array with 0 element.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void QuickSort_If_Input_Array_Length_Is_0()
        {
            _inputArray = new int[0];

            SortAndFilter.QuickSort(ref _inputArray);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method MergeSort if the referenced array reference refers to array with 0 element.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MergeSort_If_Input_Array_Length_Is_0()
        {
            _inputArray = new int[0];

            SortAndFilter.MergeSort(ref _inputArray);
        }
    }
}
