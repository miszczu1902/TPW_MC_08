using System.Collections.ObjectModel;
using Logic;

namespace TP.ConcurrentProgramming.PresentationModel
{
    public abstract class ModelAbstractApi
    {
        public abstract int Width { get; }
        public abstract int Height { get; }

        public abstract ObservableCollection<Ball> Balls(int balls);
        public abstract void BeginMove();
        public abstract void StopMove();

        public static ModelAbstractApi CreateApi()
        {
            return new ModelApi();
        }
    }

    internal class ModelApi : ModelAbstractApi
    {
        private Board Board = new Board();
        public override int Width => Board.WIDTH;
        public override int Height => Board.HEIGHT;

        public override ObservableCollection<Ball> Balls(int balls)
        {
            Board.CreateBalls(balls);
            return Board.Balls;
        }

        public override void BeginMove()
        {
            Board.StartBalls();
        }

        public override void StopMove()
        {
            Board.Stop();
        }
    }
}