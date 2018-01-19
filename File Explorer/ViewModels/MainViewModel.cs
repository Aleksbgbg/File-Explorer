namespace FileExplorer.ViewModels
{
    using FileExplorer.ViewModels.Interfaces;

    internal class MainViewModel : ViewModelBase, IMainViewModel
    {
        public MainViewModel(IFolderStructureViewModel folderStructureViewModel)
        {
            FolderStructureViewModel = folderStructureViewModel;
        }

        public IFolderStructureViewModel FolderStructureViewModel { get; }
    }
}