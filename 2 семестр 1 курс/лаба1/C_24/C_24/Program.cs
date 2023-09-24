using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace C_24
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int>[] array = new List<int>[25];
            for (int i = 0; i < 25; i++)
            {
                array[i] = new List<int>();
            }
            int n;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                n = int.Parse(sr.ReadLine());
                int k;
                for (int i = 0; i < n; i++)
                {
                    k = int.Parse(sr.ReadLine());
                    array[k % 25].Add(k);
                }
            }
            int sum = 0;
            foreach (int item in array[0])
            {
                sum += item;
            }
            for (int i = 1; i < 13; i++)
            {
                array[i].Sort();
                array[25 - i].Sort();
                int len = Math.Min(array[i].Count(), array[25 - i].Count());
                for (int j = len; j > 0; j--)
                {
                    sum = sum + array[i][j - 1] + array[25 - i][j - 1];
                }
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
