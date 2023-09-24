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
            int[] a = new int[n];
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(input[i]);
                sum = sum + a[i];
            };
            Array.Sort(a);
            int left = 0, right = n - 1;
            int k = (sum - 1) / n;
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
            if (a[left] != k)
            {
                if ()
            }
            else
            {
                while (left < n && a[left] == k)
                {
                    left++;
                };
            }
            int count = a[left - 1] + n - left + 1;
            Console.WriteLine(count - 1);
            Console.ReadKey();
        }
    }
}
