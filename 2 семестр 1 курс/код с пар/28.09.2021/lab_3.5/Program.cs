﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool x, y, z;
            int i, j, k;
            Console.WriteLine("x       y       z       A");
            for (i = 0; i <= 1; i++)
            {
                for (j = 0; j <= 1; j++)
                {
                    for (k = 0; k <= 1; k++)
                    {
                        if (i == 0)
                        {
                            x = false;
                        }
                        else
                        {
                            x = true;
                        };
                        if (j == 0)
                        {
                            y = false;
                        }
                        else
                        {
                            y = true;
                        };
                        if (k == 0)
                        {
                            z = false;
                        }
                        else
                        {
                            z = true;
                        };
                        bool a = (XOR(x, y) || !x || (!x && z));
                        Console.WriteLine($"{x}   {y}   {z}   {a}");
                    };
                };
            };
            Console.WriteLine("\n\n x       y       z       B");
            for (i = 0; i <= 1; i++)
            {
                for (j = 0; j <= 1; j++)
                {
                    for (k = 0; k <= 1; k++)
                    {
                        if (i == 0)
                        {
                            x = false;
                        }
                        else
                        {
                            x = true;
                        };
                        if (j == 0)
                        {
                            y = false;
                        }
                        else
                        {
                            y = true;
                        };
                        if (k == 0)
                        {
                            z = false;
                        }
                        else
                        {
                            z = true;
                        };
                        bool b = (pir (x, !y) || (x || pir(!z, z)));
                        Console.WriteLine($"{x}   {y}   {z}   {b}");
                    }; 
                };
            };
            Console.ReadKey();
        }
        static bool XOR(bool a, bool b)
        {
            bool c = !a && b || a && !b;
            return c;
        }
        static bool pir(bool a, bool b)
        {
            bool c = !(a || b);
            return c;
        }
    }
}