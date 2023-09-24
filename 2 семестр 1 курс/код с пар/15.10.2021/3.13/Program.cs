/*lab 2_3.13
*Belugin Arseniy IB11-BO
*max summa 2 elementov s intervalom bolche 7 minyt
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    class Program
    {
        static void Main()
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            int k = 0;
            int max = 0;
            int sum = 0;
            int[] a = new int[7];
            for (int i = 1; i <= 7; i++)
            {
                int b = int.Parse(Console.ReadLine());
                a[i - 1] = b;
            };
            for (int i = 8; i <= n; i++)
            {
                int b = int.Parse(Console.ReadLine());
                if (a[0] > max)
                {
                    max = a[0];
                };
                Swap(a);
                a[6] = b;
                if (b + max > sum)
                {
                    sum = b + max;
                };
            };
            Console.WriteLine($"Summa = {sum}");
            Console.ReadKey();
        }
        static void Swap(int[] a)
        {
            for (int j = 0; j <= 5; j++)
            {
                a[j] = a[j + 1];
            };
        }
    }
}
/*
10
1
1
1
1000
1000
1
1
1
1
1
summa = 2

8
10
10000
10000
10000
10000
10000
10000
1
summa = 11

10
1
2
3
4
5
6
7
8
9
10
summa = 13
*/
