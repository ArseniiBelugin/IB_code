/*
 * lab 3 #1
 * Belugin Arseniy IB-11 BO
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_4
{
    class Program
    {
        static void swap_int(ref int a, ref int b)
        {

            int t = a;
            a = b;
            b = t;
        }
        static void swap_double(ref double a, ref double b)
        {

            double t = a;
            a = b;
            b = t;
        }
        static void Write_int(string TypeOut, int N, string NameSet, int Size_array, int[] Massiv_int, int t)
        {
            using (StreamWriter sw = File.AppendText("output.txt"))
            {
                if (TypeOut == "row")
                {
                    sw.WriteLine(NameSet + t);
                    sw.WriteLine(Size_array);
                    for (int j = 0; j < Massiv_int.Length; j++)
                    {
                        sw.Write($"{Massiv_int[j]} ");
                    }
                    sw.WriteLine();
                }
                else
                {
                    sw.WriteLine(NameSet + t);
                    sw.WriteLine(Size_array);
                    for (int j = 0; j < Massiv_int.Length; j++)
                    {
                        sw.WriteLine($"{Massiv_int[j]} ");
                    }
                    sw.WriteLine();
                }
            }
        }
        static void Create_Array_int(ref int[] a, int min, int max)
        {
            Random randomize = new Random();
            for (int i = 0; i < a.Length; i++) a[i] = randomize.Next(min, max);

        }
        static void Create_Array_double(ref double[] a, int min, int max)
        {
            Random randomize = new Random();
            for (int i = 0; i < a.Length; i++) a[i] = randomize.NextDouble() * (max - min) + min;

        }
        static void NoRepeat_int(ref int[] a, int min, int max)
        {
            Random rn = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                bool flag = true;
                while (flag)
                {
                    int t = rn.Next(min, max);
                    bool last = true;
                    for (int j = 0; j < a.Length; j++)
                    {
                        if (t == a[j] && i != j)
                        {
                            last = false;
                            break;
                        }
                    }
                    if (last)
                    {
                        a[i] = t;
                        flag = false;
                    }
                }
            }
        }
        static void NoRepeat_double(ref double[] a, int max, int min)
        {
            Random rn = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rn.NextDouble() * (max - min) + min;
                for (int j = 0; j < a.Length; j++)
                {
                    if (a[i] == a[j] && i != j)
                    {
                        a[i] = rn.NextDouble() * (max - min) + min;
                        break;
                    }
                }
            }
        }
        static void QuickSort_int(int[] array, int left, int right)
        {
            int i = left, j = right;
            int midItem = array[left + (right - left) / 2];
            do
            {
                while (array[i] < midItem) i++;
                while (array[j] > midItem) j--;
                if (i <= j)
                {
                    swap_int(ref array[i], ref array[j]);
                    i++;
                    j--;
                }
            } while (i < j);
            if (left < j) QuickSort_int(array, left, j);
            if (right > i) QuickSort_int(array, i, right);
        }
        static void QuickSort_double(double[] array, int left, int right)
        {
            int i = left, j = right;
            double midItem = array[left + (right - left) / 2];
            do
            {
                while (array[i] < midItem) i++;
                while (array[j] > midItem) j--;
                if (i <= j)
                {
                    swap_double(ref array[i], ref array[j]);
                    i++;
                    j--;
                }
            } while (i < j);
            if (left < j) QuickSort_double(array, left, j);
            if (right > i) QuickSort_double(array, i, right);
        }

        static void Write_double(string TypeOut, int N, string NameSet, int Size_array, double[] Massiv_double, int t)
        {
            using (StreamWriter sw = File.AppendText("output.txt"))
            {
                if (TypeOut == "row")
                {
                    sw.WriteLine(NameSet + t);
                    sw.WriteLine(Size_array);
                    for (int j = 0; j < Massiv_double.Length; j++)
                    {
                        sw.Write($"{Massiv_double[j]:f5}" + " ");

                    }
                    sw.WriteLine();
                }
                else
                {
                    sw.WriteLine(NameSet + t);
                    sw.WriteLine(Size_array);
                    for (int j = 0; j < Massiv_double.Length; j++)
                    {
                        sw.WriteLine($"{Massiv_double[j]:f5}" + " ");
                    }
                    sw.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            Random randomize = new Random();
            Console.Write("Set Name: ");
            string NameSet = Console.ReadLine();

            Console.Write("N = ");
            int N = int.Parse(Console.ReadLine());

            Console.Write("Type: ");
            string Type = Console.ReadLine();

            Console.Write("Min = ");
            int Min = int.Parse(Console.ReadLine());

            Console.Write("Max = ");
            int Max = int.Parse(Console.ReadLine());

            Console.Write("MinLen = ");
            int MinLen = int.Parse(Console.ReadLine());

            Console.Write("MaxLen = ");
            int MaxLen = int.Parse(Console.ReadLine());

            Console.Write("Repeat: ");
            string repeat = Console.ReadLine();

            Console.Write("Sort: ");
            string sort = Console.ReadLine();

            Console.Write("TypeOut: ");
            string TypeOut = Console.ReadLine();



            for (int t = 1; t <= N; t++)
            {
                int Size_array = randomize.Next(MinLen, MaxLen);
                if (Type == "int")
                {
                    int[] Massiv_int = new int[Size_array];
                    Create_Array_int(ref Massiv_int, Min, Max);
                    if (repeat == "no") NoRepeat_int(ref Massiv_int, Min, Max);

                    if (sort == "asc") QuickSort_int(Massiv_int, 0, Massiv_int.Length - 1);
                    if (sort == "desc")
                    {
                        QuickSort_int(Massiv_int, 0, Massiv_int.Length - 1);
                        Array.Reverse(Massiv_int);
                    }

                    Write_int(TypeOut, N, NameSet, Size_array, Massiv_int, t);
                }

                if (Type == "double")
                {
                    double[] Massiv_double = new double[Size_array];
                    Create_Array_double(ref Massiv_double, Min, Max);
                    if (repeat == "no") NoRepeat_double(ref Massiv_double, Max, Min);
                    if (sort == "asc") QuickSort_double(Massiv_double, 0, Massiv_double.Length - 1);
                    if (sort == "desc")
                    {
                        QuickSort_double(Massiv_double, 0, Massiv_double.Length - 1);
                        Array.Reverse(Massiv_double);
                    }
                    Write_double(TypeOut, N, NameSet, Size_array, Massiv_double, t);
                }

            }
        }
    }
}
/*
test
2
int
2
10
4
10
no
asc
row


input
3
double
0
1
2
10
no
none
col
 */