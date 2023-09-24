using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2
{
    class Program
    {
        static bool Zerofound (int [,] a, int r, int s)
        {
            for (int i = 1; i <= r; i++)
            {
                for (int j = 1; j <= s; j++)
                {
                    if (a[i, j] == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static void FindMax (ref int [,] a, int r, int s)
        {
            int sum = 0;
            int max = 0;
            int n = 1;
            int m = 1;
            for (int i = 1; i <= r; i++)
            {
                sum = 0;
                for (int j = 1; j <= s; j++)
                {
                    sum = a[i, j - 1] + a[i + 1, j - 1] + a[i + 1, j] + a[i + 1, j + 1] + a[i, j + 1] + a[i - 1, j + 1] + a[i - 1, j] + a[i - 1, j - 1];
                    if(sum > max && a[i, j] == 0)
                    {
                        max = sum;
                        n = i;
                        m = j;
                    }
                }
            }
            a[n, m] = 1;
        }
        static void Main(string[] args)
        {
            int r, s;
            int[,] array = new int[52, 52];
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string[] line = sr.ReadLine().Split();
                r = int.Parse(line[0]);
                s = int.Parse(line[1]);
                for (int i = 1; i <= r; i++)
                {
                    line = sr.ReadLine().Split();
                    for (int j = 1; j <= s; j++)
                    {
                        array[i, j] = int.Parse(line [j - 1]);
                    }
                }
            }
            if (Zerofound(array, r, s))
            {
                FindMax(ref array, r, s);
            }
            int sum = 0;
            for (int i = 1; i <= r; i++)
            {
                for (int j = 1; j <= s; j++)
                {
                    if (array[i, j] == 1)
                    {
                        sum += array[i, j - 1] + array[i + 1, j - 1] + array[i + 1, j] + array[i + 1, j + 1] + array[i, j + 1] + array[i - 1, j + 1] + array[i - 1, j] + array[i - 1, j - 1];
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                sw.WriteLine(sum / 2);
                /*for (int i = 0; i <= r + 1; i++)
                {
                    sw.WriteLine();
                    for (int j = 0; j <= s + 1; j++)
                    {
                        sw.Write($"{array[i, j]} ");
                    }
                }*/
            }
        }
    }
}
