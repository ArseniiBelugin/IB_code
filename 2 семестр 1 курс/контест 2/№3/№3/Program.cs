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
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                int x1, x2, y1, y2;
                string[] input;
                input = sr.ReadLine().Split();
                x1 = int.Parse(input[0]);
                y1 = int.Parse(input[1]);
                input = sr.ReadLine().Split();
                x2 = int.Parse(input[0]);
                y2 = int.Parse(input[1]);
                int r = int.Parse(sr.ReadLine());
                double d = Math.Sqrt((x1 - x2)*(x1 - x2) + (y1 - y2)*(y1 - y2));
                double s1 = 0;
                if (d > 0 && d < 2 * r)
                {
                    s1 = r * r * (2 * Math.Acos(d * d / (2 * r * d)) - Math.Sin(2 * Math.Acos(d * d / (2 * r * d))));
                    s1 = 2 * Math.PI * r * r - s1;
                }
                if (d >= 2 * r)
                {
                    s1 = 2 * Math.PI * r * r;
                }
                if (d == 0)
                {
                    s1 = Math.PI * r * r;
                }
                int s2 = int.Parse(sr.ReadLine());
                if (s1 > s2)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
        }
    }
}
