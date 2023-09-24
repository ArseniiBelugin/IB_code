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
            long a = 1, b = 1;
            int k = 1;
            long n = int.Parse(Console.ReadLine());
            if (n != 0)
            {
                while (n > b)
                {
                    b = a + b;
                    a = b - a;
                    k++;
                }
                char[] s = new char[k];
                for (int i = 0; i < k; i++)
                {
                    s[i] = '0';
                }
                while (n != 0)
                {
                    if (/*s[k] != '1' &&*/ n - b >= 0)
                    {
                        n = n - b;
                        s[k - 1] = '1';
                    }
                    a = b - a;
                    b = b - a;
                    k--;
                }
                for (int i = s.Length - 1; i >= 0; i--)
                {
                    if (i != s.Length - 1 || s[i] != '0')
                    {
                        Console.Write(s[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine(0);
            }
            Console.ReadKey();
        }
    }
}
