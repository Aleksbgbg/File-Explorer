namespace FileExplorer.ViewModels
{
    using FileExplorer.ViewModels.Interfaces;

    internal class ShellViewModel : ViewModelBase, IShellViewModel
    {
        public ShellViewModel(IMainViewModel mainViewModel) => MainViewModel = mainViewModel;

        public IMainViewModel MainViewModel { get; }

        public override string DisplayName
        {
            get => "FileExplorer";

            set
            {
            }
        }
    }
}