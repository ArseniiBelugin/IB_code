/*lab 3 #1.7
 * Belugin Arseniy IB-11
 * Kolichestvo seriy
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
            int[] array = Input();
            Console.WriteLine("Vvedite # serii");
            Console.WriteLine();
            Console.WriteLine ($"Massiv \n {Del(array)}");
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
        static int Count(int [] array)
        {
            int k = 1;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] != array[i])
                {
                    k = k + 1;
                };
            };
            return k;
        }
        static int[] Del (int [] array)
        {
            
            if ()
        }
    }
}
/*
 * 5
 * 1
 * 1
 * 1
 * 1
 * 1
 * k = 1
 * 
 * 
 * 4
 * 1
 * 2
 * 3
 * 4
 * k = 4
 * 
 * 
 * 5
 * 1
 * 2
 * 2
 * 3
 * 3
 * k = 3
 * 
 * 
 * 1
 * 1
 * k = 1
 */
