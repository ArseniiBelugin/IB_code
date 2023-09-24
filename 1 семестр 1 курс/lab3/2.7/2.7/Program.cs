/*
 * lab 3 #2.7
 * Belugin Arseniy
 * удалить из массива серию к
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7
{
    class Program
    {
        static int[] ReadArray()
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("input array");
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }
            return a;
        }
        static int ArraySer(ref int num, ref int dlina, int k, int [] a)
        {
            int count = 1;
            for (int i = 1; i < a.Length; i++)
            {
                if (k == count)
                {
                    dlina++;
                    if (num == -1)
                    {
                        num = i - 1;
                    }
                }
                if (a[i - 1] != a[i])
                {
                    count++;
                }
            }
            return count;
        }
        static int [] Del (int num, int dlina, int [] a)
        {
            for (int j = 0; j < dlina; j++)
            {
                for (int i = num; i < a.Length - 1; i++)
                {
                    a[i] = a[i + 1];
                }
            }
            Array.Resize(ref a, a.Length - dlina);
            return a;
        }
        static void Print(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"{a[i]} ");
            }
        }
        static void Main(string[] args)
        {
            Console.Write("K = ");
            int k = int.Parse(Console.ReadLine());
            int[] array = ReadArray();
            int dlina = 0, num = -1;
            int kolvo = ArraySer(ref num, ref dlina, k, array);
            if (kolvo >= k)
            {
                array = Del(num, dlina, array);
            }
            Print(array);
            Console.ReadKey();
        }
    }
}
/*
1
5
1
2
2
2
2
 * 2 2 2 2
 * 
2
6
1
1
2
2
3
3
 * 1 1 3 3
 * 
3
5
1
1
1
2
2
 * 1 1 1 2 2
 */
