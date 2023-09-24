/*
lab 4 #2.1
Belugin Arseniy IB11 BO
Шифр Гая Юлия Цезаря. Циклический сдвиг алфавита влево на 3 позиции.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] input = new string[n];
            for (int i = 0; i < n; i++)
            {
                input[i] = Console.ReadLine();
            };
            string[] output = new string[n];
            //зашифровка
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    char c = input [i][j];
                    if ((int)c >= 1040 && (int)c <= 1068 || (int)c >= 1072 && (int)c <= 1100)
                    {
                        c++;
                        c++;
                        c++;
                    }
                    else
                    {
                        if ((int)c == 1069)
                        {
                            c = 'А';
                        }
                        if ((int)c == 1070)
                        {
                            c = 'Б';
                        }
                        if ((int)c == 1071)
                        {
                            c = 'В';
                        }
                        if ((int)c == 1101)
                        {
                            c = 'а';
                        }
                        if ((int)c == 1102)
                        {
                            c = 'б';
                        }
                        if ((int)c == 1103)
                        {
                            c = 'в';
                        }
                    }
                   
                    output[i] = output[i] + $"{c}";
                }
            }
            Console.WriteLine("\n\n\n");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(output[i]);
            }
            //расшифровка
            string[] input2 = output;
            string[] output2 = new string[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < input2[i].Length; j++)
                {
                    char c = input2[i][j];
                    if ((int)c >= 1043 && (int)c <= 1068 || (int)c >= 1075 && (int)c <= 1103)
                    {
                        c--;
                        c--;
                        c--;
                    }
                    else
                    {
                        if ((int)c == 1040)
                        {
                            c = 'Э';
                        }
                        if ((int)c == 1041)
                        {
                            c = 'Ю';
                        }
                        if ((int)c == 1042)
                        {
                            c = 'Я';
                        }
                        if ((int)c == 1072)
                        {
                            c = 'э';
                        }
                        if ((int)c == 1073)
                        {
                            c = 'ю';
                        }
                        if ((int)c == 1074)
                        {
                            c = 'я';
                        }
                    }
                    output2[i] = output2[i] + $"{c}";
                }
            }
            Console.WriteLine("\n\n\n");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(output2[i]);
            }
            Console.ReadKey();
        }
    }
}
/*
24
Я помню чудное мгновенье:
Передо мной явилась ты,
Как мимолётное виденье,
Как гений чистой красоты.
В томленьях грусти безнадежной,
В тревогах шумной суеты,
Звучал мне долго голос нежный,
И снились милые черты.
Шли годы. Бурь порыв мятежный
Рассеял прежние мечты,
И я забыл твой голос нежный,
Твои небесные черты.
В глуши, во мраке заточенья
Тянулись тихо дни мои
Без божества, без вдохновенья,
Без слёз, без жизни, без любви.
Душе настало пробужденье:
И вот опять явилась ты,
Как мимолётное виденье,
Как гений чистой красоты.
И сердце бьётся в упоенье,
И для него воскресли вновь
И божество, и вдохновенье,
И жизнь, и слёзы, и любовь.

2
АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ
абвгдеёжзийклмнопрстуфхцчшщъыьэюя
*/