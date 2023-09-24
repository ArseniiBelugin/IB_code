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
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    int t = int.Parse(sr.ReadLine());
                    string[] input;
                    for (int z = 0; z < t; z++)
                    {
                        long w, h;
                        input = sr.ReadLine().Split();
                        w = int.Parse(input[0]);
                        h = int.Parse(input[1]);
                        input = sr.ReadLine().Split();
                        long min_XO = int.Parse(input[1]), max_XO = int.Parse(input[int.Parse(input[0])]);
                        input = sr.ReadLine().Split();
                        long min_XH = int.Parse(input[1]), max_XH = int.Parse(input[int.Parse(input[0])]);
                        input = sr.ReadLine().Split();
                        long min_OX = int.Parse(input[1]), max_OX = int.Parse(input[int.Parse(input[0])]);
                        input = sr.ReadLine().Split();
                        long min_WX = int.Parse(input[1]), max_WX = int.Parse(input[int.Parse(input[0])]);
                        long s_XO = (max_XO - min_XO) * h;
                        long s_OX = (max_OX - min_OX) * w;
                        long s_XH = (max_XH - min_XH) * h;
                        long s_WX = (max_WX - min_WX) * w;
                        sw.WriteLine(Math.Max(Math.Max(s_XO, s_OX), Math.Max(s_XH, s_WX)));
                    }
                }
            }
        }
    }
}
