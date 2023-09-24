using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_06_b._8
{
    class Program
    {
        static bool Check_array (int a, int b, int c, int d)
        {
            int [] mas = new int[4] { a, b, c, d };
            Array.Sort(mas);
            if (mas [0] * mas [3] == mas [1] * mas[2] && mas [0] != mas [1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Print_array (int [,] array, int a, int b, int c, int d)
        {
            for (int i = a; i <= c; i++)
            {
                for (int j = b; j <= d; j++)
                {
                    Console.Write($"{array [i, j]} ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int n, m;
            int[,] array = new int[10000, 10000];
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string[] line;
                line = sr.ReadLine().Split();
                n = int.Parse(line[0]);
                m = int.Parse(line[1]);
                for (int i = 0; i < n; i++)
                {
                    line = sr.ReadLine().Split();
                    for (int j = 0; j < m; j++)
                    {
                        array[i, j] = int.Parse(line[j]);
                    }
                }
            }
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < m - 1; j++)
                    {
                        for (int k = i + 1; k < n; k++)
                        {
                            for (int l = j + 1; l < m; l++)
                            {
                                if (Check_array(array[i, j], array[i, l], array[k, j], array[k, l]))
                                {
                                    Print_array(array, i, j, k, l);
                                }
                            }
                        }
                    }
                }
            Console.ReadKey();
        }
    }
}
