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
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            int[] a = new int[100000];
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split();
                for (int j = 0; j < m; j++)
                {
                    a[int.Parse(input[j]) - 1] = a[int.Parse(input[j]) - 1] + 1;
                };
            };
            for (int i = 0; i < 100000; i++)
            {
                if (a[i] == n)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            };
            Console.ReadKey();
        }
    }
}