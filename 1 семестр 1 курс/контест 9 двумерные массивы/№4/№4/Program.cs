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
                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    int t = int.Parse(sr.ReadLine());
                    for (int k = 0; k < t; k++)
                    {
                        int n = int.Parse(sr.ReadLine());
                        int[,] array = new int[n, 5];
                        int[,] kolvo = new int[2, 5];
                        for (int i = 0; i <= 4; i++)
                        {
                            kolvo []
                        }
                        for (int i = 0; i < n; i++)
                        {
                            string[] line = sr.ReadLine().Split();
                            int count = 0;
                            for (int j = 0; j < 5; j++)
                            {
                                array[i, j] = Convert.ToChar(line[j]);
                                count++;
                            }
                            kolvo[i, 1] = count;
                        }
                        bool answer = true;
                        bool col1 = false;
                        bool col2 = false;
                        for (int i = 0; i < 5; i++)
                        {
                            int count = 0;
                            for (int j = 0; j < n; j++)
                            {
                                if (array[j, i] == '1')
                                {
                                    count++;
                                }
                            }
                            if (count >= n / 2)
                            {
                                if (!col1)
                                {
                                    col1 = true;
                                }
                                else
                                {
                                    if (!col2)
                                    {
                                        col2 = true;
                                    }
                                }
                            }
                        }
                        if (!(col1 && col2))
                        {
                            answer = false;
                        }

                        if (answer)
                        {
                            sw.WriteLine("YES");
                        }
                        else
                        {
                            sw.WriteLine("NO");
                        }
                    }
                }
            }
        }
    }
}
