using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2._2_Б
{
    class Program
    {
        static void Read_array (ref int n, ref int m, ref int [,] array)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string [] line;
                line = sr.ReadLine().Split();
                n = Convert.ToInt32(line[0]);
                m = Convert.ToInt32(line[1]);
                for (int i = 0; i < n; i++)
                {
                    line = sr.ReadLine().Split();
                    for (int j = 0; j < m; j++)
                    {
                        array[i, j] = Convert.ToInt32(line[j]);
                    }
                }
            }
        }
        static void Init_line (ref bool [] line)
        {
            for (int i = 0; i < 101; i++)
            {
                line[i] = false;
            }
        }
        static bool Check_line (bool [] mas, bool [] temp)
        {
            bool flag = true;
            for (int i = 0; i < 101; i++)
            {
                if (mas [i] != temp[i])
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        static void Main(string[] args)
        {
            int n = 0, m = 0;
            int[,] array = new int[100, 100];
            Read_array(ref n, ref m, ref array);
            bool [] mas = new bool [101];
            for (int i = 0; i < m; i++)
            {
                mas[array[0, i]] = true;
            }
            bool[] temp = new bool[101];
            int count = 0;
            for (int i = 1; i < n; i++)
            {
                Init_line(ref temp);

                for (int j = 0; j < m; j++)
                {
                    temp[array[i, j]] = true;
                }

                if (Check_line(mas, temp))
                {
                    count++;
                }  
            }
            Console.WriteLine(count);
            Console.ReadKey();
        }
    }
}
