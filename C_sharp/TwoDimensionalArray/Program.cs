using System;
using System.Runtime.CompilerServices;

namespace TwoDimensionalArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TwoDimensionalArray arr1 = new TwoDimensionalArray(3, 4);
            double [][] arr2 = new double[3][];
            for (int i = 0; i < 3; i++) //создание двумерного массива
                arr2[i] = new double[4];
           
            for (int i = 0; i < 3; i++) //заполнение arr2
                for (int j = 0; j < 4; j++)
                    arr2[i][j] = double.Parse(Console.ReadLine());

            arr1 = arr2; //преобразование объекта класса TwoDimensionalArray в double[][]
            arr1.Print();

            TwoDimensionalArray array1 = new TwoDimensionalArray(3, 4);
            array1.KeyboardInit();
            double[][] array2 = new double[3][];
            for (int i = 0; i < 3; i++) //создание двумерного массива
                arr2[i] = new double[4];
            array2 = array1; //преобразование double[][] в объекта класса TwoDimensionalArray

            TwoDimensionalArray array = new TwoDimensionalArray(3, 4);
            array.KeyboardInit();
            array.Print();
            array.ColumnsSort();
            array.Print();
            Console.WriteLine(array.GetNumberOfElements);
            array.MultiplyElementsBy = 5;
            array.Print();
            array[2, 4] = 10;
            Console.WriteLine(array[1,1]);
            array++;
            array.Print();
        }

        public class TwoDimensionalArray
        {
            private double[][] DoubleArray;
            private int n, m;

            public TwoDimensionalArray(int n, int m)
            {
                this.n = n;
                this.m = m;

                DoubleArray = new double[n][];
                for (int i = 0; i < DoubleArray.Length; i++)
                {
                    DoubleArray[i] = new double[m];
                }
            }

            public void KeyboardInit()
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write("Array[{0}][{1}] = ", i, j);
                        DoubleArray[i][j] = Double.Parse(Console.ReadLine());
                    }
                }
            }

            public void Print()
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write(DoubleArray[i][j] + " ");
                    }
                    Console.WriteLine();
                }
            }

            public void ColumnsSort()
            {
                for (int i = 0; i < n; i++)
                {
                    Array.Sort(DoubleArray[i]);
                    Array.Reverse(DoubleArray[i]);
                }
            }

            public int GetNumberOfElements
            {
                get { return n * m; }
            }

            public int MultiplyElementsBy
            {
                set
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            DoubleArray[i][j] *= value;
                        }
                    }
                }
            }
            
            //_________________________________________14_________________________________________
            
            public double this[int RowIndex, int ColumnIndex] //индексатор
            {
                get {return DoubleArray[RowIndex][ColumnIndex];}
                set {DoubleArray[RowIndex][ColumnIndex] = value;}
            }

            public static TwoDimensionalArray operator ++ (TwoDimensionalArray array)
            {
                for (int i = 0; i < array.n; i++)
                {
                    for (int j = 0; j < array.m; j++)
                    {
                        array[i,j]++;
                    }
                }
                return array;
            }

            public static TwoDimensionalArray operator -- (TwoDimensionalArray array)
            {
                for (int i = 0; i < array.n; i++)
                {
                    for (int j = 0; j < array.m; j++)
                    {
                        array[i,j]--;
                    }
                }
                return array;
            }

            private bool IsEveryRowSorted()
            {
                int counter = 0; //количество отсортированных строк
                for (int i = 0; i < n; i++)
                {
                    Array array = DoubleArray[i];
                    Array.Sort(array);

                    if (DoubleArray[i].Equals(array))
                    {
                        counter++;
                    }
                }
                return (counter == n) ? true : false;
            }

            public static bool operator true(TwoDimensionalArray array)
            {
                return array.IsEveryRowSorted();
            }

            public static bool operator false(TwoDimensionalArray array)
            {
                return array.IsEveryRowSorted();
            }

            public static TwoDimensionalArray operator *(TwoDimensionalArray arr1, TwoDimensionalArray arr2)
            {
                if (arr1.m == arr2.m && arr1.n == arr2.n)
                {
                    for (int i = 0; i < arr1.n; i++)
                    {
                        for (int j = 0; j < arr1.m; j++)
                        {
                            arr1[i,j] *= arr2[i,j];
                        }
                    }
                }
                else
                {
                    throw new Exception(); //TODO: сделать норм исключение
                }
                return arr1;
            }
            
            public static implicit operator double[][](TwoDimensionalArray array)
            {
                double[][] arr = new double[array.n][];
                
                for (int i = 0; i < array.n; i++) {
                    arr[i] = new double[array.m];
                    for (int j = 0; j < array.m; j++)
                    {
                        arr[i][j] = array[i, j];
                    }
                }

                return arr;
            }
            
            public static implicit operator TwoDimensionalArray(double[][] array)
            {
                int n = array.Length;
                int m = array[0].Length;         
                TwoDimensionalArray arr = new TwoDimensionalArray(n, m);
                
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        arr[i,j] = array[i][j];
                    }
                }
                return arr;
            }
        }
    }
}
