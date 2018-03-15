using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Самостоятельная работа задание 4 вариант 3
using System;


namespace ConsoleAplication
{
    class Program
    {
        static void SortHoara(int[] MyArray2, int left, int right, ref int flag1)
        {
            int i = left, j = right, t = MyArray2[(left + right) / 2];
            do
            {
                //ищем слева элемент меньше среднего
                while (MyArray2[i] > t)
                { ++i; }
                //ищем справа элемент больший среднего
                while (MyArray2[j] < t)
                { --j; }
                if (i <= j)//если нарушены оба условия и не середина переставляемся
                {

                    int var = MyArray2[i]; MyArray2[i] = MyArray2[j]; MyArray2[j] = var;
                    i++; j--;
                    ++flag1;

                }
            }
            while (i <= j);
            if (i < right)
            {
                SortHoara(MyArray2, i, right, ref flag1);
            }
            if (left < j)
            {
                SortHoara(MyArray2, left, j, ref flag1);
            }

        }
        static void SortLineSelection(int[] MyArray, ref int flag)
        {
            for (int i = 0; i < MyArray.Length; ++i)
            {
                int k = i;
                int max = MyArray[i];
                for (int j = i + 1; j < MyArray.Length; ++j)
                {
                    if (MyArray[j] > max)
                    {

                        max = MyArray[j];
                        k = j;
                    }
                }
                if (k != i)
                {
                    MyArray[k] = MyArray[i];
                    MyArray[i] = max;
                    ++flag;
                }
            }
        }
        static void BinarySearch(int[] MyArray2, int z, int n, ref int flag3)
        {
            int m = 0, L = 0, R = n - 1;
            bool flag2 = false;
            int t = MyArray2[(MyArray2.Length + 1) / 2];
            while ((L <= R) & (flag2 == false))
            {
                m = (R + L) / 2;
                if (MyArray2[m] == z)
                { flag2 = true; }
                else
                {
                    if (MyArray2[m] > z)
                    { L = m + 1; }
                    else
                    { R = m - 1; }
                }
                ++flag3;
            }
            if (flag2 == true)
            { Console.WriteLine("Элемент найден его номер={0}", m); }
            else
            { Console.WriteLine("Элемент в массиве отсутствует"); }
        }
        static void Main()
        {
            Console.WriteLine("введите размерность массива");
            int n = int.Parse(Console.ReadLine());
            int[] MyArray = new int[n], MyArray2 = new int[n];
            Random m = new Random(0);
            for (int i = 0; i < MyArray.Length; ++i)
            { MyArray[i] = m.Next(0, 99); MyArray2[i] = MyArray[i]; }
            Console.WriteLine("Массив для линейного метода до сортировки:");
            foreach (int q in MyArray)
            { Console.Write("{0} ", q); }
            Console.WriteLine();
            int flag = 0;
            SortLineSelection(MyArray, ref flag);
            Console.WriteLine("Отсортированный по линейному методу массив:");
            foreach (int q in MyArray)
            { Console.Write("{0} ", q); }
            Console.WriteLine();
            Console.WriteLine("Количество перестановок по линейному методу = {0}", flag);
            Console.WriteLine();
            Console.WriteLine("Массив для метода хоара до сортировки:");
            foreach (int q in MyArray2)
            { Console.Write("{0} ", q); }
            Console.WriteLine();
            int left = 0, right = n - 1, flag1 = 0;
            SortHoara(MyArray2, left, right, ref flag1);
            Console.WriteLine("Отсортированный по методу хоара массив:");
            foreach (int q in MyArray2)
            { Console.Write("{0} ", q); }
            Console.WriteLine();
            Console.WriteLine("Количество перестановок по методу хоара = {0}", flag1);
            Console.WriteLine("введите значение искомого элемента массива");
            int z = int.Parse(Console.ReadLine());
            int flag3 = 0;
            BinarySearch(MyArray2, z, n, ref flag3);
            Console.WriteLine("Количество шагов в бинарном поиске = {0}", flag3);

        }
    }
}