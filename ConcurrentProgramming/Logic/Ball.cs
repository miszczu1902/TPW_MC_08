using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Numerics;

namespace Logic
{
    public class Ball
    {
        private double _radius = 50;
        private int _x = 0;
        private int _y = 0;

        private Vector2 _velocity;
        // private long _gameTime = DateTime.Now.Millisecond;


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

        public Vector2 Coordinates { get; set; }

        public Vector2 Velocity
        {
            get ;
            set ;
        }

        public void UpdatePostion(long currentTime)
        {
            //Console.WriteLine(Velocity);
            //Console.WriteLine(currentTime);
            
            Coordinates += Velocity * currentTime;
            


            if (Coordinates.X < _radius || Coordinates.X > Board.WIDTH - _radius) Velocity *= -Vector2.UnitX;
            if (Coordinates.Y < _radius || Coordinates.Y > Board.HEIGHT - _radius) Velocity *= -Vector2.UnitY; 
            
        }
    }
}