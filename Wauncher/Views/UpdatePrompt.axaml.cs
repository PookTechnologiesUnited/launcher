using Avalonia.Controls;
using Wauncher.Utils;

namespace Wauncher;

public partial class UpdatePrompt : Window
{
    public UpdatePrompt()
    {
        InitializeComponent();
    }
    
    private async void Button_Update(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        await Services.GetLatestRelease();
    }
}
