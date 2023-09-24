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
                n = int.Parse(sr.ReadLine());
                input = sr.ReadLine().Split();
                Stack<int> stack = new Stack<int>();
                List <KeyValuePair<int, int>> ans = new List<KeyValuePair<int, int>>();
                if (n == 1)
                {
                    Console.WriteLine("1 1");
                    Console.WriteLine("2 1");
                }
                else
                {
                    stack.Push(int.Parse(input[0]));
                    int first = 1;
                    int cab_in = 1;
                    if (int.Parse(input[0]) == first)
                    {
                        first++;
                        ans.Add(new KeyValuePair<int, int>(1, 1));
                        ans.Add(new KeyValuePair<int, int>(2, 1));
                        cab_in = 0;
                        stack.Pop();
                    }
                    for (int i = 1; i < n; i++)
                    {
                        if (int.Parse(input[i]) != first)
                        {
                            stack.Push(int.Parse(input[i]));
                            cab_in++;
                        }
                        else
                        {
                            ans.Add(new KeyValuePair<int, int>(1, cab_in + 1));
                            cab_in = 0;
                            first++;
                            int cab_out = 1;
                            while (stack.Count != 0 && stack.Peek() == first)
                            {
                                first++;
                                cab_out++;
                                stack.Pop();
                            }
                            ans.Add(new KeyValuePair<int, int>(2, cab_out));
                            cab_out = 0;
                        }
                    }
                    if (stack.Count != 0)
                    {
                        Console.WriteLine(0);
                    }
                    else
                    {
                        for (int i = 0; i < ans.Count;i++)
                        {
                            Console.WriteLine($"{ans[i].Key} {ans[i].Value}");
                        }
                    }
                }
                //Console.ReadKey();
            }
        }
    }
}
