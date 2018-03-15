using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilterDigitServer;

namespace MSUnitFilterDigit
{
    [TestClass]
    public class MSUnitTestFilterDigit
    {
        private int[] _inputArray;

        public MSUnitTestFilterDigit()
        {
            // Arrange
            var inputArry = new int[5]
            {
                42, 62, 6, 48, 69
            };

            this._inputArray = inputArry;
        }

        [TestMethod]
        public void MsTest_FilterDigit_InputArrayAsArgument_RezaltArrayReturned()
        {
            // Act
            var assert1 = FilterClass.FilterDigit(this._inputArray, 6);

            // Rezalt
            Assert.AreEqual(62, assert1[0]);
            Assert.AreEqual(6, assert1[1]);
            Assert.AreEqual(69, assert1[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void MsTest_FilterDigit_If_Input_Array_Is_Null()
        {
            // Arrange
            this._inputArray = null;

            // Act
            var assert1 = FilterClass.FilterDigit(_inputArray, 6);
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyArrayException))]
        public void MsTest_FilterDigit_If_Input_Array_Length_Is_0()
        {
            // Arrange
            this._inputArray = new int[0];

            // Act
            var assert1 = FilterClass.FilterDigit(_inputArray, 6);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MsTest_FilterDigit_If_Input_Number_Less_Then_0()
        {
            // Arrange
            int number = -1;

            // Act
            var assert1 = FilterClass.FilterDigit(_inputArray, number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MsTest_FilterDigit_If_Input_Number_More_Then_MaxValue()
        {
            // Arrange
            int number = 10;

            // Act
            var assert1 = FilterClass.FilterDigit(_inputArray, number);
        }
    }
}
