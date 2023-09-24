using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace _2
{
    struct id
    {
        public string name;
        public int num;
    }
    class Program
    {
        static id[] array = new id [1000000];
        public static int Check(string a, int len)
        {
            bool flag = true;
            int temp = 0;
            for (int i = 0; i <= len; i++)
            {
                if (array[i].name == a)
                {
                    flag = false;
                    array[i].num++;
                    temp = array[i].num;
                    break;
                }
            }
            if (flag)
            {
                return -1;
            }
            else
            {
                return temp;
            }
        }
        static void Main(string[] args)
        {
            int n;
            int k = 0;
            int t;
            for (int i = 0; i < array.Length; i++)
            {
                array[i].name = "";
                array[i].num = 0;
            }
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                using (StreamWriter sw = new StreamWriter("output.txt")) 
                {
                    n = int.Parse(sr.ReadLine());
                    string input;
                    for (int i = 0; i < n; i++)
                    {
                        input = sr.ReadLine();
                        t = Check(input, k);
                        if (t == -1)
                        {
                            array[k].name = input;
                            k++;
                            sw.WriteLine("OK");
                        }
                        else
                        {
                            sw.WriteLine($"{input}{t}");
                        }
                    }
                }
            }
        }
    }
}
