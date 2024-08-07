using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

///TODO: Add comments

namespace WpfBase_Template.Interfaces.ViewModels;

public interface IShellWindowViewModel
{
    public RelayCommand GoBackCmd { get; }
    public ICommand LoadedCmd { get; }
    public ICommand UnloadedCmd { get; }

    public ObservableCollection<MenuItem> MenuItems { get; }
}