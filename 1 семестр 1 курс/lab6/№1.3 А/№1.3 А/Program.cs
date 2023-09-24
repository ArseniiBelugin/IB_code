using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1._3_А
{
    class Program
    {
        static void Print_matrix (int n, int [,] matrix)
        {
            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        sw.Write($"{matrix[i, j]} ");
                    }
                    sw.WriteLine();
                }
            }
        }
        static void Input_matrix_console (ref int n, ref int[,] matrix)
        {
            Console.WriteLine("input n");
            n = int.Parse(Console.ReadLine());
            string [] line;
            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = Convert.ToInt32(line[j]);
                }
            }
        }
        static void Input_matrix_file(ref int n, ref int [,] matrix)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                n = int.Parse(sr.ReadLine());
                string[] line;
                for (int i = 0; i < n; i++)
                {
                    line = sr.ReadLine().Split();
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = Convert.ToInt32(line[j]);
                    }
                }
            }
        }
        static bool Character_matrix(int n, int [,] matrix)
        {
            int count_zero_in_zone = 0;
            int count_zero = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i >= j) && (i + j >= n - 1))
                    {
                        if (matrix[i, j] == 0)
                        {
                            count_zero_in_zone++;
                        }
                    }
                    else
                    {
                        if (matrix[i, j] == 0)
                        {
                            count_zero++;
                        }
                    }
                }
            }
            if (count_zero == count_zero_in_zone)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Change_matrix(ref int n, ref int[,] matrix)
        {
            int[] mins = new int[n];
            int min;
            for (int i = 0; i < n; i++)
            {
                min = matrix[i, 0];
                for (int j = 1; j < n; j++)
                {
                    if (matrix [i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
                mins[i] = min;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    matrix[i, j] = matrix[i, j] * mins[i];
                }
            }
        }
        static void Main(string[] args)
        {
            int menu_num = 0;
            bool init_check = false;
            int[,] matrix = new int[100, 100];
            int n = 0;
            while (menu_num != 6)
            {
                Console.WriteLine("1.ввод матрицы с клавиатуры\n2.ввод матрицы из файла\n3.вычисление характеристики\n4.преобразование матрицы\n5.печать матрицы\n6.выход.\n");
                menu_num = int.Parse(Console.ReadLine());
                switch (menu_num)
                {
                    case 1: 
                        Input_matrix_console(ref n, ref matrix);
                        init_check = true;
                        break;
                    case 2:
                        Input_matrix_file(ref n, ref matrix);
                        init_check = true;
                        break;
                    case 3:
                        if (init_check)
                        {
                            Console.WriteLine(Character_matrix(n, matrix));
                        }
                        else
                        {
                            Console.WriteLine("Input matrix, please");
                        }
                        break;
                    case 4:
                        Change_matrix(ref n, ref matrix);
                        break;
                    case 5:
                        if (init_check)
                        {
                            Print_matrix(n, matrix);
                        }
                        else
                        {
                            Console.WriteLine("Input matrix, please");
                        }
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Input error");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
/*
5 
1 9 9 9 9
0 0 0 0 7
8 14 100 74 12
4 5 0 7 8
9 9 9 9 9



*/