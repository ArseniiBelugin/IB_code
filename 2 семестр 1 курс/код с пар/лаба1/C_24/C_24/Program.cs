using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace C_24
{
    class Program
    {
        static int n;
        static int[] array = new int[100000];
        static int SumCheck(int init, int t)
        {
            Console.WriteLine(t);
            if (init == n - 1)
            {
                if (t % 25 == 0)
                {
                    return t;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                t = Math.Max(SumCheck(init + 1, t), SumCheck(init + 1, t + array[init]));
                return t;
            }  
        }
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    array[i] = int.Parse(Console.ReadLine());
                }
            }
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                int sum = SumCheck(i, 0);
                if (sum > max)
                {
                    max = sum;
                }
            }
            Console.WriteLine(max);
            Console.ReadKey();
        }
    }
}
