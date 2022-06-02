using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public class LogicApi : LogicAbstractApi
    {
        public static int WIDTH = 720;
        public static int HEIGHT = 360;
        private CancellationToken _cancellationToken;
        private CancellationTokenSource _cancellationTokenSource;
        private DataAbstarctApi _data;
        private IList _balls;
        private List<Task> _tasks = new List<Task>();
        private object _lock = new object();

        public LogicApi()
        {
            _data = DataAbstarctApi.CreateBallsData();
            _balls = _data._balls();
        }

        public int TasksAmount
        {
            get => _tasks.Count;
        }

        public CancellationToken CancellationToken => _cancellationToken;

        public CancellationTokenSource CancellationTokenSource => _cancellationTokenSource;

        public IList Balls
        {
            get => _balls;
        }

        public void CreateBalls(int countBalls)
        {
            if (countBalls < 0)
            {
                throw new Exception("Ujemna Liczba");
            }

            if (Balls.Count != 0)
            {
                _tasks.Clear();
                Balls.Clear();
            }


            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;

            Random random = new Random();

            for (int i = 0; i < countBalls; i++)
            {
                Ball ball = new Ball();
                ball.Id = i + 1;
                ball.Velocity = new Vector2((float) 0.00045, (float) 0.00045);
                // ball.Coordinates = new Vector2(random.Next(50, 680), random.Next(50, 310));
                if (i == 0)
                {
                    ball.Coordinates = new Vector2(random.Next(50, 680), random.Next(50, 310));
                }
                else
                {
                    bool restart;
                    do
                    {
                        restart = false;
                        foreach (Ball bl in _balls)
                        {
                            restart = false;
                            if (bl.Equals(ball)) continue;
                            ball.Coordinates = new Vector2(random.Next(50, 680), random.Next(50, 310));
                            if (Vector2.Distance(ball.Coordinates, bl.Coordinates) <= 75 &&
                                Vector2.Distance(ball.Coordinates, bl.Coordinates)
                                - Vector2.Distance(ball.Coordinates + ball.Velocity, bl.Coordinates + bl.Velocity) >
                                0)
                            {
                                restart = true;
                            }

                            if (restart)
                            {
                                break;
                            }
                        }
                    } while (restart);
                }

                _balls.Add(ball);
            }

            _data.BallsList = _balls;
        }

        public void StartBalls()
        {
            foreach (Ball ball in _balls)
            {
                Task task = Task.Run(() =>
                    {
                        Thread.Sleep(1);
                        while (true)
                        {
                            Thread.Sleep(10);
                            try
                            {
                                _cancellationToken.ThrowIfCancellationRequested();
                            }
                            catch (OperationCanceledException)
                            {
                                break;
                            }

                            DetectHits(ball);
                        }
                    }
                );
                _tasks.Add(task);
            }
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
            _tasks.Clear();
            _balls.Clear();
        }

        public void DetectHits(Ball bl)
        {
            UpdatePosition(bl);

            bl.Coordinates += new Vector2(bl.Velocity.X * bl.Speed, bl.Velocity.Y * bl.Speed);

            foreach (Ball ball in _balls)
            {
                if (ball == bl)
                {
                    continue;
                }

                if (bl.Coordinates.X < bl.Radius || bl.Coordinates.X > DataApi.WIDTH)
                {
                    bl.VelocityX *= -1;
                }

                if (bl.Coordinates.Y < bl.Radius || bl.Coordinates.Y > DataApi.HEIGHT)
                {
                    bl.VelocityY *= -1;
                }

                if (Vector2.Distance(ball.Coordinates, bl.Coordinates) <= bl.Radius &&
                    Vector2.Distance(ball.Coordinates, bl.Coordinates)
                    - Vector2.Distance(ball.Coordinates + ball.Velocity, bl.Coordinates + bl.Velocity) > 0)
                {
                    Vector2 newVelocity2 = (bl.Velocity * (bl.Mass - ball.Mass) + 2 * ball.Mass * ball.Velocity) /
                                           (bl.Mass + ball.Mass);
                    Vector2 newVelocity1 = (ball.Velocity * (ball.Mass - bl.Mass) + 2 * bl.Mass * bl.Velocity) /
                                           (bl.Mass + ball.Mass);
                    
                    ball.Velocity = newVelocity1;
                    bl.Velocity = newVelocity2;
                }
            }
        }

        public void UpdatePosition(Ball bl)
        {
            bl.Coordinates += new Vector2(bl.Velocity.X * bl.Speed, bl.Velocity.Y * bl.Speed);
            
            lock (_lock)
            {
                if (bl.Coordinates.X < bl.Radius || bl.Coordinates.X > DataApi.WIDTH)
                {
                    bl.VelocityX *= -1;
                }

                if (bl.Coordinates.Y < bl.Radius || bl.Coordinates.Y > DataApi.HEIGHT)
                {
                    bl.VelocityY *= -1;
                }
                _data.SaveDataToFile();
            }
        }
    }
}