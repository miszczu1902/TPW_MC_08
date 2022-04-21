using System.Collections;
using System.Windows.Input;
using TP.ConcurrentProgramming.PresentationModel;
using TP.ConcurrentProgramming.PresentationViewModel.MVVMLight;

namespace TP.ConcurrentProgramming.PresentationViewModel
{
    public class MainWindowViewModel : ViewModelBase

    {
        private int _AmountOfBalls;
        private int b_Radious;
        private int _width;
        private int _height;
        private IList coords;
        private readonly ModelAbstractApi ModelLayer = ModelAbstractApi.CreateApi(); 
        public MainWindowViewModel() : this(ModelAbstractApi.CreateApi())
        {
        }

        public MainWindowViewModel(ModelAbstractApi modelAbstractApi)
        {
            ModelLayer = modelAbstractApi;
            Radious = ModelLayer.Radius;
            _height = ModelLayer.Height;
            _width = ModelLayer.Width;
            ButtomClick = new RelayCommand(() => ClickHandler());
            Coords = ModelLayer.Coordinates(_AmountOfBalls);
        }

        public int Radious
        {
            get { return b_Radious; }
            set
            {
                if (value.Equals(b_Radious))
                    return;
                b_Radious = value;
                RaisePropertyChanged("Radious");
            }
        }

        public int viewHeight
        {
            get{return _height;}
    }
        public int viewWidth
        {
            get{return _width;}
    }
        


        public ICommand ButtomClick { get; set; }

        private void ClickHandler()
        {
            ModelLayer.Coordinates(_AmountOfBalls);
            ModelLayer.BeginMove();
        }
        
        public int BallsAmount
        {
            get { return _AmountOfBalls; }
            set
            {
                _AmountOfBalls = value;
                RaisePropertyChanged("BallsAmount");
            }
        }

        public IList Coords
        {
            get => coords;
            set
            {
                coords = value;
                RaisePropertyChanged("Coords");
            }
        }
    }
}