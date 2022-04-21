using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Logic
{
    public class Ball : INotifyPropertyChanged
    {
        private double _radius = 25;
        private int _speed = 5000;
        private Vector2 _coordinates;
        private Vector2 _velocity;

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

        public Vector2 Velocity { get; set; }

        public void UpdatePostion()
        {
            Coordinates += new Vector2(Velocity.X * _speed, Velocity.Y * _speed);
            if (Coordinates.X < _radius || Coordinates.X > Board.WIDTH)
            {
                Velocity *= -Vector2.UnitX;
            }

            if (Coordinates.Y < _radius || Coordinates.Y > Board.HEIGHT)
            {
                Velocity *= -Vector2.UnitY;
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