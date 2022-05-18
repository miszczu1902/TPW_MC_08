using System.Collections.ObjectModel;
using Logic;

namespace Data
{
    public abstract class DataAbstarctApi
    {
        public static DataAbstarctApi CreateBallsData()
        {
            return new DataApi();
        }

        public abstract ObservableCollection<Ball> _balls();
    }
}