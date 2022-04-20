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
        private IList coords;
        private readonly ModelAbstractApi ModelLayer = ModelAbstractApi.CreateApi();

        public MainWindowViewModel() : this(ModelAbstractApi.CreateApi())
        {
        }

        public MainWindowViewModel(ModelAbstractApi modelAbstractApi)
        {
            ModelLayer = modelAbstractApi;
            Radious = ModelLayer.Radius;
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