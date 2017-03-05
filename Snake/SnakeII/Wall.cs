using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeII
{
    [Serializable]
    public class Wall: GameObject
    {
        public Wall()
        {
            this.sign = 'X';
        }
        public void Generate()
        {
            this.points.Add(new Point(5, 5));           
        }

        internal Wall Load1()
        {
            throw new NotImplementedException();
        }
    }
}
