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
            int[] a = new int[10000];
            string[] input = Console.ReadLine().Split();
            for (int i = 0; i < n; i++)
            {
                a[int.Parse(input[i]) - 1] = a[int.Parse(input[i]) - 1] + 1;
            };
            int plat = 0;
            for (int i = 0; i < 10000; i++)
            {
                if (a[i] > n / 2)
                {
                    plat = i + 1;
                    break;
                }
            };
            Console.WriteLine(plat);
            Console.ReadKey();
        }
    }
}
