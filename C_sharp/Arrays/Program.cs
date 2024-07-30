using System;

namespace Arrays
{
    public class Program
    {
        static void Main(string[] args)
        {
            TwoDimensionalArray tarray = new TwoDimensionalArray();
            tarray.FillMatrix();
        }
    }

    public class StepArray
    {
        public int[][] InitializationStepArray()
        {
            Console.WriteLine("введите размерность массива");
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int[][] a = new int[n][];
            for (int i = 0; i < n; ++i)
            {
                a[i] = new int[n];
                for (int j = 0; j < n; ++j)
                {
                    Console.Write("a[{0},{1}]= ", i, j);
                    a[i][j] = int.Parse(Console.ReadLine());
                }
            }
            return a;
        }
        public void PrintStepArray(int[][] a)
        {
            for (int i = 0; i < a.Length; ++i, Console.WriteLine())
                for (int j = 0; j < a[i].Length; ++j)
                    Console.Write("{0,5} ", a[i][j]);
        }

        static int[] Multiplication(int[][] array)
        {
            int[] multiplication = new int[array.Length];
            Console.Write("k1 = ");
            int k1 = int.Parse(Console.ReadLine());
            Console.Write("k2 = ");
            int k2 = int.Parse(Console.ReadLine());

            for (int j = 0; j < array.Length; j++)
            {
                int subMultiplication = 1;

                for (int i = k1 - 1; i < k2; i++)
                {
                    int a = array[i][j];
                    subMultiplication *= a;
                }
                multiplication[j] = subMultiplication;
            }
            return multiplication;
        }
        static int[] NegativeSum(int[][] array)
        {
            int[] negativeSum = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                int negativesum = 0;

                for (int j = 0; j < array.Length; j++)
                {
                    int a = array[j][i];
                    if (a < 0)
                    {
                        negativesum += a;
                    }
                }
                negativeSum[i] = negativesum;
            }
            return negativeSum;
        }
    }
    class TwoDimensionalArray
    {
        public int[,] InitializationTwoDimensionalArray(out int n, out int m)
        {
            Console.WriteLine("введите размерность массива");
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
            Console.Write("m = ");
            m = int.Parse(Console.ReadLine());
            int[,] a = new int[n, m];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < m; ++j)
                {
                    Console.Write("a[{0},{1}]= ", i, j); //row, column
                    a[i, j] = int.Parse(Console.ReadLine());
                }
            return a;
        }
        public int NegativeSum(int[,] array)
        {
            int negativeSum = 0;

            for (int i = 0; i < array.GetLength(0); ++i, Console.WriteLine())
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                {
                    if (array[i, j] < 0)
                    {
                        negativeSum += array[i, j];
                    }
                }
            }
            return negativeSum;
        }
        public void NonMultiplicitySeven(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); ++i)
                for (int j = 0; j < array.GetLength(1); ++j)
                    if (array[i, j] % 7 != 0)
                        Console.Write("[{0}, {1}]", i, j);
        }

        public int[,] FillMatrix()
        {
            int n, m;
            Console.WriteLine("введите размерность массива");
            Console.Write("n(rows) = ");
            n = int.Parse(Console.ReadLine());
            Console.Write("m(columns) = ");
            m = int.Parse(Console.ReadLine());
            int[,] array = new int[n, m];
            int k = n * m;
            int currentK = 1;

            while (currentK <= k)
            {
                for (int i = 0; i < m; i++)
                {
                    if (i % 2 != 0)
                    {
                        for (int j = n - 1; j >= 0; j--)
                        {
                            array[j, i] = currentK;
                            currentK++;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < n; j++)
                        {
                            array[j, i] = currentK;
                            currentK++;
                        }
                    }
                }
            }

            return array;
        }
        static int[,] Swap(int[,] array)
        {
            int columnsNumber = array.Length / array.GetLength(0);
            int rowsNumber = array.GetLength(0);
            int index = columnsNumber / 2 - 1; //первый средний столбец
            int[] arr = new int[rowsNumber];

            if (columnsNumber % 2 == 0)
            {
                for (int i = 0; i < rowsNumber; i++)
                {
                    arr[i] = array[i, index];
                    array[i, index] = array[i, index + 1];
                }
                for (int i = 0; i < rowsNumber; i++)
                {
                    array[i, index + 1] = arr[i];
                }
            }
            else
            {
                for (int i = 0; i < rowsNumber; i++)
                {
                    arr[i] = array[i, 0];
                    array[i, 0] = array[i, index + 1];
                }
                for (int i = 0; i < rowsNumber; i++)
                {
                    array[i, index + 1] = arr[i];
                }
                foreach (int i in arr)
                {
                    Console.WriteLine(i);
                }
            }
            return array;
        }
        public void PrintTwoDimensionalArray(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); ++i, Console.WriteLine())
                for (int j = 0; j < a.GetLength(1); ++j)
                    Console.Write("{0,5} ", a[i, j]);
        }
    }

    class SingleArrays
    {
        static int[] InitializingIntArray()
        {
            Console.Write("Array size: ");
            int ArraySize = int.Parse(Console.ReadLine());


            int[] Array = new int[ArraySize];
            for (int i = 0; i < ArraySize; i++)
            {
                Console.Write("Array[{0}] = ", i);
                Array[i] = int.Parse(Console.ReadLine());
            }
            return Array;
        }
        static double[] InitializingDoubleArray()
        {
            Console.Write("Array size: ");
            int ArraySize = int.Parse(Console.ReadLine());


            double[] Array = new double[ArraySize];
            for (int i = 0; i < ArraySize; i++)
            {
                Console.Write("Array[{0}] = ", i);
                Array[i] = double.Parse(Console.ReadLine());
            }
            return Array;
        }
        static double ArithmeticMeanOfNegativeElements(int[] array)
        {
            double NegativeSum = 0;
            int countNegativeElements = 0;
            foreach (int element in array)
            {
                if (element < 0)
                {
                    NegativeSum += element;
                    countNegativeElements++;
                }
            }
            Console.WriteLine(NegativeSum + "/" + countNegativeElements);
            return NegativeSum / countNegativeElements;
        }
        static void NonMultiplicitySeven(int[] array)
        {
            foreach (int element in array)
            {
                if (element % 7 != 0)
                {
                    Console.WriteLine("Array[{0}]", Array.IndexOf(array, element));
                }
            }
            //или
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 7 != 0)
                {
                    Console.WriteLine("Array[{0}]", i);
                }
            }
        }
        static int FirstMinElement(double[] array)
        {
            int index = 0;
            double min = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            foreach (double element in array)
            {
                if (element == min)
                {
                    index = Array.IndexOf(array, element);
                    break;
                }
            }
            return index;

        }
        static double MaxAbsElement(double[] array)
        {
            double max = Math.Abs(array[0]);

            foreach (double element in array)
            {
                if (Math.Abs(element) > max)
                {
                    max = Math.Abs(element);
                }
            }
            return max;
        }
        static void PrintArray(int[] a)
        {
            for (int i = 0; i < a.Length; ++i)
                Console.Write("{0,5} ", a[i]);
        }
    }
}
