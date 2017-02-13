using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Student //создание класса Student
    {
        //переменные с модификатором доступа public, то есть доступны в любом месте кода.
        public string name;
        public string lastname;
        public double gpa;
        public Student() //конструктор класса Student
        {
            name = "Yernur";
            lastname = "Alpyssov";
            gpa = 4.0;
        }
        public Student(string name, string lastname, double gpa)
        {
            this.name = name;
            this.lastname = lastname;
            this.gpa = gpa;
        }
        public override string ToString() //переписываем конструкторы в строку
        {
            return name + " " + lastname + " " + gpa;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
         //создаем объект класса Student
            Student student1 = new Student();
            student1.name = Console.ReadLine();
            student1.lastname = Console.ReadLine();
            student1.gpa = double.Parse(Console.ReadLine());
            Console.WriteLine(student1.ToString());
            Console.ReadKey();
        }
    }
}
