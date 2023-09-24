using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22._02._2022
{
    class Program
    {
        static int [,] dp = new int [100, 2];
        static int maxlen (string s, int left, int len)
        {
            if (dp[left, len] == -1)
            {
                if (len <= 1)
                {
                    dp[left, len] = len;
                }
                else
                {
                    if(s[left] == s[left + len - 1])
                    {
                        dp[left, len] = 2 + maxlen(s, left + 1, len - 2);
                    }
                    else
                    {
                        dp[left, len] = Math.Max(maxlen(s, left + 1, len - 1), maxlen(s, left, len - 1));
                    }
                }
            }
            return dp[left, len];
        }
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            dp = new int[word.Length, word.Length + 1];
            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j <= word.Length; j++)
                {
                    dp[i, j] = -1;
                }
            }
            Console.WriteLine(maxlen(word, 0, word.Length));
            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j <= word.Length; j++)
                {
                    Console.Write($"{dp[i, j], 4} ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
