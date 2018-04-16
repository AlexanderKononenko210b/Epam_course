using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SortAndFilterArray
{
    public static class FilterAndChange
    {
        #region Interfaces

        /// <summary>
        /// Interface with method search digit or number in element integer array
        /// </summary>
        public interface IFilterNumber<T>
        {
            bool IsMatch(T number);
        }

        /// <summary>
        /// Interface with method change number
        /// </summary>
        public interface IChangeNumber<T>
        {
            T ChangeNumberMultipl(T number);
        }

        #endregion

        #region Class FilterArrayIntegerNumbers

        /// <summary>
        /// Class implement interface IFilterNumber for check contain digit in element array
        /// </summary>
        public class FilterArrayIntegerNumbers : IFilterNumber<int>
        {
            private int filterNumber;

            /// <summary>
            /// Number filter
            /// </summary>
            public int FilterNumber
            {
                get
                {
                    return filterNumber;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException($"Value`s must be greater or equals 0");
                    }

                    value = filterNumber;
                }
            }

            /// <summary>
            /// Constructor class FilterArrayIntegerNumbers
            /// </summary>
            /// <param name="filter"></param>
            public FilterArrayIntegerNumbers(int filter)
            {
                this.FilterNumber = filter;
            }

            /// <summary>
            /// Method to determine whether a number in an element of an array
            /// </summary>
            /// <param name="item">element of array</param>
            /// <returns>true if element of array contains number and false if he isn`t contains number </returns>
            public bool IsMatch(int item)
            {
                var arraySourceNumber = DigitInArray(item);

                var arrayDigitFilter = DigitInArray(this.FilterNumber);

                if (arraySourceNumber.Length < arrayDigitFilter.Length)
                {
                    return false;
                }
                else
                {
                    if (arraySourceNumber.Length == arrayDigitFilter.Length)
                    {
                        return (item ^ this.FilterNumber) == 0;
                    }
                    else
                    {
                        int countIteration = 0, countHelper = 0;
                        var numberHelper = 0.0;

                        while (countIteration + arrayDigitFilter.Length <= arraySourceNumber.Length)
                        {
                            for (int j = countIteration; j < arrayDigitFilter.Length + countIteration; j++)
                            {
                                countHelper++;
                                numberHelper += arraySourceNumber[j] / Math.Pow(10, countHelper);
                            }

                            numberHelper *= Math.Pow(10, countHelper);

                            var resultNumber = (int)numberHelper;

                            if ((resultNumber ^ this.FilterNumber) == 0)
                            {
                                return true;
                            }

                            countIteration++;
                            numberHelper = 0;
                            countHelper = 0;
                        }
                    }
                }

                return false;
            }

            /// <summary>
            /// Method for change input number in digit array
            /// </summary>
            /// <param name="itemNumber">number for change in digit array</param>
            /// <returns>array digit</returns>
            private static int[] DigitInArray(int itemNumber)
            {
                Collection<int> collectHelper = new Collection<int>();

                do
                {
                    collectHelper.Add(itemNumber % 10);

                    itemNumber /= 10;
                }
                while (itemNumber > 0);

                return collectHelper.ToArray();
            }
        }

        #endregion Class FilterArrayIntegerNumbers

        #region Class ChangeNumber

        /// <summary>
        /// Class change number in array
        /// </summary>
        public class ChangeNumber : IChangeNumber<int>
        {
            private int valueMultipl;

            /// <summary>
            /// Degree for pow operetion
            /// </summary>
            public int ValueMultipl
            {
                get
                {
                    return valueMultipl;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException($"Value`s must be greater or equals 0");
                    }

                    value = valueMultipl;
                }
            }

            public ChangeNumber(int numberValue)
            {
                this.ValueMultipl = numberValue;
            }

            /// <summary>
            /// Method for pow number
            /// </summary>
            /// <param name="number"></param>
            /// <returns></returns>
            public int ChangeNumberMultipl(int number)
            {
                return number * this.ValueMultipl;
            }
        }

        #endregion

        #region FilterDigit

        /// <summary>
        /// Method for search in array with interface in general type
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="inputEnumerable">input array</param>
        /// <param name="predicate">predicate</param>
        /// <returns>IEnumarable T</returns>
        public static IEnumerable<T> FilterDigit<T>(this T[] inputEnumerable, IFilterNumber<T> predicate)
        {
            if (inputEnumerable == null)
            {
                throw new ArgumentNullException($"Argument {nameof(inputEnumerable)} is null");
            }

            if (inputEnumerable.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(inputEnumerable)} length is 0");
            }

            if (predicate == null)
            {
                throw new ArgumentOutOfRangeException($"Argument { nameof(predicate) } is null");
            }

            return FilterDigitSearcher(inputEnumerable, predicate.IsMatch);

        }

        /// <summary>
        /// Method for search in array predicate in general type
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="inputEnumerable">input array</param>
        /// <param name="predicate">predicate</param>
        /// <returns>IEnumarable T</returns>
        public static IEnumerable<T> FilterDigit<T>(this T[] inputEnumerable, Func<T, bool> predicate)
        {
            if (inputEnumerable == null)
            {
                throw new ArgumentNullException($"Argument {nameof(inputEnumerable)} is null");
            }

            if (inputEnumerable.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(inputEnumerable)} count is 0");
            }

            if (predicate == null)
            {
                throw new ArgumentOutOfRangeException($"Argument { nameof(predicate) } is null");
            }

            return FilterDigitSearcher(inputEnumerable, predicate);
        }

        /// <summary>
        /// Block state for search predicate
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="inputEnumerable">input Array</param>
        /// <param name="predicate">delegate predicate</param>
        /// <returns>IEnumarable<typeparamref name="T"/></returns>
        private static IEnumerable<T> FilterDigitSearcher<T>(T[] inputEnumerable, Func<T, bool> predicate)
        {
            foreach(T item in inputEnumerable)
            {
                if(predicate(item))
                    yield return item;
            }
        }

        #endregion

        #region ChangeArray

        /// <summary>
        /// Extension method change array using interface
        /// </summary>
        /// <param name="inputEnumerable">input array</param>
        /// <param name="conditionInterface">instance class ChangeNumber</param>
        /// <returns>array with change number</returns>
        public static IEnumerable<T> ChangeArrayElements<T>(this T[] inputEnumerable, IChangeNumber<T> conditionInterface)
        {
            if (inputEnumerable == null)
            {
                throw new ArgumentNullException($"Argument {nameof(inputEnumerable)} is null");
            }

            if (inputEnumerable.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(inputEnumerable)} length is 0");
            }

            if (conditionInterface == null)
            {
                throw new ArgumentOutOfRangeException($"Argument`s { nameof(conditionInterface) } is null");
            }

            return Changer(inputEnumerable, conditionInterface.ChangeNumberMultipl);
        }

        /// <summary>
        /// Extension method change array using delegate
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="inputEnumerable">input array</param>
        /// <param name="conditionDelegate">delegate incapsulation method for change inputEnumerable</param>
        /// <returns>IEnumarable T</returns>
        public static IEnumerable<T> ChangeArrayElements<T>(this T[] inputEnumerable, Func<T, T> conditionDelegate)
        {
            if (inputEnumerable == null)
            {
                throw new ArgumentNullException($"Argument {nameof(inputEnumerable)} is null");
            }

            if (inputEnumerable.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(inputEnumerable)} count is 0");
            }

            if (conditionDelegate == null)
            {
                throw new ArgumentOutOfRangeException($"Argument { nameof(conditionDelegate) } is null");
            }

            return Changer(inputEnumerable, conditionDelegate);
        }

        /// <summary>
        /// Block state for change input Enumerable
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="inputEnumerable">input Array</param>
        /// <param name="changeDelegate">delegate incapsulation method for change inputEnumerable</param>
        /// <returns>IEnumarable<typeparamref name="T"/></returns>
        private static IEnumerable<T> Changer<T>(T[] inputEnumerable, Func<T, T> changeDelegate)
        {
            foreach (T item in inputEnumerable)
            {
                var res = changeDelegate(item);
                    yield return res;
            }
        }

        #endregion

        #region Helper

        /// <summary>
        /// Method for check change in element output array using interface
        /// </summary>
        /// <param name="inputNumber">input number</param>
        /// <param name="outputNumber">outnput number</param>
        /// <param name="condition">value for change element</param>
        /// <returns>true if change element all element in array</returns>
        public static bool IsNumberChangeHelper(int inputNumber, int outputNumber, IChangeNumber<int> condition)
        {
            if (condition.ChangeNumberMultipl(inputNumber) != outputNumber)
                return false;
            return true;
        }

        /// <summary>
        /// Method for check change in element output array using interface
        /// </summary>
        /// <param name="inputNumber">input number</param>
        /// <param name="outputNumber">outnput number</param>
        /// <param name="condition">value for change element</param>
        /// <returns>true if change element all element in array</returns>
        public static bool IsNumberChangeHelper(int inputNumber, int outputNumber, Func<int, int> condition)
        {
            if (condition(inputNumber) != outputNumber)
                return false;
            return true;
        }

        /// <summary>
        /// Method for check change in element output array
        /// </summary>
        /// <param name="outPutNumber">input number</param>
        /// <param name="predicate">filter value</param>
        /// <returns>true if all elements in output array contain filter number</returns>
        public static bool IsNumberFilterHelper(int outPutNumber, IFilterNumber<int> predicate)
        {
            if (!predicate.IsMatch(outPutNumber))
                return false;
            return true;
        }

        /// <summary>
        /// Method for verification change in element output array
        /// </summary>
        /// <param name="outPutNumber">input number</param>
        /// <param name="predicate">filter value</param>
        /// <returns>true if all elements in output array contain filter number</returns>
        public static bool IsNumberFilterHelper(int outPutNumber, Func<int, bool> predicate)
        {
            if (!predicate(outPutNumber))
                return false;
            return true;
        }

        #endregion
    }
}
