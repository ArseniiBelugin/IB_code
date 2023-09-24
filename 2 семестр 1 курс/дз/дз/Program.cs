using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _160220221OPZ
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                input = sr.ReadToEnd();
            }
            Console.WriteLine(input);
            string[] lexem = input.Split(new char[] { ' ', '\t' },
                StringSplitOptions.RemoveEmptyEntries);
            Stack<KeyValuePair<string, int>> stack = new Stack<KeyValuePair<string, int>>();
            StringBuilder opz = new StringBuilder();
            foreach (string key in lexem)
            {
                int pr = Priority(key);
                if (pr == -1)
                {
                    opz.Append(key);
                    opz.Append(" ");
                }
                else
                {
                    if (pr == 0 || stack.Count == 0 || pr > stack.Peek().Value)
                    {
                        stack.Push(new KeyValuePair<string, int>(key, pr));
                    }
                    else
                    {
                        while (stack.Count != 0 && pr <= stack.Peek().Value)
                        {
                            opz.Append(stack.Pop().Key);
                            opz.Append(" ");
                        }
                        if (key == ")" && stack.Peek().Key == "(")
                        {
                            stack.Pop();
                        }
                        else
                        {
                            stack.Push(new KeyValuePair<string, int>(key, pr));
                        }
                    }
                }
            }
            while (stack.Count != 0)
            {
                opz.Append(stack.Pop().Key);
                opz.Append(" ");
            }
            Console.WriteLine(opz.ToString());
            Console.ReadKey();
        }
        static int Priority(string lexem)
        {
            int pr;
            switch (lexem)
            {
                case "(": pr = 0; break;
                case ")": case "=": pr = 1; break;
                case ">":
                case ">=":
                case "<":
                case "<=":
                case "==":
                case "!=": pr = 6; break;
                case "+": case "-": pr = 7; break;
                case "*": case "/": case "%": pr = 8; break;
                default: pr = -1; break;

            }
            return pr;
        }
    }
}