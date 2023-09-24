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
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    int n = int.Parse(sr.ReadLine());
                    Queue<string> queue = new Queue<string>();
                    string[] input;
                    for (int i = 0; i < n; i++)
                    {
                        input = sr.ReadLine().Split();
                        if (input[0] == "+")
                        {
                            queue.Enqueue(input[1]);
                        }
                        if (input[0] == "*")
                        {
                            string [] arr = queue.ToArray();
                            int temp = (queue.Count + queue.Count % 2) / 2;
                            queue.Clear();
                            for (int j = 0; j < temp; j++)
                            {
                                queue.Enqueue(arr[j]);
                            }
                            queue.Enqueue(input[1]);
                            for (int j = temp;j < arr.Length; j++)
                            {
                                queue.Enqueue(arr[j]);
                            }
                        }
                        if (input[0] == "-")
                        {
                            sw.WriteLine(queue.Dequeue());
                        }
                    }
                }
            }
        }
    }
}
