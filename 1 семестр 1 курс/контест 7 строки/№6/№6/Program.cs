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
            string line = null;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                while (!sr.EndOfStream)
                    line = sr.ReadLine();
            }
            int count = 0;
            for (int i = 0; i < line.Length - 5; i++)
            {
                if (line[i] == '>' && line [i+1] == '>' && line [i + 2] == '-' && line [i+3] == '-' && line [i + 4] == '>' || line[i] == '<' && line[i + 1] == '-' && line[i + 2] == '-' && line[i + 3] == '<' && line[i + 4] == '<')
                {
                    count++;
                }
            }
            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                sw.Write(count);
            }
        }
    }
}

