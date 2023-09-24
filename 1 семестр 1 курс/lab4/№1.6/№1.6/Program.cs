/*
lab4 #1.6
определите длину самой длинной замкнутой цепочки в строках, содержащих менее 30
букв R, а также общее количество замкнутых цепочек во всех таких строках.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._6
{
    class Program
    {
        static Boolean Check_R (string s)
        {
            int r_count = 0;
            for (int l = 0; l < s.Length; l++)
            {
                if (s[l] == 'R')
                {
                    r_count++;
                };
            };
            if (r_count >= 30)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input;
            int str = 0;
            int max = 0;
            for (int i = 1; i <= n; i++)
            {
                input = Console.ReadLine();
                if (Check_R(input))
                {
                    for (int j = 0; j < input.Length - 1; j++)
                    {
                        char first = input[j];
                        int count = 1, last = j;
                        for (int k = j + 1; k < input.Length; k++)
                        {
                            if (input[k] == first)
                            {
                                last = k;
                                break;
                            };
                            count++;
                        };
                        if (last != j && input[last] == first)
                        {
                            str++;
                            if (count > max)
                            {
                                max = count;
                            };
                        };
                    };
                };
            };
            Console.WriteLine(str);
            Console.WriteLine(max);
            Console.ReadKey();
        }
    }
}
/*
3
PRIVET
INFORMATIKA
AWERTYUIOPAZXCA
4
10

3
VOVA
ZAEALE
QRAEQT
4
4

4
RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRAOOOOOOOOOOOOOOOOOA
APR
SPS
TMO
1
2


1
RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRAOOOOOOOOOOOOOOOOOA
0
0
*/