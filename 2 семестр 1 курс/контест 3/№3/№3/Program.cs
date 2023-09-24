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
            string[] input = Console.ReadLine().Split();
            int s = int.Parse(input[0]), k = int.Parse(input[1]);
            int s1 = s;
            for (int i = k; i > 0; i--)
            {
                if (s - 9 >= 0)
                {
                    Console.Write(9);
                    s = s - 9;
                }
                else
                {
                    Console.Write(s);
                    s = 0;
                }
            }
            Console.Write(' ');
            if (k > 1 && (s1 + 1) / 9 < k)
            {
                Console.Write(1);
                s1 = s1 - 1;
                k--;
            }
            for (int i = 0; i < (k - (s1 / 9 + 1)); i++)
            {
                Console.Write(0);
            }
            if (k - (s1 / 9 + 1) >= 0)
            {
                Console.Write(s1 % 9);
            }
            s1 = s1 - s1 % 9;
            for (int i = 0; i < (s1 / 9); i++)
            {
                Console.Write(9);
            }
            //Console.ReadKey();
        }
    }
}
