using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1._7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] rect;
            int n, min_x = 10000, min_y = 10000, max_x = -10000, max_y = -10000;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                n = int.Parse(sr.ReadLine());
                rect = new int[2 * n + 2, 2];
                string[] line;
                for (int i = 0; i < 2 * n; i++)
                {
                    line = sr.ReadLine().Split();
                    rect[i, 0] = int.Parse(line[0]);
                    rect[i, 1] = int.Parse(line[1]);
                    if (i % 2 == 0)
                    {
                        if (min_x > rect[i, 0])
                        {
                            min_x = rect[i, 0];
                        }
                        if (min_y > rect[i, 1])
                        {
                            min_y = rect[i, 1];
                        }
                    }
                    else
                    {
                        if (max_x < rect[i, 0])
                        {
                            max_x = rect[i, 0];
                        }
                        if (max_y < rect[i, 1])
                        {
                            max_y = rect[i, 1];
                        }
                    }
                }
            }
            int k = 0;
            for (int i = min_x; i < max_x; i++)
            {
                for (int j = min_y; j < max_y; j++)
                {
                    int count = 0;
                    for (int l = 0; l < 2 * n; l = l + 2)
                    {
                        if ((i >= rect[l,0] && i <= rect [l + 1, 0]) && (j >= rect [l, 1] && j <= rect[l + 1,1]))
                        {
                            count++;
                        }
                    }
                    if (count > k)
                    {
                        k = count;
                    }
                }
            }
            Console.WriteLine(k);
            Console.ReadKey();
        }
    }
}
