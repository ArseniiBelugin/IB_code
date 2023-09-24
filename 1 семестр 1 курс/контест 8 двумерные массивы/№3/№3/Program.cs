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
            int n;
            int[,] friends = new int[100, 100];
            int[] var = new int[100];
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                n = int.Parse(sr.ReadLine());
                string [] line;
                for (int i = 0; i < n; i++)
                {
                    line = sr.ReadLine().Split();
                    for (int j = 0; j < n; j++)
                    {
                        friends[i, j] = int.Parse(line[j]);
                    }
                }
                line = sr.ReadLine().Split();
                line = sr.ReadLine().Split();
                for (int i = 0; i < n; i++)
                {
                    var[i] = int.Parse(line[i]);
                }
            }
            int couple = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (i < j)
                    {
                        if (friends[i, j] == 1)
                        {
                            if (var[i] != var[j])
                            {
                                couple++;
                            }
                        }
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                sw.WriteLine(couple);
            }
        }
    }
}
