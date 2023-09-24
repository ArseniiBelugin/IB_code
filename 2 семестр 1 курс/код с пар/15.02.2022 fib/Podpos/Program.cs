using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podpos
{
    class Program
    {
        public static int [] maxLengthSubseq (int [] value)
        {
            int[] length = new int[value.Length];
            length[0] = 1;
            for (int i = 1; i < value.Length; i++)
            {
                length[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (value [j] < value[i])
                    {
                        length[i] = Math.Max(length[i], length[j] + 1);
                    }
                }
            }
            return length;
        }
        public static int [] maxseq(int [] value, int [] length)
        {
            int indmax = 0;
            for (int i = 1; i < length.Length; i++)
            {
                if (length[i] > length[indmax])
                {
                    indmax = i;
                }
            }
            int len = length[indmax];
            int[] subseq = new int[len];

            subseq[len - 1] = value[indmax];
            for (int j = len - 1; j > 0; j--)
            {
                int i = indmax - 1;
                for (; i >= 0; i--)
                {
                    if (value [i] < value [indmax] && length [i] == j)
                    {
                        break;
                    }
                }
                subseq[j - 1] = value[i];
                indmax = i;
            }
            return subseq;
        }
        static void Main(string[] args)
        {
            string [] lines = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] seq = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                seq[i] = int.Parse(lines[i]);
            }
            int[] lengthSub = maxLengthSubseq(seq);
            foreach (int item in lengthSub)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            int[] subseq = maxseq(seq, lengthSub);
            foreach (int item in subseq)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
