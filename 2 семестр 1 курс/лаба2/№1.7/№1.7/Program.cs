using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1._7
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            using (StreamReader sr = new StreamReader("input4.txt"))
            {
                input = sr.ReadToEnd();
            }
            Console.WriteLine(input);
            string[] lexem = input.Split(new char[] { ' ', '\t' },
                StringSplitOptions.RemoveEmptyEntries);
            Stack<KeyValuePair<string, int>> stack = new Stack<KeyValuePair<string, int>>();
            foreach (string key in lexem)
            {
                int pr = Priority(key);
                if (pr == -1)
                {
                    stack.Push(new KeyValuePair<string, int>(key, pr));
                }
                else
                {
                    StringBuilder temp = new StringBuilder();
                    if (pr == 0)
                    {
                        int num = Convert.ToInt32(stack.Pop().Key) - 1;
                        if (key == "]")
                        {
                            temp.Insert(0, "]");
                        }
                        else
                        {
                            temp.Insert(0, ")");
                        }
                        for (int i = 0; i <= num - 1; i++)
                        {
                            if (i == 0 || i == num)
                            {
                                temp.Insert(0, stack.Pop().Key);
                            }
                            else
                            {
                                temp.Insert(0, ", ");
                                temp.Insert(0, stack.Pop().Key);
                            }
                        }
                        if (key == "]")
                        {
                            temp.Insert(0, "[");
                        }
                        else
                        {
                            temp.Insert(0, "(");
                        }
                        temp.Insert(0, stack.Pop().Key);
                        stack.Push(new KeyValuePair<string, int>(temp.ToString(), 0));
                    }
                    else
                    {
                        if (pr > stack.Peek().Value && stack.Peek().Value > 0)
                        {
                            temp.Insert(0, ")");
                            temp.Insert(0, stack.Pop().Key);
                            temp.Insert(0, "(");
                        }
                        else
                        {
                            temp.Insert(0, stack.Pop().Key);
                        }
                        temp.Insert(0, " ");
                        temp.Insert(0, key);
                        temp.Insert(0, " ");
                        if (pr > stack.Peek().Value && stack.Peek().Value != -1)
                        {
                            temp.Insert(0, ")");
                            temp.Insert(0, stack.Pop().Key);
                            temp.Insert(0, "(");
                        }
                        else
                        {
                            temp.Insert(0, stack.Pop().Key);
                        }
                        stack.Push(new KeyValuePair<string, int>(temp.ToString(), pr));
                    }
                }
            }
            string answer = stack.Pop().Key;
            Console.WriteLine(answer);
            Console.ReadKey();
        }
        static int Priority(string lexem)
        {
            int pr;
            switch (lexem)
            {
                case "]": case "Ф": pr = 0; break;
                case "+": case "-": pr = 1; break;
                case "*":  pr = 2; break;
                case "^": case "/": case "%": pr = 3; break;
                default: pr = -1; break;
            }
            return pr;
        }
    }
}
