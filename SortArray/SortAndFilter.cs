using System;
using System.Linq;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SortAndFilterArray
{
    /// <summary>
    /// Static class for sort one-dimensional array
    /// </summary>
    public static class SortAndFilter
    {
        #region Sort

        /// <summary>
        /// Method for quick sort.
        /// The input array is checked for null, the length of the array is different from 0.
        /// If the length of the array is strictly greater than one element,
        /// then the QuickSortHelper helper method is invoked in which the value 
        /// of the reference to the input array is passed as an argument.
        /// </summary>
        /// <param name="inputArray">input one-dimensional array</param>
        /// <returns>rezalt array</returns>
        public static void QuickSort(int[] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException($"Argument {nameof(inputArray)} is null");
            }

            if (inputArray.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(inputArray)} length is 0");
            }

            if (inputArray.Length > 1)
            {
                QuickSortHelper(inputArray, 0, inputArray.Length - 1);
            }
        }

        /// <summary>
        /// lengthArray1 - length of half of the array,
        /// array1 - auxiliary array equal to half of the input array,
        /// array2 - auxiliary array equal to half of the input array,
        /// if the length of the auxiliary array is greater than 1,
        /// recursively call the MergeSort.
        /// </summary>
        /// <param name="inputArray">input array</param>
        public static void MergeSort(int[] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException($"Argument {nameof(inputArray)} is null");
            }

            if (inputArray.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(inputArray)} length is 0");
            }

            int lengthArray1 = inputArray.Length / 2;

            int[] array1 = inputArray.Take(lengthArray1).ToArray(),
                array2 = inputArray.Skip(lengthArray1).ToArray();

            if (array1.Length > 1)
            {
                MergeSort(array1);
            }

            if (array2.Length > 1)
            {
                MergeSort(array2);
            }

            MergeSortHelper(inputArray, array1, array2);
        }

        /// <summary>
        /// numberOfIndexLeft - the index of the left element of the array,
        /// numberOfIndexRight - the index of the right element of the array,
        /// In the do-while loop, we rearrange the elements from the right and
        /// left sides of the array until i is less than or equal to j. 
        /// If the condition i is less than numberOfIndexRight and numberOfIndexLeft is less than j,
        /// the QuickSortHelper method is recursively called.
        /// </summary>
        /// <param name="inputArray">input one-dimensional array</param>
        /// <param name="numberOfIndexLeft">the index of the left element of the array</param>
        /// <param name="numberOfIndexRight">the index of the right element of the array</param>
        private static void QuickSortHelper(int[] inputArray, int numberOfIndexLeft, int numberOfIndexRight)
        {
            int i = numberOfIndexLeft,
                j = numberOfIndexRight, 
                t = inputArray[(numberOfIndexLeft + numberOfIndexRight) / 2];

            do
            {
                while (inputArray[i] > t)
                {
                    ++i;
                }

                while (inputArray[j] < t)
                {
                    --j;
                }

                if (i <= j)
                {
                    int var = inputArray[i];
                    inputArray[i] = inputArray[j];
                    inputArray[j] = var;
                    i++;
                    j--;
                }
            }
            while (i <= j);

            if (i < numberOfIndexRight)
            {
                QuickSortHelper(inputArray, i, numberOfIndexRight);
            }

            if (numberOfIndexLeft < j)
            {
                QuickSortHelper(inputArray, numberOfIndexLeft, j);
            }
        }

        /// <summary>
        /// indexOfArray1 - the index of the array1,
        /// indexOfArray2 - the index of the array2,
        /// A method for merging two sorted arrays.
        /// </summary>
        /// <param name="inputArray">input array</param>
        /// <param name="array1">first array</param>
        /// <param name="array2">second array</param>
        private static void MergeSortHelper(int[] inputArray, int[] array1, int[] array2)
        {
            int indexOfArray1 = 0, indexOfArray2 = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                if ((indexOfArray2 < array2.Length) && (indexOfArray1 < array1.Length))
                {
                    if (array1[indexOfArray1] > array2[indexOfArray2])
                    {
                        inputArray[i] = array2[indexOfArray2++];
                    }
                    else
                    {
                        inputArray[i] = array1[indexOfArray1++];
                    }
                }
                else
                if (indexOfArray2 < array2.Length)
                {
                    inputArray[i] = array2[indexOfArray2++];
                }
                else
                {
                    inputArray[i] = array1[indexOfArray1++];
                }
            }
        }

        #endregion Sort

        #region Filter

        /// <summary>
        /// Slow method for verification include digit in element input array
        /// </summary>
        /// <param name="inputArray">input array</param>
        /// <param name="digit">number - filter</param>
        /// <returns>output array with element that contains digit</returns>
        public static int[] SlowFilterDigit(int[] inputArray, int digit)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException($"Argument {nameof(inputArray)} is null");
            }

            if (inputArray.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(inputArray)} length is 0");
            }

            if (digit < 0 || digit > 9)
            {
                throw new ArgumentOutOfRangeException($"Digit`s {nameof(digit)} must be greater than 0 and less than 10");
            }

            bool flag = false;

            var digitAsChar = char.GetNumericValue(digit.ToString(CultureInfo.CreateSpecificCulture("en-US"))[0]);

            var rezaltCollection = new Collection<int>();

            for (int i = 0; i < inputArray.Length; i++)
            {
                var elementArrayAsString = inputArray[i].ToString(CultureInfo.CreateSpecificCulture("en-US"));

                foreach (char charItem in elementArrayAsString)
                {
                    if (char.GetNumericValue(charItem) == digitAsChar)
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag == true)
                {
                    rezaltCollection.Add(inputArray[i]);
                    flag = false;
                }
            }

            return rezaltCollection.ToArray();
        }

        /// <summary>
        /// Method for verification include digit in element input array
        /// </summary>
        /// <param name="inputArray">input array</param>
        /// <param name="digit">number - filter</param>
        /// <returns>output array with element that contains digit</returns>
        public static int[] QuickFilterDigit(int[] inputArray, int digit)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException($"Argument {nameof(inputArray)} is null");
            }

            if (inputArray.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(inputArray)} length is 0");
            }

            if (digit < 0 || digit > 9)
            {
                throw new ArgumentOutOfRangeException($"Digit`s {nameof(digit)} must be greater than 0 and less than 10");
            }

            Collection<int> rezaltCollection = new Collection<int>();

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (IsDigit(inputArray[i], digit))
                {
                    rezaltCollection.Add(inputArray[i]);
                }
            }

            return rezaltCollection.ToArray();

        }

        /// <summary>
        /// Private method to determine whether a number in an element of an array
        /// </summary>
        /// <param name="itemArray">element of array</param>
        /// <param name="digit">number - filter</param>
        /// <returns>true if element of array contains digit and false if he isn`t contains digit </returns>
        public static bool IsDigit(int itemArray, int digit)
        {
            do
            {
                if (itemArray % 10 == digit)
                {
                    return true;
                }

                itemArray = itemArray / 10;
            }
            while (itemArray != 0);

            return false;
        }

        #endregion Filter

        #region Helper

        /// <summary>
        /// Helper method for check is an array sorted or not sorted
        /// </summary>
        /// <param name="inputArray">input array</param>
        /// <param name="typeSort">type sort</param>
        /// <returns>true if array is an array sorted and false if not sorted</returns>
        public static bool IsSort(int[] inputArray, TypeSortArray typeSort)
        {
            switch (typeSort)
            {
                case TypeSortArray.Descend:
                    for (int itemArray = 0; itemArray < inputArray.Length - 1; itemArray++)
                    {
                        if (inputArray[itemArray] < inputArray[itemArray + 1])
                        {
                            return false;
                        }
                    }
                    break;
                case TypeSortArray.Ascend:
                    for (int itemArray = 0; itemArray < inputArray.Length - 1; itemArray++)
                    {
                        if (inputArray[itemArray] > inputArray[itemArray + 1])
                        {
                            return false;
                        }
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Argument {nameof(typeSort)} is not suitable for selection conditions");
            }

            return true;
        }

        #endregion Helper
    }
}
