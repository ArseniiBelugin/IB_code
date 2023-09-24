using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17._09._2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите числa");
            string Input = Console.ReadLine();
            string[] strings= Input.Split(new char[] {' ',';'}, StringSplitOptions.RemoveEmptyEntries);
            int n1 = int.Parse(strings[0]),
                n2 = int.Parse(strings[1]),
                n3 = int.Parse(strings[2]);
            int max = 0, min = 0;
            if ((n1 >= n2) && (n1 >= n3)) {
                max = n1;
            };
            if ((n2 >= n1) && (n2 >= n3))
            {
                max = n2;
            };
            if ((n3 >= n1) && (n3 >= n2))
            {
                max = n3;
            };
            if ((n1 <= n2) && (n1 <= n3))
            {
                min = n1;
            };
            if ((n2 <= n1) && (n2 <= n3))
            {
                min = n2;
            };
            if ((n3 <= n1) && (n3 <= n2))
            {
                min = n3;
            };
            n2 = n1 + n2 + n3 - max - min;
            n1 = max;
            n3 = min;
            Console.WriteLine($"{n1}, {n2}, {n3}");
            //number1 = int.Parse(Inputstring);
            //Console.WriteLine(number1.ToString()+" + "+number2.ToString()+ " = "+summa.ToString());
            //Console.WriteLine($"{number1} + {number2} = {summa}");
            //Console.WriteLine("{0} + {1} = {2}", number1, number2, summa);
            Console.ReadKey();

        }
    }
}
