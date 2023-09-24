using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            string a;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                a = sr.ReadLine();
                a = a + "0";
            }
            int n = a.Length - 1;
            if (n != 0)
            {
                int[] array = new int[n];
                for (int i = 0; i < n; i++)
                {
                    array[i] = Convert.ToInt32(a[i]) - 48;
                }
                long[] vars = new long[n];
                vars[0] = 1;
                if (n >= 2)
                {
                    if (array[0] != 0 && array[0] * 10 + array[1] <= 33)
                    {
                        vars[1] = 2;
                    }
                    else
                    {
                        vars[1] = 1;
                    }
                }
                for (int i = 2; i < n; i++)
                {
                    vars[i] = vars[i - 1];
                    if (array[i - 1] != 0 && array[i - 1] * 10 + array[i] <= 33)
                    {
                        vars[i] = vars[i] + vars[i - 2];
                    }
                }
                Console.WriteLine(vars[n - 1]);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
