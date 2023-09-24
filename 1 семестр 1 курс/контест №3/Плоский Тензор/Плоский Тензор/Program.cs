using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Плоский_Тензор
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[4001];
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int t = int.Parse(input[1]);
            int min = 4000,
                max = 0;
            int minl = 0,
                maxl = 0;
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split();
                int x = int.Parse(input[0]);
                int l = int.Parse(input[1]);
                if (min > x)
                {
                    min = x;
                    minl = l;
                }
                if (max < x)
                {
                    max = x;
                    maxl = l;
                }
                for (int j = 2*x+2000 - l; j<= 2*x+2000 + l; j++)
                {
                    if (j > 0 && j < 4001)
                    {
                        a[j] = 1;
                    }
                }
            };
            min = 2 * min + 2000 + minl;
            max = 2 * max + 2000 - maxl;
            int count = 2;
            bool flag;
            for (int i = min; i < max; i++)
            {
                flag = true;
                if (i - t + 1 < 0)
                {
                    continue; 
                }
                if (i + t - 1 > max)
                {
                    continue;
                }
                for (int j = i - t + 1; j <= i + t - 1; j++)
                {
                    if (a[j] == 1)
                    {
                        flag = false;
                    }
                }
                if (flag && ((a[i - t] == 0) && (a[i + t] == 0)))
                {
                    flag = false;
                };
                if (flag)
                {
                    count++;
                }
            };
            Console.WriteLine($"{count}");
            //Console.ReadKey();
        }
    }
}
