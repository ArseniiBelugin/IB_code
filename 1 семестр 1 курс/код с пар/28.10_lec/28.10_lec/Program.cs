using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _28._10_lec
{
    class Program
    {
        static int [] CreateArrayRandom(int n, int a, int b)
        {
            Random Rd = new Random();
            int [] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = Rd.Next(a, b + 1);
            }
            return array;
        }
        static void print(int[] array)
        {
            foreach (int item in array)
            {
                Console.Write($"{item} ");
            }
        }
        static bool isSorted(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i-1] > array[i])
                {
                    return false;
                }
            }
            return true;
        }
        static void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSort(array, left, mid);
                MergeSort(array, mid + 1, right);
                Merge(array, left, right);
            }
        }
        static void Swap (ref int a,ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }
        static void Merge (int [] array, int left, int right)
        {
            if (right - left == 1)
            {
                if (array[left] > array[right])
                {
                    Swap(ref array[left],ref array[right]);
                    return;
                }
            }
            int[] buffer = new int[right - left + 1];
            int mid = left + (right - left) / 2;
            int idxBuffer = 0, idxLeft = left, idxRight = mid + 1;
            while (idxLeft <= mid && idxRight <= right)
            {
                if (array[idxLeft] < array[idxRight])
                {
                    buffer[idxBuffer++] = array[idxLeft++];
                }
                else
                {
                    buffer[idxBuffer++] = array[idxRight++];
                }
            }
            while(idxLeft <= mid)
            {
                buffer[idxBuffer++] = array[idxLeft++];
            }
            while (idxRight <= right)
            {
                buffer[idxBuffer++] = array[idxRight++];
            }
            for (idxBuffer = 0, idxLeft = left; idxLeft <= right; idxBuffer++, idxLeft++){
                array[idxLeft] = buffer[idxBuffer];
            }
        }
        static void QuickSort (int[] array, int left, int right)
        {
            int i = left, j = right;
            int midItem = array[left + (right - left) / 2];
            do
            {
                while (array[i] < midItem) i++;
                while (array[j] > midItem) j--;
                if (i <= j)
                {
                    Swap(ref array[i], ref array[j]);
                    i++;
                    j--;
                }
            } while (i < j);
            if (left < j) QuickSort(array, left, j);
            if (right > i) QuickSort(array, i, right);
        }
        static void Main(string[] args)
        {
            Stopwatch t = new Stopwatch();
            int N = 1000000;
            int[] massiv = CreateArrayRandom(N, 1, 100);
            int[] copyMassive = new int[N];
            Array.Copy(massiv, copyMassive, N);
            //print(massiv);
            Console.WriteLine();
            Console.WriteLine(isSorted(massiv));
            t.Start();
            MergeSort(massiv, 0, massiv.Length - 1);
            t.Stop();
            Console.WriteLine($"MergeSort : {t.ElapsedMilliseconds}");
            //print(massiv);
            Console.WriteLine();
            Console.WriteLine(isSorted(massiv));
            t = Stopwatch.StartNew();
            QuickSort(copyMassive, 0, copyMassive.Length - 1);
            t.Stop();
            Console.WriteLine($"QuickSort : {t.ElapsedMilliseconds}");
            //print(copyMassive);
            Console.WriteLine();
            Console.WriteLine(isSorted(copyMassive));
            Console.ReadKey();
        }
    }
}
