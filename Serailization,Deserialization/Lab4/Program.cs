using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LAB4
{
    [Serializable]
    public class Complex
    {
        int a;
        int b;
        public Complex()
        {
            this.a = 6;
            this.b = 6;
        }
        public Complex(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex res = new Complex(0, 0);
            res.a = c1.a + c2.a;
            res.b = c1.b + c2.b;

            return res;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //создаем объект для сериализации
            XmlSerializer xml = new XmlSerializer();
            Complex s = new Complex(6, 6);// создаем объект класса комплекс
            FileStream fs = new FileStream("complexxml.txt", FileMode.OpenOrCreate);// создаем поток для открытия или создания файла

            xml.Serialize(fs, s);
            fs.Close();

            Complex s1 = new Complex();//создаем пустой объект класса комплекс
            FileStream fs = new FileStream("complexxml.txt", FileMode.Open, FileAccess.Read);//открываем поток для чтения            

            s1 = (Complex)xml.Deserialize(fs1);//переписываем данные в виде комплекса
            fs.Close();
        }
    }
}