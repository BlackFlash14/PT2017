﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeII
{
    public class Worm:GameObject
    {
        public Game game;

        public int dx;
        public int dy;

        public Worm()
        {
            this.sign = 'o';
            this.dx = 0;
            this.dy = 0;
        }

        public void Generate()
        {
            this.points.Add(new Point(10,10));//задаем начальную позицию змейки
        }

        public void changeDirection(int v1, int v2)
        {
            dx = v1;
            dy = v2;
        }

        public bool Collision()
        {
            for (int i = 0; i < Game.wall.points.Count; i++)// при совпадении точек змейки и стенки возратить "столкновение"
                if (points[0].Equals(Game.wall.points[i]))
                    return true;
            return false;
        }
    }
}
