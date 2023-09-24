/*lab 1.22
Belugin Arseniy IB 11 BO
если массив не отсортирован по неубыванию или невозрастанию, то удалить каждый 4 элемент
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._22
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
        static bool ArrayCheck(int[] a)
        {
            bool down = true,
                up = true;
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i - 1] >= a[i] && up)
                {
                    up = false;
                }
                if (a[i - 1] <= a[i] && down)
                {
                    down = false;
                }
            }
            return (up || down);
        }
        static int [] Del(int [] a)
        {
            int k = 1;
            while (3 * k < a.Length)
            {
                for (int i = 3 * k; i < a.Length - 1; i++)
                {
                    a[i] = a[i + 1];
                };
                Array.Resize(ref a , a.Length - 1);
                k++;
            }
            return a;
        }
        static void PrintArray(int [] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"{a[i]} ");
            }
        }
        static void Main(string[] args)
        {
            int[] array = ReadArray();
            if (ArrayCheck(array))
            {
                array = Del(array);
            }
            PrintArray(array);
            Console.ReadKey();
        }
    }
}
/*
5
1
2
1
2
1

 * 1 2 1 2 1


10
1
2
3
4
5
6
7
8
9
10
 
1 2 3 5 6 7 9 10
  
10
10
9
8
7
6
5
4
3
2
1
 * 
 * 
 * 10 9 8 6 5 4 2 1
 
4
1
2
3
4
 
 *  1 2 3
 *  
 *  
3
1
2
3
 *  
 *  1 2 3
 */
