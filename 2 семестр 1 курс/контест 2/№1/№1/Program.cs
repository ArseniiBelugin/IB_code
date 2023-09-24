using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    int t = int.Parse(sr.ReadLine());
                    string [] input;
                    for (int z = 0; z < t; z++)
                    {
                        int n = int.Parse(sr.ReadLine());
                        int trues = 0;
                        int falses = 0;
                        input = sr.ReadLine().Split();
                        for(int i = 0; i < n; i++)
                        {
                            if (int.Parse(input[i]) % 2 == 0)
                            {
                                trues++;
                            }
                            else
                            {
                                falses++;
                            }
                        }
                        int m = int.Parse(sr.ReadLine());
                        input = sr.ReadLine().Split();
                        int count = 0;
                        for (int i = 0; i < m; i++)
                        {
                            if (int.Parse(input[i]) % 2 == 0)
                            {
                                count = count + trues;
                            }
                            else
                            {
                                count = count + falses;
                            }
                        }
                        sw.WriteLine(count);
                    }
                }
            }
        }
    }
}
