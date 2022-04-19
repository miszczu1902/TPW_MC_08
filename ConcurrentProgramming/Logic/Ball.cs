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
        private double _radius = 25;
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
            
            if(Velocity==Vector2.Zero){
               System.Random random = new System.Random();
           Velocity = new Vector2((float) random.NextDouble(), (float) random.NextDouble());
            }
           // Console.WriteLine(Velocity);
            //Console.WriteLine(currentTime);
            
            Coordinates += Velocity * currentTime;
            //Console.WriteLine(Coordinates.X);
            //Console.WriteLine("a");
            
            //Console.WriteLine(Coordinates.Y);
            if (Coordinates.X < _radius || Coordinates.X > Board.WIDTH - _radius) Velocity *= -Vector2.UnitX;
             if (Coordinates.Y < _radius || Coordinates.Y > Board.HEIGHT - _radius) Velocity *= -Vector2.UnitY; 
            
        }
    }
}