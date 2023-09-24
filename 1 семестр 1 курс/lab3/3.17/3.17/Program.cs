/*
 * lab 3 #3.17
 * Belugin Arseniy
 * положительные числа в массив У, модули отрицательных чисел в Z
 * удалить простые числа палиндромы из каждого массива
 * найти как изменилось кол-во простых чисел после удаления 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3._17
{
    class Program
    {
        static bool isPrime (int a)
        {
            a = Math.Abs(a);
            if (a == 1)
            {
                return false;
            }
            for (int i = 2; i <= Math.Round(Math.Sqrt(a)); i++)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        static bool isPal (int a)
        {
            a = Math.Abs(a);
            int b = a;
            int pal = 0;
            if (a / 10 == 0)
            {
                return false;
            }
            while (b > 0)
            {
                pal = 10 * pal + b % 10;
                b = b / 10;
            }
            if (a == pal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static int [] makeZ(int [] x)
        {
            int k = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] < 0)
                {
                    k++;
                }
            }
            int[] z = new int[k];
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] < 0)
                {
                    z[z.Length - k] = -x[i];
                    k--;
                }
            }
            return z;
        }
        static int [] makeY(int [] x)
        {
            int k = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] > 0)
                {
                    k++;
                }
            }
            int[] y = new int[k];
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] > 0)
                {
                    y[y.Length - k] = x[i];
                    k--;
                }
            }
            return y;
        }
        static int [] Del(int [] a)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (isPrime(a[i]) && isPal(a[i]))
                {
                    count++;
                }
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (isPrime(a[i]) && isPal(a[i]))
                {
                    for (int j = i; j < a.Length - 1; j++)
                    {
                        a[i] = a[i + 1];
                    }
                }
            }
            Array.Resize(ref a, a.Length - count);
            return a;
        }
        static int CountPrime(int [] a)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (isPrime(a[i]))
                {
                    count++;
                }
            }
            return count;
        }
        static int [] ReadArray()
        {
            /*using (StreamReader file = new StreamReader("input.txt"))
            {
                int n = int.Parse(file.ReadLine());
                int[] a = new int[n];
                string[] input = file.ReadLine().Split();
                for (int i = 0; i < n; i++)
                {
                    a[i] = int.Parse(input[i]);
                }
                return a;
            }*/
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            string[] input = Console.ReadLine().Split();
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(input[i]);
            }
            return a;
        }
        static void Print(int [] x, int [] y, int [] z)
        {
            /*using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                sw.WriteLine($"Количество простых чисел в X = {CountPrime(x)}");
                sw.WriteLine($"Количество простых чисел в Y = {CountPrime(y)}");
                sw.WriteLine($"Количество простых чисел в Z = {CountPrime(z)}");
                x = Del(x);
                y = Del(y);
                z = Del(z);
                sw.WriteLine($"Количество простых чисел в X = {CountPrime(x)}");
                sw.WriteLine($"Количество простых чисел в Y = {CountPrime(y)}");
                sw.WriteLine($"Количество простых чисел в Z = {CountPrime(z)}");
            }*/
            Console.WriteLine($"Количество простых чисел в X = {CountPrime(x)}");
            Console.WriteLine($"Количество простых чисел в Y = {CountPrime(y)}");
            Console.WriteLine($"Количество простых чисел в Z = {CountPrime(z)}");
            Console.WriteLine($"Количество простых чисел в X = {CountPrime(Del(x))}");
            Console.WriteLine($"Количество простых чисел в Y = {CountPrime(Del(y))}");
            Console.WriteLine($"Количество простых чисел в Z = {CountPrime(Del(z))}");
        }
        static void Main(string[] args) {
            int [] arrayX = ReadArray();
            int[] arrayY = makeY(arrayX);
            int[] arrayZ = makeZ(arrayX);
            Print(arrayX, arrayY, arrayZ);
            Console.ReadKey();
        }
    }
}
