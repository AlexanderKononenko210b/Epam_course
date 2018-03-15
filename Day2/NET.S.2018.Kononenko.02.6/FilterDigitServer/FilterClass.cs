using System;
using System.Globalization;
using FilterDigitServer.Properties;

namespace FilterDigitServer
{

    public static class FilterClass
    {
        public static int[] FilterDigit(int[] inputArray, int number)
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

            // check the empty array
            if (number < 0 || number > 9)
            {
                throw new ArgumentOutOfRangeException(Resources.NumberIsNotValid);
            }

            // index for rezalt array
            int indexOfRezaltArray = 0;

            // flag exist numeral in element array
            bool flag = false;

            // number as char
            var numberAsChar = char.GetNumericValue(number.ToString(CultureInfo.CreateSpecificCulture("en-US"))[0]);

            // rezalt array
            var rezaltArray = new int[inputArray.Length];

            for (int i = 0; i < inputArray.Length; i++)
            {
                var elementArrayAsString = inputArray[i].ToString(CultureInfo.CreateSpecificCulture("en-US"));

                foreach (char charItem in elementArrayAsString)
                {
                    if (char.GetNumericValue(charItem) == numberAsChar)
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag == true)
                {
                    rezaltArray[indexOfRezaltArray] = inputArray[i];
                    indexOfRezaltArray++;
                    flag = false;
                }
            }

            return rezaltArray;
        }
    }
}
