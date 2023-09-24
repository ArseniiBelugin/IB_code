using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                int x1, x2, xr, y1, y2, yr, r;
                string[] input = sr.ReadLine().Split();
                x1 = int.Parse(input[0]);
                y1 = int.Parse(input[1]);
                x2 = int.Parse(input[2]);
                y2 = int.Parse(input[3]);
                input = sr.ReadLine().Split();
                xr = int.Parse(input[0]);
                yr = int.Parse(input[1]);
                r = int.Parse(input[2]);
                double a = (y2 - y1);
                double b = (x2 - x1);
                double c = -(y1 * x2 - x1 * y2);
                double AB = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
                double AO = Math.Sqrt((x1 - xr) * (x1 - xr) + (y1 - yr) * (y1 - yr));
                double BO = Math.Sqrt((xr - x2) * (xr - x2) + (yr - y2) * (yr - y2));
                double d;
                if (AO * AO + AB * AB >= BO * BO && BO * BO + AB * AB >= AO * AO)
                {
                    d = Math.Abs(a * xr + b * yr + c) / Math.Sqrt(a * a + b * b);
                    Console.WriteLine(d);
                }
                else
                {
                   d = Math.Min(Math.Sqrt((x1 - xr) * (x1 - xr) + (y1 - yr) * (y1 - yr)), (Math.Sqrt((x2 - xr) * (x2 - xr) + (y2 - yr) * (y2 - yr))));
                }
                if (d >= r)
                {
                    Console.WriteLine($"{AB:f3}");
                }
                else
                {
                    //double dlina = 2 * Math.Sqrt(r * r - d * d);
                    //double l = 2 * Math.Acos(d / r) * r;
                    //Console.WriteLine($"{AB - dlina + l:f3}");
                    Console.WriteLine($"{AB - 2 * Math.Sqrt(r * r - d * d) + 2 * Math.Acos(d / r) * r:f3}");
                }
            }
            Console.ReadKey();
        }
    }
}
