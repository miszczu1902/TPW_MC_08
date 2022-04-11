using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Logika
{
    internal class Kula
    {
        private double _radius = 2;
        private int _x = 0;
        private int _y = 0;

        public Kula()
        {
           
        }

        public Kula(int r)
        {
            _radius = r;
        }


        public Kula(int r, int x, int y)
        {
            _radius = r;
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
