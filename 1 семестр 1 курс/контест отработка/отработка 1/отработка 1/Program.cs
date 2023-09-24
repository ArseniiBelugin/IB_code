using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace отработка_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            int sum = 0;
            int[] a = new int[m];
            int[] b = new int[m];
            for (int i = 0; i < m; i++)
            {
                input = Console.ReadLine().Split();
                a[i] = int.Parse(input[0]);
                b[i] = int.Parse(input[1]);
            };
            for (int i = 0; i < m - 1; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    if (b[i] < b[j])
                    {
                        int t = a[i];
                        a[i] = a[j];
                        a[j] = t;
                        t = b[i];
                        b[i] = b[j];
                        b[j] = t;
                    };
                };
            };
            int l = 0;
            while (n > 0 && l != m)
            {
                if (n - a[l] >= 0)
                {
                    sum = sum + a[l] * b[l];
                }
                else
                {
                    sum = sum + n * b[l];
                };
                n = n - a[l];
                l++;
            };
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
