using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Logic
{
    public class Ball :INotifyPropertyChanged
    {
        private double _radius = 35;
        private int _x = 0;
        private int _y = 0;
        private Vector2 _coordinates;
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

        public float X
        {
            get => _coordinates.X;

        }

        public float Y
        {
            get => _coordinates.Y;
        }

        public Vector2 Coordinates
        {
            get => _coordinates;
            set => _coordinates = value;
        }

        public Vector2 Velocity { get; set; }

        public void UpdatePostion(long currentTime)
        {
            
            if (Velocity == Vector2.Zero)
            {
                System.Random random = new System.Random();
                Velocity = new Vector2((float) random.NextDouble(), (float) random.NextDouble());
            }
            // Console.WriteLine(Velocity);
            //Console.WriteLine(currentTime);
            
            Coordinates += Velocity * currentTime;
            //Console.WriteLine(Coordinates.X);
            //Console.WriteLine("a");
            //Trace.WriteLine(Coordinates);
            //Console.WriteLine(Coordinates.Y);
            if (Coordinates.X < _radius || Coordinates.X > Board.WIDTH - _radius) Velocity *= -Vector2.UnitX;
            if (Coordinates.Y < _radius || Coordinates.Y > Board.HEIGHT - _radius) Velocity *= -Vector2.UnitY;
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