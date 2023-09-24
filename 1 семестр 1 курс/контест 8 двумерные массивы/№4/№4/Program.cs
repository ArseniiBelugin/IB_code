using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            int[,] array = new int[10001, 10001];
            bool[] num = new bool [10001];
            for (int i = 0; i <= 10000; i++)
            {
                num[i] = true;
            }
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                n = int.Parse(sr.ReadLine());
                string[] line;
                for (int i = 0; i < n; i++)
                {
                    line = sr.ReadLine().Split();
                    for (int j = 0; j < n; j++)
                    {
                        array[i, j] = int.Parse(line[j]);
                        if (array [i, j] != 0)
                        {
                            num[array[i, j]] = false;
                        }
                        
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (array [i, j] == 0)
                    {
                        for (int k = 1; k <= n * n; k++)
                        {
                            if (num[k])
                            {
                                num[k] = false;
                                array[i, j] = k;
                                break;
                            }
                        }
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