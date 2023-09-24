using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                int n = int.Parse(sr.ReadLine());
                string[] input = new string[n];
                int count = 1;
                int ten = 0;
                int k = 0;
                input[0] = sr.ReadLine();
                int a = (Convert.ToInt32(input[0][1]) - 48)* 600 + (Convert.ToInt32(input[0][2]) - 48) * 60 + (Convert.ToInt32(input[0][4])- 48) * 10 + (Convert.ToInt32(input[0][5]) - 48);
                if (input[0][7] == 'p')
                {
                    a = a + 720;
                }

                for (int i = 1; i < n; i++)
                {
                    input[i] = sr.ReadLine();
                    int hh = (Convert.ToInt32(input[i][1]) - 48) * 600 + (Convert.ToInt32(input[i][2]) - 48) * 60;
                    int mm = (Convert.ToInt32(input[i][4]) - 48) * 10 + (Convert.ToInt32(input[i][5]) - 48);
                    int b = hh + mm;
                    if (input[i][7] == 'p')
                    {
                        b = b + 720;
                    }
                    if (hh == 720 && mm > 0 && input[i][7] == 'a')
                    {
                        b = mm;
                    }
                    if (hh == 720 && mm > 0 && input[i][7] == 'p')
                    {
                        b = 720 + mm;
                    }
                    if (b == 720)
                    {
                        b = b * 2;
                    }
                    if (a == b)
                    {
                        if (k == 0)
                        {
                            k = a;
                            ten++;
                        }
                        else
                        {
                            if (b == k)
                            {
                                ten++;
                                if (ten == 10)
                                {
                                    count++;
                                    ten = 0;
                                }
                            }
                            else
                            {
                                k = 0;
                                ten = 0;
                            }
                        }
                    }
                    else
                    {
                        ten = 0;
                        if (a > b)
                        {
                            count++;
                        }
                    }
                    a = b;
                    Console.WriteLine(a);
                    Console.WriteLine(count);
                }
                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    sw.WriteLine(count);
                }
            }
            Console.ReadKey();
        }
    }
}
