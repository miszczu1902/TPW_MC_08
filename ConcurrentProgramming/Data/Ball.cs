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
        private int _speed = 5000;
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
        
        public float VelocityX
        {
            get => _velocity.X;
            set => _velocity.X = value;
        }
        
        public float VelocityY
        {
            get => _velocity.Y;
            set => _velocity.Y = value;
        }

        public int Speed
        {
            get => _speed;
            set => _speed = value;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // public override bool Equals(object obj)
        // {
        //     Ball ball = (Ball) obj;
        //     return _coordinates == ball.Coordinates;
        // }
    }
}