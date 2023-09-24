using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3
{
    struct str
    {
        public static bool [,] array = new bool [101,101];

        public void Add (int m, int n)
        {
            if (!array[n, m])
            {
                array[n, m] = true;
            }
        }
        public string Listset(int n)
        {
            string line = "";
            bool flag = true;
            for (int i = 0; i <= 100; i++)
            {
                if (array[n, i])
                {
                    if (flag)
                    {
                        flag = false;
                    }
                    line = line + Convert.ToString(i);
                    line = line + " ";
                }
            }
            if (flag)
            {
                return "-1";
            }
            else
            {
                return line;
            }
        }
        public string Listsetof(int m)
        {
            string line = "";
            bool flag = true;
            for (int i = 0; i <= 100; i++)
            {
                if (array[i, m])
                {
                    if (flag)
                    {
                        flag = false;
                    }
                    line = line + Convert.ToString(i);
                    line = line + " ";
                }
            }
            if (flag)
            {
                return "-1";
            }
            else
            {
                return line;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            str mno = new str();
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    string [] input;
                    input = sr.ReadLine().Split();
                    n = int.Parse(input[0]);
                    m = int.Parse(input[1]);
                    int k = int.Parse(sr.ReadLine());
                    for (int i = 0; i < k; i++)
                    {
                        input = sr.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (input[0] == "ADD")
                        {
                            mno.Add(int.Parse(input[1]), int.Parse(input[2]));
                        }
                        if (input[0] == "LISTSET")
                        {
                            sw.WriteLine (mno.Listset(int.Parse(input[1])));
                        }
                        if (input[0] == "LISTSETSOF")
                        {
                            sw.WriteLine (mno.Listsetof(int.Parse(input[1])));
                        }
                    }
                }
            }
        }
    }
}

