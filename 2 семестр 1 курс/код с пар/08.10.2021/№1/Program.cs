using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        
        static void Main(string[] args)
        { 
            int[] array = Input();
            Console.WriteLine($"MaxItem = {MaxItem(array)}");
            Console.ReadKey();
        }
        static int MaxItem(int[] array)
        {
            int max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                };
            };
            return max;
        }
        static int[] Input()
        {
            int n = -1;
            while(n < 0)
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
        ///<summary>
        ///vvod chisel
        ///</summary>
        ///<returns>max</returns>
    }
}
/*
 * 3
 * 1
 * 2
 * 3
 * max = 3
 */
