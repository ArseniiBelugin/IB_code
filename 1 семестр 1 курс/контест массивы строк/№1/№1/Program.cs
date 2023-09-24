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
                string line;
                int n = int.Parse(sr.ReadLine());
                string[] answer = new string[n];
                for (int i = 0; i < n; i++)
                {
                    line = sr.ReadLine();
                    if (line[line.Length - 1] != ':')
                    {
                        line = line + ": ";
                    }
                    else
                    {
                        line = line + ' ';
                    }
                    string slot = "";
                    if (line[0] == ':' && line[1] == ':')
                    {
                        int count = 0;
                        for (int k = 2; k < line.Length - 1; k++)
                        {
                            if (line[k] == ':')
                            {
                                count++;
                            }
                        }
                        for (int k = 1; k <= 8 - count; k++)
                        {
                            answer[i] += "0000:";
                        }
                        for (int j = 2; j < line.Length; j++)
                        {
                            if (line[j] == ':')
                            {
                                for (int k = 1; k <= 4 - slot.Length; k++)
                                {
                                    answer[i] = answer[i] + '0';
                                }
                                answer[i] = answer[i] + slot + ':';
                                slot = "";
                            }
                            else
                            {
                                slot = slot + line[j];
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < line.Length - 1; j++)
                        {
                            if (line[j] == ':' && j != line.Length - 1)
                            {
                                if (j != line.Length - 1)
                                {
                                    for (int k = 1; k <= 4 - slot.Length; k++)
                                    {
                                        answer[i] = answer[i] + '0';
                                    }
                                    answer[i] = answer[i] + slot + ':';
                                    slot = "";
                                }
                                if (line[j + 1] == ':')
                                {
                                    int count = -1;
                                    for (int k = 0; k < line.Length - 2; k++)
                                    {
                                        if (line[k] == ':')
                                        {
                                            count++;
                                        }
                                    }
                                    for (int k = 1; k < 7 - count; k++)
                                    {
                                        answer[i] += "0000:";
                                    }
                                }
                            }
                            else
                            {
                                slot = slot + line[j];
                            }
                        }
                    }
                }
                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    for (int i = 0; i < answer.Length; i++)
                    {
                        sw.WriteLine(answer[i].Remove(answer[i].Length - 1, 1));
                    }
                }
            }
        }
    }
}