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
                string[] input;
                int n;
                input = sr.ReadToEnd().Split();
                n = int.Parse(input[0]);
                Stack<KeyValuePair<int, int>> stack = new Stack<KeyValuePair<int, int>>();
                stack.Push(new KeyValuePair<int, int>(int.Parse(input[1]), 1));
                for (int i = 2; i <= n; i++)
                {
                    while (int.Parse(input[i]) != stack.Peek().Key && stack.Peek().Value >= 3)
                    {
                        int k = stack.Peek().Value;
                        if (k >= 3)
                        {
                            for (int j = 0; j < k; j++)
                            {
                                stack.Pop();
                            }
                        }
                    }
                    if (int.Parse(input[i]) == stack.Peek().Key)
                    {
                        stack.Push(new KeyValuePair<int, int>(int.Parse(input[i]), stack.Peek().Value + 1));
                    }
                    else
                    {
                        stack.Push(new KeyValuePair<int, int>(int.Parse(input[i]), 1));
                    }
                }
                int t = stack.Peek().Value;
                if (t >= 3)
                {
                    for (int j = 0; j < t; j++)
                    {
                        stack.Pop();
                    }
                }
                Console.WriteLine(n - stack.Count);
            }
        }
    }
}
