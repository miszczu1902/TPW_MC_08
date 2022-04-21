using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Input;
using TP.ConcurrentProgramming.PresentationModel;
using TP.ConcurrentProgramming.PresentationViewModel.MVVMLight;

namespace TP.ConcurrentProgramming.PresentationViewModel
{
    public class MainWindowViewModel : ViewModelBase

    {
        private readonly ModelAbstractApi ModelLayer = ModelAbstractApi.CreateApi();
        private readonly int _width;
        private readonly int _height;
        private int _amountOfBalls;
        private IList _balls;

        public MainWindowViewModel() : this(ModelAbstractApi.CreateApi())
        {
        }

        public MainWindowViewModel(ModelAbstractApi modelAbstractApi)
        {
            ModelLayer = modelAbstractApi;
            _height = ModelLayer.Height;
            _width = ModelLayer.Width;
            ClickButton = new RelayCommand(() => ClickHandler());
            StopButton = new RelayCommand(() => StopHandler());
            Ballses = ModelLayer.Balls(_amountOfBalls);
        }

        public int ViewHeight
        {
            get { return _height; }
        }

        public int ViewWidth
        {
            get { return _width; }
        }

        public ICommand ClickButton { get; set; }
        public ICommand StopButton { get; set; }

        private void ClickHandler()
        {
            ModelLayer.Balls(_amountOfBalls);

            ModelLayer.BeginMove();
        }

        private void StopHandler()
        {
            ModelLayer.StopMove();
        }


        public int BallsAmount
        {
            get { return _amountOfBalls; }
            set
            {
                _amountOfBalls = value;
                RaisePropertyChanged("BallsAmount");
            }
        }

        public IList Ballses
        {
            get => _balls;
            set
            {
                _balls = value;
                RaisePropertyChanged("Ballses");
            }
        }
    }
}