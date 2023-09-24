using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _4
{
    class Program
    {
        public struct trio
        {
            public int x, y;
            public string ans;
            public trio(int X, int Y, string ANS)
            {
                x = X; y = Y; ans = ANS;
            }
        }

        static void Main(string[] args)
        {
            {
                Queue<trio> queue = new Queue<trio>();
                int x, y;
                string ans = "";
                string[] input = Console.ReadLine().Split();
                x = int.Parse(input[0]);
                y = int.Parse(input[1]);
                queue.Enqueue(new trio (x, y, ans));
                int iter = 0;
                while (iter <= 600000)
                {
                    iter++;
                    if (queue.Peek().x == queue.Peek().y)
                    {
                        Console.WriteLine(queue.Peek().ans);
                        break;
                    }
                    int x_first = queue.Peek().x, y_first = queue.Peek().y;
                    string ans_first = queue.Peek().ans;
                    int x_second = queue.Peek().x, y_second = queue.Peek().y;
                    string ans_second = queue.Peek().ans;
                    queue.Dequeue();
                    x_first = x_first + 1;
                    y_first = y_first * 2;
                    ans_first = string.Concat(ans_first, "1");
                    if (x_first == y_first)
                    {
                        Console.WriteLine(ans_first);
                        break;
                    }
                    queue.Enqueue(new trio(x_first, y_first, ans_first));
                    x_second = x_second * 2;
                    y_second = y_second + 1;
                    ans_second = string.Concat(ans_second, "2");
                    if (x_second == y_second)
                    {
                        Console.WriteLine(ans_second);
                        break;
                    }
                    queue.Enqueue(new trio(x_second, y_second, ans_second));
                }
                if (iter >= 600000)
                {
                    Console.WriteLine(0);
                }
                //Console.ReadKey();
            }
        }
    }
}
