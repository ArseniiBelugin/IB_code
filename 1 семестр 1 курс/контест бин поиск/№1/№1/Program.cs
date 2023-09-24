using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int [] a = new int [n];
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            };
            Array.Sort(a);
            int m = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = 1; i <= m; i++)
            {
                int k = int.Parse(Console.ReadLine());
                if (k >= a[0] && k <= a[n - 1])
                {
                    int left = 0, right = n - 1;
                    while (left < right)
                    {
                        int middle = left + (right - left) / 2;
                        if (a[middle] <= k)
                        {
                            left = middle + 1;
                        }
                        else
                        {
                            right = middle;
                        }
                        
                    }
                    if (a[left] == k)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
            Console.ReadKey();
        }
    }
}
