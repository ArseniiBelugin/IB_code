using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task
{
    class Program
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                int k = int.Parse(Console.ReadLine());
                int answer = 0;
                string[] input = Console.ReadLine().Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                for (int el = k - 1; el > 0; el--)
                {
                    if (int.Parse(input[el]) < int.Parse(input[el - 1]))
                    {
                        answer += int.Parse(input[el - 1]) - int.Parse(input[el]);
                    }
                }

                Console.WriteLine(answer);
            }
            Console.ReadKey();
        }
    }
}
