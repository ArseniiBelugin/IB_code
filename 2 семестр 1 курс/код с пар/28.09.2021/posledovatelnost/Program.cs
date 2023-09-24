using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posledovatelnost
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int dir = 3;
            if (a > b)
            {
                dir = 2;
            }
            else
            {
                if (a < b)
                {
                    dir = 1;
                };
            };
            do
            {
                a = b;
                b = int.Parse(Console.ReadLine());
                if (b != 0)
                {
                    if (a > b && dir != 2)
                    {
                        dir = 3;
                    }
                    else
                    {
                        if (a < b && dir != 1)
                        {
                            dir = 3;
                        };
                    };
                };
            } while (b != 0);
            switch (dir)
            {
                case 1:
                    {
                        Console.WriteLine("Возрастающая");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Убывающая");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Произвольная");
                        break;
                    }

            };
            Console.ReadKey();
        }
    }
}
