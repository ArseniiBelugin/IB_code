using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                n = int.Parse(sr.ReadLine());
            }
            n = n-1;
            string [,] array = new string[n, n];
            for (int i = 0; i < n; i++)
            {
                array[0, i] = Convert.ToString(i + 1);
                array[i, 0] = Convert.ToString(i + 1);
            }
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    int k = Convert.ToInt32(array[i, 0]) * Convert.ToInt32(array[0, j]);
                    while (k != 0)
                    {
                        array[i, j] = Convert.ToString(k % (n + 1)) + array[i, j];
                        k = k / (n + 1);
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        sw.Write($"{array[i, j]} ");
                    }
                    sw.WriteLine();
                }
            }
        }
    }
}
