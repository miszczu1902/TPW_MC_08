using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public class Board
    {
        public static int WIDTH = 720;
        public static int HEIGHT = 360;
        private ObservableCollection<Ball> _balls = new ObservableCollection<Ball>();
        private Generator _generator = new Generator();
        private List<Task> _tasks = new List<Task>();
        private ObservableCollection<Vector2> _ballsCords = new ObservableCollection<Vector2>();

        public Board()
        {
        }

        public ObservableCollection<Vector2> BallsCords
        {
            get => _ballsCords;
            set => _ballsCords = value ?? throw new ArgumentNullException(nameof(value));
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

        public ObservableCollection<Ball> Balls
        {
            get => _balls;
            set => _balls = value ?? throw new ArgumentNullException(nameof(value));
        }

        public void AddBallsOnBoard(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Ball ball = _generator.GenerateBall();
                _balls.Add(ball);
            }
        }

        public void CreateBalls(int countBalls)
        {
            Random random = new Random();

            for (int i = 0; i < countBalls; i++)
            {
                Ball ball = new Ball();
                // _generator.GenerateXY();
                ball.Velocity = Vector2.Zero;
                // ball.Velocity = new Vector2(50 - (float) random.NextDouble() * 100,
                //  50 - (float) random.NextDouble() * 100);
                ball.Coordinates = new Vector2(random.Next(50, 680), random.Next(50, 310));
                _balls.Add(ball);
                _ballsCords.Add(ball.Coordinates);
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
                        Thread.Sleep(30);
                        ball.UpdatePostion(DateTime.Now.Second);

                        // ShowBalls();
                    }
                });
                //Thread.Sleep(1);
                _tasks.Add(task);
                //task.Start();
            }

            // Task.WaitAll(_tasks.ToArray());
            // foreach (Task t in _tasks)
            //     Console.WriteLine("Task {0} Status: {1}", t.Id, t.Status);
        }
    }
}