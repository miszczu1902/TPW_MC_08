using System.Collections;
using System.Collections.ObjectModel;
using Logic;

namespace TP.ConcurrentProgramming.PresentationModel
{
    public abstract class ModelAbstractApi
    {
        public abstract int Width { get; }
        public abstract int Height { get; }

        public abstract IList Balls(int balls);
        public abstract void BeginMove();
        public abstract void StopMove();

        public static ModelAbstractApi CreateApi()
        {
            return new ModelApi();
        }
    }

    internal class ModelApi : ModelAbstractApi
    {
        private LogicApi _logicApi = new LogicApi();
        public override int Width => LogicApi.WIDTH;
        public override int Height => LogicApi.HEIGHT;

        public override IList Balls(int balls)
        {
            _logicApi.CreateBalls(balls);
            return _logicApi.Balls;
        }

        public override void BeginMove()
        {
            _logicApi.StartBalls();
        }

        public override void StopMove()
        {
            _logicApi.Stop();
        }
    }
}