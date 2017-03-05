using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeII
{
    class Program
    {
        //используем системный класс для получения непрерывного движения
        public static Thread toMove = new Thread(new ThreadStart(Motion)); 
        public static Thread pressedKeys = new Thread(new ThreadStart(Doing));
       
        static void Main(string[] args)
        {
            Console.CursorVisible = false; //обозначаем курсор невидимым
            Game game = new SnakeII.Game();
            Program.pressedKeys.Start();//начинаем игру по нажатию клавиш
        }



        public static void Doing()
        {
            Game.food.Generate();
            Game.wall.Generate();
            Game.worm.Generate();
            toMove.Start();
            Game.food.Draw();
            Game.wall.Draw();
            Game.worm.Draw();
            while (Game.inGame)
            {
                Game.wall.Draw();
                Game.food.Draw();
                Game.worm.Draw();
                ConsoleKeyInfo button = Console.ReadKey(true);
                //задаем условия, при которых позиция "змейки" будет меняться
                switch (button.Key)
                {
                    case ConsoleKey.UpArrow:
                        Game.worm.changeDirection(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        Game.worm.changeDirection(0, 1);
                        break;
                    case ConsoleKey.RightArrow:
                        Game.worm.changeDirection(1, 0);
                        break;
                    case ConsoleKey.LeftArrow:
                        Game.worm.changeDirection(-1, 0);
                        break;
                    case ConsoleKey.S:
                        Game.SaveGame();
                        break;
                    case ConsoleKey.L:
                        Game.LoadGame();                                                      
                        break;
                }
                Console.Clear();
            }
        }

        public static void Motion()
        {
            while (Game.inGame)
            {
                Thread.Sleep(Game.SPEED);
                Game.worm.Clear();

                for (int i = Game.worm.points.Count - 1; i > 0; --i)
                {
                    Game.worm.points[i].x = Game.worm.points[i - 1].x;
                    Game.worm.points[i].y = Game.worm.points[i - 1].y;
                }

                if (Game.worm.points[0].x + Game.worm.dx < 0)
                    Game.worm.points[0].x = 20;
                else
                    if (Game.worm.points[0].x + Game.worm.dx > Game.WIDTH)
                        Game.worm.points[0].x = 0;
                    else
                    Game.worm.points[0].x = Game.worm.points[0].x + Game.worm.dx;

                if (Game.worm.points[0].y + Game.worm.dy < 0) 
                    Game.worm.points[0].y = 20;
                else
                    if (Game.worm.points[0].y + Game.worm.dy > Game.HEIGTH)
                         Game.worm.points[0].y = 0;
                    else
                    Game.worm.points[0].y = Game.worm.points[0].y + Game.worm.dy;

                Game.worm.Draw();
                Game.worm.game.CanEat();
                if (Game.worm.Collision())
                    Game.inGame = false;            
                }
        }

    }
}
