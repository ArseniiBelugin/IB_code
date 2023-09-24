using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2
{
    class Program
    {
        static void PosLen (int n, int[] array)
        {
            int[] d = new int[n];
            for (int i = 0; i < n; i++)
            {
                d[i] = 1;
                for(int j = 0; j < i; j++)
                {
                    if (array[i] % array[j] == 0 && d[j] + 1 > d[i])
                    {
                        d[i] = d[j] + 1;
                    }
                }
            }
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                if (d[i] > max)
                {
                    max = d[i];
                }
            }
            Console.WriteLine(max);
        }
        static void Main(string[] args)
        {
            int n;
            int[] array = new int [1001];
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                n = int.Parse(sr.ReadLine());
                string [] input = sr.ReadLine().Split();
                for (int i = 0; i < n; i++)
                {
                    array[i] = int.Parse(input[i]);
                }
            }
            PosLen(n, array);
            //Console.ReadKey();
        }
    }
}
