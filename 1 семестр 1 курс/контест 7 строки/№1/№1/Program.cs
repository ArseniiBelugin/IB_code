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
            string[] input = new string[2];
            int i = 0;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                while (!sr.EndOfStream)
                {
                    input[i] = sr.ReadLine();
                    i++;
                }
            }
            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                for (i = 0; i < input[0].Length; i++)
                {
                    bool a;
                    bool b;
                    if (input[0][i] == '0')
                    {
                        a = false;
                    }
                    else
                    {
                        a = true;
                    }
                    if (input[1][i] == '0')
                    {
                        b = false;
                    }
                    else
                    {
                        b = true;
                    }
                    sw.Write(Convert.ToInt32(!a && b || a && !b));
                }
            }
        }
    }
}
