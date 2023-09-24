using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split();
            int[] a = new int[n + 1];
            a[0] = int.Parse(input[0]);
            for (int i = 1; i < n; i++)
            {
                a[i] = int.Parse(input[i]) + a[i - 1];
            }
            int m = int.Parse(Console.ReadLine());
            input = Console.ReadLine().Split();
            for (int i = 0; i < m; i++)
            {
                int sum = 0, k = int.Parse(input[i]);
                int left = 0, right = n;
                while (left < right)
                {
                    int middle = left + (right - left) / 2;
                    if (a[middle] < k)
                    {
                        left = middle + 1;
                    }
                    else
                    {
                        right = middle;
                    }
                }
                Console.WriteLine(left + 1);
            }
            Console.ReadKey();
        }
    }
}
