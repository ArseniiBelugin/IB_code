using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            { 
            int n = int.Parse(sr.ReadLine());
            int i, maxX = 0, minY = 0, maxY = 0, cntY = 0;
            string[] Input;
            for (i = 1; i <= n; i++)
            {
                Input = sr.ReadLine().Split();
                int x = int.Parse(Input[0]);
                int y = int.Parse(Input[1]);
                if (x == 0)
                {
                    if (cntY == 0)
                    {
                        minY = maxY = y;
                        cntY = 1;
                    }
                    else
                    {
                        if (y > maxY)
                        {
                            maxY = y;
                        };
                        if (y < minY)
                        {
                            minY = y;
                        };
                    };
                }
                else
                {
                    if (Math.Abs(x) > maxX)
                    {
                        maxX = Math.Abs(x);
                    };
                };
            };
            double square = Math.Abs(maxY - minY) * maxX / 2.0;
            Console.WriteLine($"{square}");
        }
            Console.ReadKey();
        }
    }
}
