using System.Collections.ObjectModel;
using System.Numerics;
using Logic;

namespace TP.ConcurrentProgramming.PresentationModel
{
    public abstract class ModelAbstractApi
    {
        public abstract int Radius { get; }

        public abstract ObservableCollection<Vector2> Coordinates(int balls);

        public static ModelAbstractApi CreateApi()
        {
            return new ModelApi();
        }

        public abstract void BeginMove();
    }

    internal class ModelApi : ModelAbstractApi
    {
        private Board Board = new Board();
        public override int Radius => 25;

        public override ObservableCollection<Vector2> Coordinates(int balls)
        {
            Board.CreateBalls(balls);
            return Board.BallsCords;
        }

        public override void BeginMove()
        {
            Board.StartBalls();
        }
    }
}