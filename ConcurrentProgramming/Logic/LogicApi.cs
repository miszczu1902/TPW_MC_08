﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
                ball.Velocity = new Vector2((float) 0.00045, (float) 0.00045);
                ball.Coordinates = new Vector2(random.Next(50, 680), random.Next(50, 310));
                _balls.Add(ball);
            }
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
                            lock(_lock)
                            {
                            ball.UpdatePostion();
                            }
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
    }
}