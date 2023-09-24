using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n + 1];
            string[] input = Console.ReadLine().Split();
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(input[i]);
            };
            int m = int.Parse(Console.ReadLine());
            input = Console.ReadLine().Split();
            for (int i = 0; i < m; i++)
            {
                int k = int.Parse(input[i]);
                int count = 0;
                if (k >= a[0] && k <= a[n - 1])
                {
                    int left = 0, right = n - 1;
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
                    while (left < n && a[left] == k)
                    {
                        count++;
                        left++;
                    } 
                }
                Console.WriteLine(count);
            }
        }
    }
}
