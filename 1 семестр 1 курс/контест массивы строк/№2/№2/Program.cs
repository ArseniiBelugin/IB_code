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
                int n = int.Parse(sr.ReadLine());
                string[] input = new string[n];
                for (int i = 0; i < n; i++)
                {
                    input[i] = sr.ReadLine();
                }
                string answer = "";
                for (int i = 0; i < input[0].Length; i++)
                {
                    char c = ' ';
                    bool flag = true;
                    for (int j = 0; j < n; j++)
                    {
                        if (input[j][i] != '?')
                        {
                            if (c == ' ')
                            {
                                c = input[j][i];
                            }
                            else
                            {
                                if (c != input[j][i])
                                {
                                    answer += '?';
                                    flag = false;
                                    break;
                                }
                            }
                        }
                    }
                    if (flag)
                    {
                        if (c == ' ')
                        {
                            answer += 'a';
                        }
                        else
                        {
                            answer += c;
                        }
                    }
                }
                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    sw.WriteLine(answer);
                }
            }
        }
    }
}
