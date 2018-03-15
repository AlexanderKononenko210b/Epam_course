using System;
using NUnit.Framework;
using FilterDigitServer;

namespace NUnitTestFilterDigit
{
    [TestFixture]
    public class NUnitTestFilterDigit
    {
        private int[] _inputArray;

        [SetUp]
        public void Initialize()
        {
            // Arrange
            var inputArray = new int[5]
            {
                42, 62, 6, 48, 69
            };

            this._inputArray = inputArray;
        }

        [Test]
        public void NUnit_FilterDigit_InputArrayAsArgument_RezaltArrayReturned()
        {
            // Act
            var assert1 = FilterClass.FilterDigit(this._inputArray, 6);

            // Rezalt
            Assert.AreEqual(62, assert1[0]);
            Assert.AreEqual(6, assert1[1]);
            Assert.AreEqual(69, assert1[2]);
        }

        [Test]
        public void NUnit_FilterDigit_If_Input_Array_Is_Null()
        {
            // Arrange
            this._inputArray = null;

            // Act
            Assert.Throws<NullReferenceException>(() => FilterClass.FilterDigit(this._inputArray, 6));
        }

        [Test]
        public void NUnit_FilterDigit_If_Input_Array_Length_Is_0()
        {
            // Arrange
            this._inputArray = new int[0];

            // Act
            Assert.Throws<EmptyArrayException>(() => FilterClass.FilterDigit(this._inputArray, 6));
        }

        [Test]
        public void NUnit_FilterDigit_If_Input_Number_Less_Then_0()
        {
            // Arrange
            int number = -1;

            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => FilterClass.FilterDigit(this._inputArray, number));
        }

        [Test]
        public void NUnit_FilterDigit_If_Input_Number_More_Then_MaxValue()
        {
            // Arrange
            int number = 10;

            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => FilterClass.FilterDigit(this._inputArray, number));
        }
    }
}
