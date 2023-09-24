using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace _1
{
    struct point
    {
        public int x;
        public int y;
    }

    class Program
    {
        public static List<double> dist = new List<double>();

        public static void Print()
        {
            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                dist.Sort();
                dist.Remove(0);
                sw.WriteLine(dist.Count);
                for (int i = 0; i < dist.Count; i++)
                {
                    sw.WriteLine($"{dist[i]:f12}");
                }
            }
        }
        static void Main(string[] args)
        {
            point[] cords = new point[1000000];
            int n;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                n = int.Parse(sr.ReadLine());
                string[] input;
                for (int i = 0; i < n; i++)
                {
                    input = sr.ReadLine().Split();
                    cords[i].x = int.Parse(input[0]);
                    cords[i].y = int.Parse(input[1]);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    dist.Add(Math.Round(Math.Sqrt((cords[j].x - cords[i].x) * (cords[j].x - cords[i].x) + (cords[j].y - cords[i].y) * (cords[j].y - cords[i].y)), 12));
                }
            }
            dist = dist.Distinct().ToList();
            Print();
        }
    }
}