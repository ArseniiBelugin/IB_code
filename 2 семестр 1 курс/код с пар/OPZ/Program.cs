using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OPZ
{
    class Program
    {
        static int priority (string lexem)
        {
            int pr;
            switch (lexem)
            {
                case "(": pr = 0;break;
                case ")": case "=": pr = 1; break;
                case ">": case ">=": case "<": case "==": case "<=": case "!=": pr = 6; break;
                case "+": case "-": pr = 7; break;
                case "*": case "/": case "%": pr = 8; break;
                case "^": pr = 9; break;
                default: pr = -1; break;
            }
            return pr;
        }
        static void Main(string[] args)
        {
            string line;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                line = sr.ReadLine();
            }
            Console.WriteLine(line);
            string[] lexems = line.Split(new char[] { ' ', '\t', '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries);
            Stack<KeyValuePair<string, int>> stack = new Stack<KeyValuePair<string, int>>();
            StringBuilder opz = new StringBuilder();
            foreach (string lexem in lexems)
            {
                int pr = priority(lexem);
                if (pr == -1)
                {
                    opz.Append(lexem + " ");
                }
                else
                {
                    if (pr == 0 || stack.Count == 0 || pr > stack.Peek().Value)
                    {
                        stack.Push(new KeyValuePair<string, int>(lexem, pr));
                    }
                    else
                    {
                        while (stack.Count != 0 && pr<= stack.Peek().Value)
                        {
                            opz.Append(stack.Pop().Key + " ");
                        }
                        if (lexem == ")" && stack.Peek().Key == "(")
                        {
                            stack.Pop();
                        }
                        else
                        {
                            stack.Push(new KeyValuePair<string, int>(lexem, pr));
                        }
                    }
                }
            }
            while (stack.Count != 0)
            {
                opz.Append(stack.Pop().Key + " ");
            }
            Console.WriteLine("OPZ : {0}", opz.ToString());
            Console.ReadKey();
        }
    }
}
