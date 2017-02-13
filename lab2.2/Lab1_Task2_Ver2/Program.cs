using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Task2
{

    class Program // класс program
    {
        static void Main(string[] args)
        {
            // задаем переменные отвечающие за минимальные и максимальные величины
            int min = int.MaxValue;
            int max = int.MinValue;
            FileStream input = new FileStream("C:\\input.txt", FileMode.Open); // указываем путь к файлу с числами И открываем его
            StreamReader read = new StreamReader(input);// читаем файл
            {
                string[] a = read.ReadLine().Split();    // задаем массив чисел и читаем его
                for (int i = 0; i < a.Length; i++) // пробегаемся по массиву строк
                {
                    string text = a[i];
                    int k = int.Parse(text); 
                    min = Math.Min(min, k);
                    max = Math.Max(max, k);
                }
            }
            Console.WriteLine("Мaximum: {0}", max);
            Console.WriteLine("Minimum: {0}", min);
            Console.ReadKey();
        }
    }
}