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
                Stack<KeyValuePair<char, int>> stack = new Stack<KeyValuePair<char, int>>();
                char input;
                int count = 0;
                while (!sr.EndOfStream)
                {
                    count++;
                    input = Convert.ToChar(sr.Read());
                    if (input == '[' || input == ']' || input == '{' || input == '}' || input == '(' || input == ')')
                    {
                        if (input == ']' || input == '}' || input == ')')
                        {
                            if (stack.Count > 0)
                            {
                                char check = stack.Peek().Key;
                                bool result = false;
                                if (check == '{' && input == '}')
                                {
                                    result = true;
                                    stack.Pop();
                                }
                                if (check == '[' && input == ']')
                                {
                                    result = true;
                                    stack.Pop();
                                }
                                if (check == '(' && input == ')')
                                {
                                    result = true;
                                    stack.Pop();
                                }
                                if (!result)
                                {
                                    //Console.WriteLine(stack.Peek().Value);]
                                    stack.Push(new KeyValuePair<char, int>(input, count));
                                    break;
                                }
                            }
                            else
                            {
                                stack.Push(new KeyValuePair<char, int>(input, count));
                                break;
                            }
                        }
                        else
                        {
                            stack.Push(new KeyValuePair<char, int>(input, count));
                        }
                    }
                }
                if (stack.Count == 0)
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine(stack.Peek().Value);
                }
                Console.ReadKey();
            }
        }
    }
}
