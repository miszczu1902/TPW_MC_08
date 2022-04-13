using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class Generator
    {
        private Random generator = new Random();
        private int _x;
        private int _y;

        public Generator() {}

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

        public void GenerateXY()
        {
            this.X = generator.Next(1, 101);
            this.Y = generator.Next(1, 101);
        }

        public Ball GenerateBall()
        {
            GenerateXY();
            return new Ball(X, Y);
        }
    }
}
