using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfBase_Template.Interfaces.ViewModels;

/// <summary>
/// Interface of the MainPage view model.
/// </summary>
public interface IShellWindowViewModel
{
    /// <summary>
    /// Gets the GoBackCmd.
    /// </summary>
    public RelayCommand GoBackCmd { get; }

    /// <summary>
    /// Gets the LoadedCmd.
    /// </summary>
    public ICommand LoadedCmd { get; }

    /// <summary>
    /// Gets the UnloadedCmd.
    /// </summary>
    public ICommand UnloadedCmd { get; }

    /// <summary>
    /// Gets the MenuItems.
    /// </summary>
    public ObservableCollection<MenuItem> MenuItems { get; }
}