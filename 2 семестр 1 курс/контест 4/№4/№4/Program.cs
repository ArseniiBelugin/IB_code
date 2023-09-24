using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _4
{
    class Program
    {
            

        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string a, b;
                a = sr.ReadLine();
                b = sr.ReadLine();
                int diff;
                int[,] array = new int[a.Length + 1, b.Length + 1];
                for (int i = 0; i <= a.Length; i++) 
                {
                    array[i, 0] = i; 
                }
                for (int i = 0; i <= b.Length; i++) 
                { 
                    array[0, i] = i; 
                }
                for (int i = 1; i <= a.Length; i++)
                {
                    for (int j = 1; j <= b.Length; j++)
                    {
                        if (a[i - 1] == b[j - 1])
                        { 
                            diff = 0;
                        }
                        else
                        {
                            diff = 1;
                        }
                        array[i, j] = Math.Min(Math.Min(array[i - 1, j] + 1, array[i, j - 1] + 1), array[i - 1, j - 1] + diff);
                    }
                }
                Console.WriteLine(array[a.Length, b.Length]);
                //Console.ReadKey();
            }
        }
    }
}
