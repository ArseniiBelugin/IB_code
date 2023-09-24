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
            string[] Input1 = Console.ReadLine().Split();
            int a = int.Parse(Input1[0]);
            int b = int.Parse(Input1[1]);
            int len = int.Parse(Input1[2]);
            int n = int.Parse(Input1[3]);
            int k = a + (n - 1) * 2 * (a + b) + 2 * len;
            Console.WriteLine($"{k}");
            Console.ReadKey();
        }
    }
}
