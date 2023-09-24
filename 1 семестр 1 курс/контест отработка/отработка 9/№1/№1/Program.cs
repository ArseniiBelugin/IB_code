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
                    string[] line = sr.ReadLine().Split();
                    int n = int.Parse(line [0]);
                    int m = int.Parse(line[1]);
                    int[,] array = new int[n, m];

                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            array[i, j] = 0;
                        }
                    }
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            if ((i + 1) * (j + 1) % 2 == 0)
                            {
                                array[i, j] = 1;
                            }
                        }
                    }
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            if ((i + 1) * (j + 1) % 3 == 0)
                            {
                                array[i, j] = 2;
                            }
                        }
                    }
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            if ((i + 1) * (j + 1) % 5 == 0)
                            {
                                array[i, j] = 3;
                            }
                        }
                    }
                    int zero = 0, one = 0, two = 0, three = 0;
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            if (array[i, j] == 0)
                            {
                                zero++;
                            }
                            if (array[i, j] == 1)
                            {
                                one++;
                            }
                            if (array[i, j] == 2)
                            {
                                two++;
                            }
                            if (array[i, j] == 3)
                            {
                                three++;
                            }
                        }
                    }
                    sw.WriteLine(
                        $"RED   : {one}\n" +
                        $"GREEN : {two}\n" +
                        $"BLUE  : {three}\n" +
                        $"BLACK : {zero}\n"
                        );
                }
            }
        }
    }
}
