using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace отработка_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[1001];
            string[] input = Console.ReadLine().Split();
            for (int i = 0; i < n; i++)
            {
                a[int.Parse(input[i]) - 1] = 1;
            };
            int temp = 0;
            bool first = true;
            for (int i = 1; i <= 1000; i++)
            {
                if (a[i] == 0 && a[i - 1] != 0)
                {
                    if (temp + 1 != i)
                    {  
                        if (first)
                        {
                            Console.Write($"{temp + 1}-{i}");
                            first = false;
                        }
                        else
                        {
                            Console.Write($",{temp + 1}-{i}");
                        }
                        temp = i;
                    }
                    else
                    {
                        
                        if (first)
                        {
                            Console.Write($"{i}");
                            first = false;
                        }
                        else
                        {
                            Console.Write($",{i}");
                        }
                        temp = i;
                    };
                };
                if (a[i - 1] == 0)
                {
                    temp = i;
                };
            };
            Console.ReadKey();
        }
    }
}
