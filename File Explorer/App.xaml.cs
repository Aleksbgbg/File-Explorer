namespace FileExplorer
{
#if DEBUG
    using System.Windows;
#endif

    public partial class App
    {
#if DEBUG
        public App() => Dispatcher.UnhandledException += (sender, e) =>
        {
            e.Handled = true;
            MessageBox.Show($"Operation unsucessful.\n\n{e.Exception.Message}", "An Error Occurred", MessageBoxButton.OK, MessageBoxImage.Error);
        };
#endif
    }
}