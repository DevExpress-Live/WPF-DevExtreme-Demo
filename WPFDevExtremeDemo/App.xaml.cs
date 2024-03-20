using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using System.Windows;

namespace WPFDevExtremeDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            CompatibilitySettings.UseLightweightThemes = true;

            var splashScreenViewModel = new DXSplashScreenViewModel()
            {
                Title = "WPF DevExtreme Demo",
                Subtitle = "Grid and Spreadsheet",
                Copyright = "Copyright © 2024 DevExpress.\nAll rights reserved."
            };
            SplashScreenManager.Create(() => new SplashScreen1(), splashScreenViewModel).ShowOnStartup();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ThemedWindow.RoundCorners = true;
        }
    }
}
