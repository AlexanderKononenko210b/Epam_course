using System;
using System.Linq;
using SortServer.Properties;

namespace SortServer
{
    /// <summary>
    /// Static class for sort one-dimensional array
    /// </summary>
    public static class SortMethods
    {
        /// <summary>
        /// Method for quick sort
        /// </summary>
        /// <param name="inputArray">input one-dimensional array</param>
        /// <returns>rezalt array</returns>
        public static int[] QuickSort(int[] inputArray)
        {
            // check the empty array
            if (inputArray == null)
            {
                throw new NullReferenceException(Resources.NullReferenceExceptions);
            }

            // check the empty array
            if (inputArray.Length == 0)
            {
                throw new EmptyArrayException(Resources.EmptyArray);
            }

            // check the array for length, if 1 element is not sorted
            if (inputArray.Length > 1)
            {
                return QuickSortHelper(inputArray, 0, inputArray.Length - 1);
            }

            return inputArray;
        }

        /// <summary>
        /// Method for merge sort
        /// </summary>
        /// <param name="inputArray">input array</param>
        /// <returns>rezalt array</returns>
        public static int[] MergeSort(int[] inputArray)
        {
            // check the empty array
            if (inputArray == null)
            {
                throw new NullReferenceException(Resources.NullReferenceExceptions);
            }

            // check the empty array
            if (inputArray.Length == 0)
            {
                throw new EmptyArrayException(Resources.EmptyArray);
            }

            // set the length of auxiliary arrays
            int lengthArray1 = inputArray.Length / 2, lengthArray2 = inputArray.Length - lengthArray1;

            // initialize additional arrays and rezalt array
            int[] array1 = inputArray.Take(lengthArray1).ToArray(),
                array2 = inputArray.Skip(lengthArray1).ToArray();

            // check the array for length, if 1 element is not sorted
            if (array1.Length > 1)
            {
                array1 = MergeSort(array1);
            }

            if (array2.Length > 1)
            {
                array2 = MergeSort(array2);
            }

            // sort merge
            var rezaltArray = MergeSortHelper(array1, array2);

            return rezaltArray;
        }

        /// <summary>
        /// Helper method for quick sort
        /// </summary>
        /// <param name="inputArray">input one-dimensional array</param>
        /// <param name="numberOfIndexLeft">index left border</param>
        /// <param name="numberOfIndexRight">index right border</param>
        /// <returns>rezalt array</returns>
        private static int[] QuickSortHelper(int[] inputArray, int numberOfIndexLeft, int numberOfIndexRight)
        {
            // initializing the left, right and middle element
            int i = numberOfIndexLeft, j = numberOfIndexRight, t = inputArray[(numberOfIndexLeft + numberOfIndexRight) / 2];

            // sorting cycle while i <= j
            do
            {
                // looking for the left element less than average
                while (inputArray[i] > t)
                {
                    ++i;
                }

                // looking for the right element of a larger average
                while (inputArray[j] < t)
                {
                    --j;
                }

                // if both conditions are violated and not the middle is rearranged
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

            // if we did not reach the right border array call recursively method QuickSort
            if (i < numberOfIndexRight)
            {
                var rezalt = QuickSortHelper(inputArray, i, numberOfIndexRight);
            }

            // if we did not reach the left border array call recursively method QuickSort
            if (numberOfIndexLeft < j)
            {
                var rezalt = QuickSortHelper(inputArray, numberOfIndexLeft, j);
            }

            return inputArray;
        }

        /// <summary>
        /// Helper method for sort double array in mergesort
        /// </summary>
        /// <param name="array1">first array</param>
        /// <param name="array2">second array</param>
        /// <returns>rezalt array</returns>
        private static int[] MergeSortHelper(int[] array1, int[] array2)
        {
            // set the index of auxiliary arrays
            int indexOfArray1 = 0, indexOfArray2 = 0;

            // auxiliary arrays
            int[] arrayRezalt = new int[array1.Length + array2.Length];

            // sorting cycle
            for (int i = 0; i < arrayRezalt.Length; i++)
            {
                if ((indexOfArray2 < array2.Length) && (indexOfArray1 < array1.Length))
                {
                    if (array1[indexOfArray1] > array2[indexOfArray2])
                    {
                        arrayRezalt[i] = array2[indexOfArray2++];
                    }
                    else
                    {
                        arrayRezalt[i] = array1[indexOfArray1++];
                    }
                }
                else
                if (indexOfArray2 < array2.Length)
                {
                    arrayRezalt[i] = array2[indexOfArray2++];
                }
                else
                {
                    arrayRezalt[i] = array1[indexOfArray1++];
                }
            }

            return arrayRezalt;
        }
    }
}
