using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _4
{
    struct mes
    {
        public string text;
        public int num;
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            mes[] forum = new mes[1000];
            int count = 0;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                n = int.Parse(sr.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    int k = int.Parse(sr.ReadLine());
                    if (k == 0)
                    {
                        forum[i].text = sr.ReadLine();
                        forum[i].num = k;
                        sr.ReadLine();
                        count = count + 1;
                    }
                    else
                    {
                        forum[i].text = sr.ReadLine();
                        forum[i].num = k;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (forum[i].num != 0)
                {
                    if (forum[forum[i].num - 1].num != 0)
                    {
                        forum[i].num = forum[forum[i].num - 1].num;
                    }
                }
            }
            int[] array = new int[count + 1];
            for (int i = 0; i < n; i++)
            {
                if (forum[i].num != 0)
                {
                    if (forum[i].num - 1 <= count)
                    {
                        array[forum[i].num - 1]++;
                    }
                }
            }
            int max = 0;
            int numb = 1;
            for (int i = 0; i <= count; i++)
            {
                if (array[i] >= max)
                {
                    max = array[i];
                    numb = i;
                }
            }
            Console.WriteLine(forum[numb].text);
            Console.ReadKey();
        }
    }
}