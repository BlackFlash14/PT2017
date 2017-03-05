using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Xml.Serialization;

namespace SnakeII
{
    [Serializable]
    public class Game
    {
        public static int SPEED = 200;
        public static int HEIGTH = 30;
        public static int WIDTH = 50;
        public static int score = 0;
        public static int score1, totalScore;
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
        public void SaveGame()
        {
            wall.Save();
            worm.Save();
            food.Save();
        }

        public void LoadGame()
        {
            wall.Clear();
            worm.Clear();
            food.Clear();
            wall = wall.Load() as Wall;
            worm = worm.Load() as Worm;
            food = food.Load() as Food;
            Console.Clear();
            wall.Draw();
            worm.Draw();
            food.Draw();
        }

        public void CanEat()
        {
            if (worm.points[0].Equals(food.points[0])) //указываем, что "еда" присоединяется к "змейке"
            {
                worm.points.Add(food.points[0]);
                score++;
                if (score == 3)
                {
                    score = 0;

                }
                food.points.Clear();
                food.Generate();

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

        internal void Load1()
        {
            throw new NotImplementedException();
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
        /* public void Serialization()
         {
             Game g = new Game();
             BinaryFormatter formatter = new BinaryFormatter();
             FileStream fs = new FileStream("snake.txt", FileMode.OpenOrCreate);
             formatter.Serialize(fs, g);
             FileStream fs1 = new FileStream("snake.txt", FileMode.OpenOrCreate);
             Game newGame = (Game)formatter.Deserialize(fs1);

         }
        */
    }


}
