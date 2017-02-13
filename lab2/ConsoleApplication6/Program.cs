using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Complex
    {
        int a;
        int b;
        public Complex(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public static Complex operator +(Complex a1, Complex b2)
        {
            Complex result = new Complex(0, 0);
            result.a = a1.a + b2.a;
            result.b = a1.b + b2.b;
            return result;
        }
        public override string ToString()
        {
            return string.Format("{0} + {1}i", a, b);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Complex a = new Complex(4, 1);
            Complex b = new Complex(3, 2);
            Complex c = a + b;
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("a + b = " + c);

            Console.ReadKey();
        }
    }

}
