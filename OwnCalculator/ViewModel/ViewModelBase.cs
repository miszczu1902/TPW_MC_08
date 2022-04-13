using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;
using ViewModel.Annotations;

namespace ViewModel;

public class ViewModelBase : INotifyPropertyChanged
{
    private ModelApi _modelApi;
    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}