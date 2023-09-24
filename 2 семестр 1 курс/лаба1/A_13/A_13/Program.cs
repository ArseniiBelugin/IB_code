/*
Саша устал играть со своими палочками и нашел более интересное занятие. Он написал на доске
все числа от 1 до N в одну строчку (так он получил очень большое число) и теперь хочет стереть
ровно M цифр таким образом, чтобы оставшееся написанное число было как можно меньше.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_13
{
    class Program
    {
        static string chisla = "";
        static void MakeString (int n)
        {
            for (int i = 1; i <= n; i++)
            {
                chisla = chisla + Convert.ToString(i);
            }
        }
        static void Del(int m)
        {
            int k = 0;
            while (m != 0)
            {
                if (Convert.ToInt32(chisla [k]) > Convert.ToInt32(chisla [k + 1]))
                {
                    chisla = chisla.Remove(k, 1);
                    if (k != 0)
                    {
                        k = k - 1;
                    }
                    m = m - 1;
                }
                else
                {
                    k++;
                }
            }
        }
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            MakeString(n);
            Del(m);
            for (int i = 0; i < chisla.Length; i++)
            {
                Console.Write(chisla[i]);
            }
            Console.ReadKey();
        }
    }
}
