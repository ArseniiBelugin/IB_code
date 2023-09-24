using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2
{
    struct item
    {
        public double cost;
        public double weigth;
    }

    class Program
    {
        static void Main(string[] args)
        {
            double total = 0;
            int n;
            double w;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string[] input = sr.ReadLine().Split();
                n = int.Parse(input[0]);
                w = int.Parse(input[1]);
                item[] array = new item[n];
                for (int i = 0; i < n; i++)
                {
                    input = sr.ReadLine().Split();
                    array[i].cost = int.Parse(input[0]);
                    array[i].weigth = int.Parse(input[1]);
                }
                item temp;
                if (n > 1)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n - 1; j++)
                        {
                            if (Math.Round(array[j].cost / array[j].weigth, 12) <= Math.Round(array[j + 1].cost / array[j + 1].weigth, 12))
                            {
                                temp = array[j];
                                array[j] = array[j + 1];
                                array[j + 1] = temp;
                            }
                        }
                    }
                }
                int k = 0;
                while (w > 0)
                {
                    if (n - 1 != k)
                    {
                        if (array[k].weigth <= w)
                        {
                            w = w - Math.Truncate(array[k].weigth);
                            total = total + array[k].cost;
                        }
                        else
                        {
                            total = total + array[k].cost / array[k].weigth * w;
                            w = 0;
                        }
                    }
                    else
                    {
                        if (w >= array[k].weigth)
                        {
                            total = total + array[k].cost;
                            w = 0;
                        }
                        else
                        {
                            total = total + array[k].cost / array[k].weigth * w;
                            w = 0;
                        }
                    }
                    k++;
                }
            }
            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                sw.WriteLine($"{total:F3}");
            }
        }
    }
}
