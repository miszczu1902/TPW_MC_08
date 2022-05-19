using System;
using System.Collections;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using Data;

namespace Logic
{
    public class Ball : INotifyPropertyChanged
    {
        private double _radius = 25;
        private int _speed = 10000;
        public float _mass;
        private Vector2 _coordinates;
        private Vector2 _velocity;
        private Random random = new Random();

        public float Mass
        {
            get => _mass;
            set => _mass = value;
        }

        public Ball()
        {
            _mass = random.Next(500,2000);
        }

        public float X
        {
            get => _coordinates.X;
        }

        public float Y
        {
            get => _coordinates.Y;
        }

        public double Radius
        {
            get => _radius;
        }
       


        public Vector2 Coordinates
        {
             
            get => _coordinates;
            set => _coordinates = value;
        }

        public Vector2 Velocity
        {
            get => _velocity;
            set => _velocity = value;
        }

        public void UpdatePostion()
        {
            // Coordinates += new Vector2(Velocity.X * _speed, Velocity.Y * _speed);
            //
            // if (Coordinates.X +_radius < margin )
            // {
            //     // Velocity *= -Vector2.UnitX;
            //     _velocity.X *= -1;
            // }
            // if (Coordinates.X +_radius < margin )
            // {
            //     // Velocity *= -Vector2.UnitX;
            //     // _velocity.X*=-1;
            // }
            //
            // // if (Coordinates.Y < _radius || Coordinates.Y > DataApi.HEIGHT)
            // // {
            // //     // Velocity *= -Vector2.UnitY;
            // //     Velocity *= -Vector2.UnitY;
            // // }

            
            Coordinates += new Vector2(Velocity.X * _mass, Velocity.Y * _mass);
            if (Coordinates.X < _radius || Coordinates.X > DataApi.WIDTH)
            {
                // Velocity *= -Vector2.UnitX;
                // _velocity.Y *= -1;
                _velocity.X *= -1;
            }
            

            if (Coordinates.Y < _radius  ||Coordinates.Y > DataApi.HEIGHT)
            {
                // Velocity *= -Vector2.UnitY;
                // _velocity.X *= -1;
                _velocity.Y *= -1;
            }
            RaisePropertyChanged(nameof(X));
            RaisePropertyChanged(nameof(Y));
        }
        public void BallHit(IList ballList)
        {
            UpdatePostion();
            Coordinates += new Vector2(Velocity.X * _speed, Velocity.Y * _speed);

            
            foreach (Ball ball in ballList)
            {
                if (Vector2.Distance(ball.Coordinates, this.Coordinates)<=_radius &&Vector2.Distance(ball.Coordinates, this.Coordinates)
                    - Vector2.Distance(ball.Coordinates + ball.Velocity, this.Coordinates + this.Velocity) > 0)
               {
                   
                    // this.Velocity = (this.Velocity *  (this.Mass - ball.Mass) + 2 * ball.Mass * ball.Velocity) / (this.Mass + ball.Mass);
                    // ball.Velocity = (ball.Velocity *  (ball.Mass - this.Mass) + 2 * this.Mass * this.Velocity) / (this.Mass + ball.Mass);
                    // Vector2 newVelocity2 = (this.Velocity *  (this.Mass - ball.Mass) + 2 * ball.Mass * ball.Velocity) / (this.Mass + ball.Mass);
                    // Vector2 newVelocity1= (ball.Velocity *  (ball.Mass - this.Mass) + 2 * this.Mass * this.Velocity) / (this.Mass + ball.Mass);                   
                    Vector2 newVelocity2 = (this.Velocity *  (this.Mass - ball.Mass) + 2 * ball.Mass * ball.Velocity) / (this.Mass + ball.Mass);
                    Vector2 newVelocity1= (ball.Velocity *  (ball.Mass - this.Mass) + 2 * this.Mass * this.Velocity) / (this.Mass + ball.Mass);
                    ball.Velocity = newVelocity1;
                    this.Velocity = newVelocity2;
                }
            }

            // if (Coordinates.Y < _radius || Coordinates.Y > DataApi.HEIGHT)
            // {
            //     Velocity *= -Vector2.UnitY;
            // }

            RaisePropertyChanged(nameof(X));
            RaisePropertyChanged(nameof(Y));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}