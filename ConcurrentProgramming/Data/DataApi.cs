using System.Collections.ObjectModel;
using Logic;

namespace Data
{
    public class DataApi : DataAbstarctApi
    {
        public override ObservableCollection<Ball> _balls()
        {
            return new ObservableCollection<Ball>();
        }
    }
}