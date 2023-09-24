using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            string[] input = Console.ReadLine().Split();
            for (int i = 0; i< n; i++)
            {
                a[i] = int.Parse(input[i]);
            }
            Array.Sort(a);
            for (int i = 0; i < n; i++)
            {
                a[i] = a[i] - i;
            }
            int max = 0;
            int count = max;
            for (int i = 0; i < n; i++)
            {
                if (a[i] >= max)
                {
                    if (a[i] == max)
                    {
                        count++;
                    }
                    else
                    {
                        count = 1;
                    }
                    max = a[i];
                }
            }
            Console.WriteLine(n + max + 1);
            Console.ReadKey();
        }
    }
}
