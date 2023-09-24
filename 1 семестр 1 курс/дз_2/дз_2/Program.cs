using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace дз_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = 1;
            int count = 0;
            int [] array = new int [100000];
            int l = 0;
            while (n > 0)
            {
                if (n - k >= k + 1)
                {
                    count++;
                    n = n - k;
                    array[l] = k;
                    l++;
                }
                else
                {
                    array[l] = n;
                    n = 0;
                    count++;
                }
                k++;
            }
            Console.WriteLine(count);
            for (int i = 0; i <= l; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
