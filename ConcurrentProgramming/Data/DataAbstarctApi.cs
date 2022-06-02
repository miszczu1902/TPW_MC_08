using System;
using System.Collections;
using System.Collections.ObjectModel;
using Logic;

namespace Data
{
    public abstract class DataAbstarctApi
    {
        private IList _ballsList;
        public static DataAbstarctApi CreateBallsData()
        {
            return new DataApi();
        }

        public IList BallsList
        {
            get => _ballsList;
            set => _ballsList = value ?? throw new ArgumentNullException(nameof(value));
        }

        public abstract ObservableCollection<Ball> _balls();

        public abstract string SaveBallData(Ball ball);

        public abstract void SaveDataToFile();
    }
}