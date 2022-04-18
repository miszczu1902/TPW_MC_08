using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Board
    {
        public static int WIDTH = 400;
        public static int HEIGHT = 500;

        private List<Ball> _balls = new List<Ball>();
        private Generator _generator = new Generator();

        public Board()
        {
        }

        public void AddBallToBoard(Ball ball)
        {
            _balls.Add(ball);
        }

        public void RemoveBallFromBoard(Ball ball)
        {
            _balls.Remove(ball);
        }

        public void ShowBalls()
        {
            foreach (var ball in _balls)
            {
                Console.Write(" " + ball.Radius);
                Console.WriteLine(ball.Coordinates);
            }
        }

        public void AddBallsOnBoard(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Ball ball = _generator.GenerateBall();
                _balls.Add(ball);
            }
        }

        public void CreateBalls()
        {
            for (int i = 0; i < 5; i++)
            {
                Ball ball = new Ball();
                _generator.GenerateXY();
                ball.Velocity = new Vector2(50 - _generator.Y * 100,
                    50 - _generator.X * 100);
                ball.Coordinates = new Vector2(_generator.X, _generator.Y);
                _balls.Add(ball);
            }
        }

        public List<Ball> Balls
        {
            get => _balls;
            set => _balls = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}