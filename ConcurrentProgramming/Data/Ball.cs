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
            set
            {
                _coordinates.X = value;
                RaisePropertyChanged(nameof(X));
            }
        }

        public float Y
        {
            get => _coordinates.Y;
            set
            {
                _coordinates.Y = value;
                RaisePropertyChanged(nameof(Y));
            }
        }

        public double Radius
        {
            get => _radius;
        }
       


        public Vector2 Coordinates
        {
             
            get => _coordinates;
            // set => _coordinates = value;
            set
            {
                _coordinates = value;
                RaisePropertyChanged(nameof(X));
                RaisePropertyChanged(nameof(Y));
            }
        }

        public Vector2 Velocity
        {
            get => _velocity;
            set => _velocity = value;
        }

        public int Speed
        {
            get => _speed;
            set => _speed = value;
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
                _velocity.X *= -1;
            }
            

            if (Coordinates.Y < _radius  ||Coordinates.Y > DataApi.HEIGHT)
            {
                _velocity.Y *= -1;
            }
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