using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]),
                w = int.Parse(input[1]),
                h = int.Parse(input[2]);
            int[] a = new int[n];
            int[] b = new int[n];
            int[] index = new int[n];
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split();
                a[i] = int.Parse(input[0]);
                b[i] = int.Parse(input[1]);
                index[i] = i + 1;
            };
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; i < n; j++)
                {
                    if (a[i] > a[j])
                    {
                        int t = a[i];
                        a[i] = a[j];
                        a[j] = t;
                        t = b[i];
                        b[i] = b[j];
                        b[j] = t;
                        t = index[i];
                        index[i] = index[j];
                        index[j] = t;
                    }
                }
            }
            int count = 0;
            if (a[0] < w || b[0] < h)
            {
                Console.WriteLine(0);
            }
            else
            {
                for (int i = 1; i < n; i++)
                {
                    if (a[i - 1] < a[i] && b[i - 1] < b[i] && )
                }
            }
        }
    }
}
