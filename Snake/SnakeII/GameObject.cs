using System;
using System.Collections.Generic;



namespace SnakeII
{
    public abstract class GameObject : IDrawable
    {
        public char sign;
        public List<Point> points = new List<Point>();

        public void Draw()
        {
            for (int i = 0; i < points.Count; ++i)
            {
                Console.SetCursorPosition(points[i].x, points[i].y);
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
    }
}
