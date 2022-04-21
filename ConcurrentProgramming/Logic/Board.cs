using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Threading.Tasks;

namespace Logic
{
    public class Board
    {
        public static int WIDTH = 720;
        public static int HEIGHT = 360;
        private ObservableCollection<Ball> _balls = new ObservableCollection<Ball>();
        private List<Task> _tasks = new List<Task>();

        public Board()
        {
        }

        public ObservableCollection<Ball> Balls
        {
            get => _balls;
        }

        public void CreateBalls(int countBalls)
        {
            if (Balls.Count != 0)
            {
                Balls.Clear();
            }

            Random random = new Random();

            for (int i = 0; i < countBalls; i++)
            {
                Ball ball = new Ball();
                ball.Velocity = new Vector2((float) 0.00045, (float) 0.00045);
                ball.Coordinates = new Vector2(random.Next(50, 680), random.Next(50, 310));
                _balls.Add(ball);
            }
        }

        public void StartBalls()
        {
            foreach (var ball in _balls)
            {
                Task task = Task.Run(() =>
                {
                    while (true)
                    {
                        ball.UpdatePostion();
                    }
                });
                _tasks.Add(task);
            }
        }
    }
}