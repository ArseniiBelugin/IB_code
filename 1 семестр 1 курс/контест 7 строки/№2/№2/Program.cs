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
        static int find_max(string a, string b)
        {
            if (a.Length != b.Length)
            {
                if (a.Length > b.Length)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (Convert.ToInt32(a[i]) != Convert.ToInt32(b[i]))
                    {
                        if (Convert.ToInt32(a[i]) > Convert.ToInt32(b[i]))
                        {
                            return 0;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                }
                return 0;
            }
        }
        static void Main(string[] args)
        {
            string[] input = new string[3];
            string line = null;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                while (!sr.EndOfStream)
                line = sr.ReadLine();
            }
            int k = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line [i] == ' ')
                {
                    k++;
                }
                else
                {
                    input[k] = input[k] + Convert.ToString(line[i]);
                }
            }
            int max = find_max(input[0], input[1]);
            if (find_max(input[max], input[2]) == 1)
            {
                max = 2;
            }
            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                    sw.Write(input[max]);
            }
        }
    }
}
