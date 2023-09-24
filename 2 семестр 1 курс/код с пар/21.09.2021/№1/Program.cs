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
            string[] Input1 = Console.ReadLine().Split();
            int a1 = int.Parse(Input1[0]),
            b1 = int.Parse(Input1[1]);
            string[] Input2 = Console.ReadLine().Split();
            int a2 = int.Parse(Input2[0]),
            b2 = int.Parse(Input2[1]);
            string[] Input3 = Console.ReadLine().Split();
            int a3 = int.Parse(Input3[0]),
            b3 = int.Parse(Input3[1]);
            int a = a1 - a3;
            int b = b1 - b2;
            Console.WriteLine($"{a} {b}");
            Console.ReadKey();
        }
    }
}
