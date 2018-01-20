namespace FileExplorer.ViewModels
{
    using FileExplorer.ViewModels.Interfaces;

    internal class MainViewModel : ViewModelBase, IMainViewModel
    {
        public MainViewModel(IFolderStructureViewModel folderStructureViewModel, IFolderViewModel folderViewModel)
        {
            FolderStructureViewModel = folderStructureViewModel;
            FolderViewModel = folderViewModel;
        }

        public IFolderStructureViewModel FolderStructureViewModel { get; }

        public IFolderViewModel FolderViewModel { get; }
    }
}