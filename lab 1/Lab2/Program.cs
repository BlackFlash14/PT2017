using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Programm // создаем класс Programm
    {

        static bool Prime(string a) //в конструкторе Prime создаем переменную типа string
        {
            int b = int.Parse(a); // эту переменную конвертируем в тип int
            int cnt = 0;// создаем счетчик делителей
            for (int i = 1; i <= b; ++i)//проверям на делимость 
            {
                if (b % i == 0)
                {
                    cnt++;//считаем количество делителей
                }
            }
            if (cnt == 2) //если количество делителей равно 2, то число простое
                return true;
            return false;
        }
        static void Main(string[] args)// задаем массив строк в методе main
        {
            for (int i = 0; i < args.Length; ++i)// пробегаемся по массиву args
            {
                if (Prime(args[i]))
                {
                    Console.WriteLine(args[i]);
                }
            }
        }
    }
}
