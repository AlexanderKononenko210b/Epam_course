using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortAndFilterArray;

namespace SortAndFilterArray.Test
{
    /// <summary>
    /// Class for test Sort methods
    /// </summary>
    [TestClass]
    public class MSUnitTestSort
    {
        private int[] inputArray;

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
            inputArray = arrayForTest;
        }

        /// <summary>
        /// Test with valid data for the method QuickSort
        /// </summary>
        [TestMethod]
        public void MSTest_QuickSortinputArrayAsArgumentinputArrayReturned_With_Valid_Data()
        {
            SortArray.QuickSort( inputArray);

            Assert.IsTrue(SortArray.IsSort( inputArray, TypeSortArray.Descend));

        }

        /// <summary>
        /// Test with valid data for the method MergeSort
        /// </summary>
        [TestMethod]
        public void MSTest_MergeSortinputArrayAsArgumentinputArrayReturned_With_Valid_Data()
        {
            inputArray.CopyTo(inputArray, 0);

            SortArray.MergeSort( inputArray);

            Assert.IsTrue(SortArray.IsSort( inputArray, TypeSortArray.Ascend));
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentNullException 
        /// in method QuickSort if the erenced array reference refers to null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MSTest_QuickSort_If_Input_Array_Is_Null()
        {
            inputArray = null;

            SortArray.QuickSort( inputArray);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentNullException 
        /// in method MergeSort if the erenced array reference refers to null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MSTest_MergeSort_If_Input_Array_Is_Null()
        {
            inputArray = null;

            SortArray.MergeSort( inputArray);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method QuickSort if the erenced array erence ers to array with 0 element.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MSTest_QuickSort_If_Input_Array_Length_Is_0()
        {
            inputArray = new int[0];

            SortArray.QuickSort( inputArray);
        }

        /// <summary>
        /// Test to check for the occurrence of an exception ArgumentOutOfRangeException
        /// in method MergeSort if the erenced array erence ers to array with 0 element.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MSTest_MergeSort_If_Input_Array_Length_Is_0()
        {
            inputArray = new int[0];

            SortArray.MergeSort( inputArray);
        }
    }
}
