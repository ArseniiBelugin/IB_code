/*lab 2_2.29
*Belugin Arseniy IB11-BO
*nomer chlena posledovatelnosti = x
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    class Program
    {
        static void Main()
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("X = ");
            int x = int.Parse(Console.ReadLine());
            int k = 0;
            string[] Input = Console.ReadLine().Split();
            for (int i = 1; i <= n; i++)
            {
                int a = int.Parse(Input[i - 1]);
                if (x == a && k == 0)
                {
                    k = i;
                };
            };
            Console.WriteLine($"Nomer elementa = {k}");
            Console.ReadKey();
        }
    }
}
/*
5
0
0 1 2 3 4
k = 1

5
0
0 0 0 0 0
k = 1

1
0
0
k = 1

5
-1
1 1 1 1 1
k = 0
*/
