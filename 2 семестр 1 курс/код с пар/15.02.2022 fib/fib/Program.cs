using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fib
{
    class Program
    {
        public static long[] value;
        public static long FibBest (int n)
        {
            long f0 = 1, f1 = 1;
            for (int i = 2; i <= n; i++)
            {
                long f2 = f0 + f1;
                f0 = f1;
                f1 = f2;
            }
            return f1;
        }
        public static long FibBT(int n)
        {
            long[] result = new long[Math.Max(2, n + 1)];
            result[0] = 1;
            result[1] = 1;
            for(int i = 2; i <= n; i++)
            {
                result[i] = result[i - 1] + result[i - 2];
            }
            return result[n];
        }
        public static long FibTB(int n)
        {
            if (value [n] == 0)
            {
                if(n < 2)
                {
                    value[n] = 1;
                }
                else
                {
                    value[n] = FibTB(n - 1) + FibTB(n - 2); 
                }
            }
            return value[n];
        }
        public static int Fibonachi (int n)
        {
            if (n < 2) return 1;
            else return Fibonachi(n - 1) + Fibonachi(n - 2);
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                value = new long[i + 1];
                Console.WriteLine($"i = {i} f({i}) = {FibTB(i)} f({i}) = {FibBT(i)} f({i}) = {FibBest(i)}");
            }
            Console.ReadKey();
        }
    }
}
