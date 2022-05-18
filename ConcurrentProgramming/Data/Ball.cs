using System;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using Data;

namespace Logic
{
    public class Ball : INotifyPropertyChanged
    {
        private int margin = 25;
        private double _radius = 25;
        private int _speed = 5000;
        public double _mass;
        private Vector2 _coordinates;
        private Vector2 _velocity;
        private Random random = new Random();

        public double Mass
        {
            get => _mass;
            set => _mass = random.Next(10,20);
        }

        public Ball()
        {
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

            
            Coordinates += new Vector2(Velocity.X * _speed, Velocity.Y * _speed);
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
        public void BallHit ()
        {
            Coordinates += new Vector2(Velocity.X * _speed, Velocity.Y * _speed);
            if (Coordinates.Y +_radius< _radius)
            {
                Velocity *= -Vector2.UnitX;
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