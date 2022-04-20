using System;
using System.Windows.Input;
using Logic;
using TP.ConcurrentProgramming.PresentationModel;
using TP.ConcurrentProgramming.PresentationViewModel.MVVMLight;

namespace TP.ConcurrentProgramming.PresentationViewModel
{
  public class MainWindowViewModel : ViewModelBase

  {
    private int balls;
    private int b_Radious;
    private object coords;
    private readonly ModelAbstractApi ModelLayer = ModelAbstractApi.CreateApi();
    public MainWindowViewModel() : this(ModelAbstractApi.CreateApi())
    { }

    public MainWindowViewModel(ModelAbstractApi modelAbstractApi)
    {
      ModelLayer = modelAbstractApi;
      Radious = ModelLayer.Radius;
      ButtomClick = new RelayCommand(() => ClickHandler());
    }
    
    public int Radious
    {
      get
      {
        return b_Radious;
      }
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
    }


    
    private int _AmountOfBalls;
    public int BallsAmount
    {
      get { return this._AmountOfBalls; }
      set 
      {
        this._AmountOfBalls = value;
          this.RaisePropertyChanged();
      }

      } 

    }
    
    
  }
  
  
