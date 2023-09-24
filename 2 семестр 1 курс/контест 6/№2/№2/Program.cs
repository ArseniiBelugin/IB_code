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
        static string Take_num (string input)
        {
            StringBuilder number = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsNumber(input[i]))
                {
                    number.Append(input[i]);
                }
            }
            return number.ToString();
        }
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("schools.in"))
            {
                using (StreamWriter sw = new StreamWriter("schools.out"))
                {
                    int n;
                    SortedList<string, int> sch = new SortedList<string, int>();
                    n = int.Parse(sr.ReadLine());
                    string num;
                    for (int i = 0; i < n; i++)
                    {
                        num = Take_num(sr.ReadLine());
                        int ind = sch.IndexOfKey(num);
                        if (ind == -1)
                        {
                            sch.Add(num, 1);
                        }
                        else
                        {
                            int temp = sch.Values[ind] + 1;
                            sch.RemoveAt(ind);
                            sch.Add(num, temp);
                        }
                    }
                    int count = 0;
                    for (int i = 0; i < sch.Count; i++)
                    {
                        if (sch.Values[i] <= 5)
                        {
                            count++;
                        }
                    }
                    sw.WriteLine(count);
                    for (int i = 0; i < sch.Count; i++)
                    {
                        if (sch.Values[i] <= 5)
                        {
                            sw.WriteLine(sch.Keys[i]);
                        }
                    }
                    //Console.ReadKey();
                }
            }
        }
    }
}
