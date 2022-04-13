using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Logic
{
    public class Ball
    {
        private double _radius = 2;
        private int _x = 0;
        private int _y = 0;

        public Ball()
        {
        }

        public Ball(int r)
        {
            _radius = r;
        }


        public Ball(int r, int x, int y)
        {
            _radius = r;
            _x = x;
            _y = y;
        }

        public Ball(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public double Radius
        {
            get => _radius;
            set => _radius = value;
        }

        public int X
        {
            get => _x;
            set => _x = value;
        }

        public int Y
        {
            get => _y;
            set => _y = value;
        }
    }
}