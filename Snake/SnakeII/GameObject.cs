using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace SnakeII
{
    [Serializable]
    public abstract class GameObject : IDrawable //Создаем абстрактный класс, наслдеующийся от класса IDrawable
    {
        public char sign;
        public List<Point> points = new List<Point>(); //создаем массив точек
        public void Draw()
        {
            for (int i = 0; i < points.Count; ++i)
            {
                Console.SetCursorPosition(points[i].x, points[i].y);//хадаем местоположение курсора
                if (this.GetType() == typeof(Worm) && i == 0)
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(sign);
            }
            Console.ForegroundColor = ConsoleColor.White;

        }

        public void Clear()
        {
            for (int i = 0; i < points.Count; ++i)
            {
                Console.SetCursorPosition(points[i].x, points[i].y);
                Console.Write(' ');
            }
        }
        public void Save()
        {
            string name = GetType().Name;
            XmlSerializer xs = new XmlSerializer(this.GetType());
            using (FileStream fs = new FileStream(string.Format("{0}.xml", name), FileMode.Create, FileAccess.Write))
            {
                xs.Serialize(fs, this);
            }
        }

        public object Load()
        {
            string name = GetType().Name;
            XmlSerializer xs = new XmlSerializer(GetType());
            object res;
            using (FileStream fs = new FileStream(string.Format("{0}.xml", name), FileMode.Open, FileAccess.Read))
            {
                res = xs.Deserialize(fs);
            }
            return res;
        }

    }
}
   

