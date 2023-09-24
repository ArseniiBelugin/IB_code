/*lab 3 #1.7
 * Belugin Arseniy IB-11
 * ydalenie serii k is massiva
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kol_vo_seriy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vvedite # serii");
            int k = int.Parse(Console.ReadLine());
            int[] array = Input();
            Console.WriteLine($"Massiv");
            Del(array, k);
            Console.ReadKey();
        }
        static int[] Input()
        {
            int n = -1;
            while (n < 0)
            {
                Console.WriteLine("input items count");
                n = int.Parse(Console.ReadLine());
            };
            Console.WriteLine("input items");
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            };
            return array;
        }
        static void Del(int[] array, int p)
        {
            int k = 1;
            int n_i = 0;
            int n = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] != array[i])
                {
                    k = k + 1;
                };
                if (k == p)
                {
                   n_i = i;
                   n++; 
                }
            };
            if (n_i != 0)
            {
                Array.Clear(array, n_i, n);
                int[] array_2 = array;
                for (int i = 0; i < array_2.Length;i++)
                {
                    Console.Write($"{array_2[i]} ");
                };
            }
            else
            {
                for (int i = 0; i < array.Length;i++)
                {
                    Console.Write($"{array[i]} ");
                };
            }
        }
    }
}

