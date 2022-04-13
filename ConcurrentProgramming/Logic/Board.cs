using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Board
    {
        private int _a = 400;
        private List<Ball> _balls = new List<Ball>();
        private Generator _generator = new Generator();

        public Board() { }

        public int A
        {
            get => _a;
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
            for (int i = 0; i < _balls.Count; i++)
            {
                Console.Write(" "+_balls[i].X);
                Console.Write(" "+_balls[i].Y);
                Console.Write(" "+_balls[i].Radius);
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

    }
}
