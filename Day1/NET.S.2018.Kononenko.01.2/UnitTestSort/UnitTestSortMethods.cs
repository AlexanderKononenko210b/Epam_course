using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortServer;

namespace UnitTestSort
{
    [TestClass]
    public class UnitTestSortMethods
    {
        private int[] _inputArray;

        public UnitTestSortMethods()
        {
            // Arrange
            var arrayForTest = new int[5] { 56, 8, 5, 402, 2 };
            this._inputArray = arrayForTest;
        }

        [TestMethod]
        public void QuickSort_ArrayForTestAsArgument_ArrayForTestReturned()
        {
            // Act
            var assert1 = SortMethods.QuickSort(this._inputArray);

            // Rezalt
            Assert.AreEqual(402, assert1[0]);
            Assert.AreEqual(56, assert1[1]);
            Assert.AreEqual(8, assert1[2]);
            Assert.AreEqual(5, assert1[3]);
            Assert.AreEqual(2, assert1[4]);
        }

        [TestMethod]
        public void MergeSort_ArrayForTestAsArgument_ArrayForTestReturned()
        {
            // Act
            var assert1 = SortMethods.MergeSort(this._inputArray);

            // Rezalt
            Assert.AreEqual(2, assert1[0]);
            Assert.AreEqual(5, assert1[1]);
            Assert.AreEqual(8, assert1[2]);
            Assert.AreEqual(56, assert1[3]);
            Assert.AreEqual(402, assert1[4]);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void QuickSort_If_Input_Array_Is_Null()
        {
            // Arrange
            this._inputArray = null;

            // Act
            var assert1 = SortMethods.QuickSort(this._inputArray);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void MergeSort_If_Input_Array_Is_Null()
        {
            // Arrange
            this._inputArray = null;

            // Act
            var assert1 = SortMethods.MergeSort(this._inputArray);
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyArrayException))]
        public void QuickSort_If_Input_Array_Length_Is_0()
        {
            // Arrange
            this._inputArray = new int[0];

            // Act
            var assert1 = SortMethods.QuickSort(this._inputArray);
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyArrayException))]
        public void MergeSort_If_Input_Array_Length_Is_0()
        {
            // Arrange
            this._inputArray = new int[0];

            // Act
            var assert1 = SortMethods.MergeSort(this._inputArray);
        }
    }
}
