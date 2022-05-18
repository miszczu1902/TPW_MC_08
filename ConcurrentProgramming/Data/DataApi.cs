using System.Collections.ObjectModel;
using Logic;

namespace Data
{
    public class DataApi : DataAbstarctApi
    {
        public static int WIDTH = 720;
        public static int HEIGHT = 360; 
        public override ObservableCollection<Ball> _balls()
        {
            return new ObservableCollection<Ball>();
        }
    }
}