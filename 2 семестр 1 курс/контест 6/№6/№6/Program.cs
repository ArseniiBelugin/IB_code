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
                int n, m;
                n = int.Parse(sr.ReadLine());
                int[] array = sr.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                m = int.Parse(sr.ReadLine());
                Stack<KeyValuePair<int, int>> stack = new Stack<KeyValuePair<int, int>>();
                Stack<KeyValuePair<int, int>> stack_temp = new Stack<KeyValuePair<int, int>>();
                int max = 0;
                if (m == 1)
                {
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write($"{array[i]} ");
                    }
                }
                else
                {
                    for (int j = 0; j < m - 1; j++)
                    {
                        if (array[j] > max)
                        {
                            max = array[j];
                        }
                        stack.Push(new KeyValuePair<int, int>(array[j], max));
                    }
                    for (int i = m - 1; i < n; i++)
                    {
                        if (array[i] > max)
                        {
                            Console.Write($"{array[i]} ");
                        }
                        else
                        {
                            Console.Write($"{max} ");
                        }
                        stack.Push(new KeyValuePair<int, int>(array[i], max));
                        max = array[i];
                        while (stack.Count > 1)
                        {
                            if (stack.Peek().Key > max)
                            {
                                max = stack.Peek().Key;
                            }
                            stack_temp.Push(new KeyValuePair<int, int>((stack.Peek().Key), max));
                            stack.Pop();
                        }
                        stack.Pop();
                        while (stack_temp.Count != 0)
                        {
                            stack.Push(stack_temp.Pop());
                        }
                    }
                }
                //Console.ReadKey();
            }
        }
    }
}