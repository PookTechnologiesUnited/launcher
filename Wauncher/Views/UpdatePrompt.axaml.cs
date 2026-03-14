using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Wauncher.Utils;
using Wauncher.ViewModels;
using Wauncher.Views;

namespace Wauncher;

public partial class UpdatePrompt : Window
{
    private MainWindow? _mainWindow = null;
    public UpdatePrompt()
    {
        InitializeComponent();
        DataContext = new UpdatePromptViewModel();
    }

    private async void Button_Update(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        await Services.GetLatestRelease();
    }

    private void Button_Reject(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        RejectUpdate();
        this.Close();
    }

    protected override void OnClosing(WindowClosingEventArgs e)
    {
        if (_mainWindow == null)
        {
            RejectUpdate();
        }
        base.OnClosing(e);
    }

    private void RejectUpdate()
    {
        _mainWindow = new MainWindow { DataContext = new MainWindowViewModel() };
        _mainWindow.Show();

        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) { desktop.MainWindow = _mainWindow; }
    }
}
