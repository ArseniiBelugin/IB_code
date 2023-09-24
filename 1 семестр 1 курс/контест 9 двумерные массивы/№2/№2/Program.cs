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
            
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                using (StreamWriter sw = new StreamWriter("output.txt")) 
                { 
                    int t = int.Parse(sr.ReadLine());
                    char [,] array = new char[101, 2];
                    for (int k = 0; k < t; k++)
                    {
                        int m = int.Parse(sr.ReadLine());
                        for (int i = 0; i < 2; i++)
                        {
                            string line = sr.ReadLine();
                            for (int j = 0; j < m; j++)
                            {
                                array[j, i] = line[j];
                            }
                        }
                        bool answer = true;
                        for (int i = 0; i < m; i++)
                        {
                            if (array[i, 0] == '1' && array[i, 1] == '1')
                            {
                                answer = false;
                                break;
                            }
                        }
                        if (answer)
                        {
                            sw.WriteLine("YES");
                        }
                        else
                        {
                            sw.WriteLine("NO");
                        }
                    }  
                }
            }
        }
    }
}
