using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.Input;
using Launcher.Utils;
using Wauncher.Utils;
using Wauncher.ViewModels;
using Wauncher.Views;

namespace Wauncher
{
    public partial class App : Application
    {
        public bool NewVersionAvailable = false;
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            Discord.Init();
            ProtocolManager.RegisterURIHandler();

            if (!Argument.Exists("--skip-updates"))
            {
                Services.LatestVersion = Task.Run(async () => await Wauncher.Utils.Version.GetLatestVersion()).GetAwaiter().GetResult();
                if (Wauncher.Utils.Version.Current != Services.LatestVersion) NewVersionAvailable = true;
            }
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
                // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
                DisableAvaloniaDataAnnotationValidation();

                if (NewVersionAvailable)
                {
                    desktop.MainWindow = new UpdatePrompt();
                }
                else
                {
                    desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel()
                };
                }
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void DisableAvaloniaDataAnnotationValidation()
        {
            // Get an array of plugins to remove
            var dataValidationPluginsToRemove =
                BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

            // remove each entry found
            foreach (var plugin in dataValidationPluginsToRemove)
            {
                BindingPlugins.DataValidators.Remove(plugin);
            }
        }


        [RelayCommand]
        public void TrayIconClicked()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop && desktop.MainWindow != null)
            {
                desktop.MainWindow.Show();
                desktop.MainWindow.Activate();
            }
        }

        public void ExitApplication_Click(object? sender, System.EventArgs e)
        {
            switch (ApplicationLifetime)
            {
                case IClassicDesktopStyleApplicationLifetime desktopLifetime:
                    desktopLifetime.TryShutdown();
                    break;
                case IControlledApplicationLifetime controlledLifetime:
                    controlledLifetime.Shutdown();
                    break;
            }
        }
    }
}