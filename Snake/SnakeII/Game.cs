using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace SnakeII
{

    public class Game
    {
        public static int SPEED = 200;
        public static int HEIGTH = 30;
        public static int WIDTH = 50;
        public static int score = 0;

        public static Food food;
        public static Worm worm;
        public static Wall wall;

        public static bool inGame = true;// пока выолняется InGame, следующие переменные действительны
        public Game()
        {
            food = new Food();
            worm = new Worm();
            wall = new Wall();
            worm.game = this;
        }

       
        public void CanEat()
        {
            if (worm.points[0].Equals(food.points[0])) //указываем, что "еда" присоединяется к "змейке"
            {
                worm.points.Add(food.points[0]);
                score++;
                if (score == 3) {
                    score = 0;

                }
                food.points.Clear();
                food.Generate();
              
            }
        }
        public void Serialization()
        {
            Game g = new Game();
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("snake.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, g);
            }

            using (FileStream fs = new FileStream("snake.txt", FileMode.OpenOrCreate))
            {
                Game newGame = (Game)formatter.Deserialize(fs);

            }
        }
    }
}