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
            int n, m;
            char c;
            char[,] map = new char[102, 102];
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string[] line;
                line = sr.ReadLine().Split();
                n = int.Parse(line[0]);
                m = int.Parse(line[1]);
                c = char.Parse(line[2]);
                for (int i = 1; i <= n; i++)
                {
                    string inp = sr.ReadLine();
                    for (int j = 1; j <= m; j++)
                    {
                        map[i, j] = Convert.ToChar(inp[j - 1]);
                    }
                }
            }
            int count = 0;
            bool[] a = new bool[26];
            a[Convert.ToInt32(c) - 65] = true;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (map [i, j] == c)
                    {
                        if (Char.IsLetter(map [i - 1, j])&& map [i - 1, j] != c && !a[Convert.ToInt32(map[i-1,j]) - 65])
                        {
                            count++;
                            a[Convert.ToInt32(map[i - 1, j]) - 65] = true;
                        }
                        if (Char.IsLetter(map[i, j - 1]) && map[i, j - 1] != c && !a[Convert.ToInt32(map[i, j - 1]) - 65])
                        {
                            count++;
                            a[Convert.ToInt32(map[i, j - 1]) - 65] = true;
                        }
                        if (Char.IsLetter(map[i + 1, j]) && map[i + 1, j] != c && !a[Convert.ToInt32(map[i + 1, j]) - 65])
                        {
                            count++;
                            a[Convert.ToInt32(map[i + 1, j]) - 65] = true;
                        }
                        if (Char.IsLetter(map[i, j + 1]) && map[i, j + 1] != c && !a[Convert.ToInt32(map[i, j + 1]) - 65])
                        {
                            count++;
                            a[Convert.ToInt32(map[i, j + 1]) - 65] = true;
                        }
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                sw.WriteLine(count);
            }
        }
    }
}
