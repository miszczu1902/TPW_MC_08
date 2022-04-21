using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Numerics;
using Logic;

namespace TP.ConcurrentProgramming.PresentationModel
{
    public abstract class ModelAbstractApi
    {
        public abstract int Radius { get; }
        public abstract int Width { get; }
        public abstract int Height { get; }

        public abstract ObservableCollection<Ball> Coordinates(int balls);
        public abstract void BeginMove();
        public static ModelAbstractApi CreateApi()
        {
            return new ModelApi();
        }

        
    }

    internal class ModelApi : ModelAbstractApi
    {
        private Board Board = new Board();
        public override int Radius => 25;
        public override int Width => Board.WIDTH;
        public override int Height => Board.HEIGHT;
        public override ObservableCollection<Ball> Coordinates(int balls)
        {
            Board.CreateBalls(balls);
            foreach (var ball in Board.Balls)
            {
                // Trace.WriteLine("x");
                // Trace.WriteLine(ball.Coordinates.X);
                // Trace.WriteLine("y");
                // Trace.WriteLine(ball.Coordinates.Y);
                Trace.WriteLine("x");
                Trace.WriteLine(ball.Coordinates.X);
                Trace.WriteLine("y");
                Trace.WriteLine(ball.Coordinates.Y);
            }
            
            return Board.Balls;
        }

        public override void BeginMove()
        {
            Board.StartBalls();
        }


    }
}