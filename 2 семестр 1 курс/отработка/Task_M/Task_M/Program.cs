using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task_M
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                using(StreamWriter sw = new StreamWriter("output.txt"))
                {
                    int n;
                    Stack<KeyValuePair<int, int>> stack = new Stack <KeyValuePair<int, int>>();
                    n = int.Parse(sr.ReadLine());
                    string[] input;
                    for (int i = 0; i < n; i++)
                    {
                        input = sr.ReadLine().Split();
                        if (input[0] == "push")
                        {
                            int max = int.Parse(input[1]);
                            if (stack.Count == 0)
                            {
                                stack.Push(new KeyValuePair<int, int>(int.Parse(input[1]), int.Parse(input[1])));
                            }
                            else
                            {
                                if (stack.Peek().Value > max)
                                {
                                    max = stack.Peek().Value;
                                }
                                stack.Push(new KeyValuePair<int, int>(int.Parse(input[1]), max));
                            }
                        }
                        if (input[0] == "max")
                        {
                            if (stack.Count > 0)
                            {
                                sw.WriteLine(stack.Peek().Value);
                            }
                        }
                        if (input[0] == "pop")
                        {
                            if (stack.Count > 0)
                            {
                                stack.Pop();
                            }
                        }
                    }
                }
            }
        }
    }
}
