using System.Collections.Generic;
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
    }

    internal class ModelApi : ModelAbstractApi
    {
        public override int Radius => 25;

        public override ObservableCollection<Vector2> Coordinates(int balls)
        {
            Board board = new Board();
            board.CreateBalls(balls);
            return board.BallsCords;
        }
    }
}