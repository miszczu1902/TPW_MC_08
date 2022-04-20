using System.Windows.Input;
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
      this.Close();
    }

    private void Close()
    {
      throw new System.NotImplementedException();
    }
  }
}