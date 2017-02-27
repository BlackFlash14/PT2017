using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace LAB5
{
    [Serializable]
    public class Complex
    {
        public int a;
        public int b;
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
            //создаем объект для класса Complex
            Complex s = new Complex(6, 6);
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, где будем создавать или открывать файл, в которой будем проводить сериализацию 
            using (FileStream fs = new FileStream("complex.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, s);
            }

            using (FileStream fs = new FileStream("complex.txt", FileMode.OpenOrCreate))
            {
                Complex newComplex = (Complex)formatter.Deserialize(fs);//проводим десериализацию в complex.txt
                Console.WriteLine("{0} + {1}i", newComplex.a, newComplex.b);
            }

            Console.ReadLine();
        }
    }
}
