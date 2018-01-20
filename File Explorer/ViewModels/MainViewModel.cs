namespace FileExplorer.ViewModels
{
    using FileExplorer.ViewModels.Interfaces;

    internal class MainViewModel : ViewModelBase, IMainViewModel
    {
        public MainViewModel(IFileSystemStructureViewModel fileSystemStructureViewModel, IFolderContentViewModel folderContentViewModel)
        {
            FileSystemStructureViewModel = fileSystemStructureViewModel;
            FolderContentViewModel = folderContentViewModel;
        }

        public IFileSystemStructureViewModel FileSystemStructureViewModel { get; }

        public IFolderContentViewModel FolderContentViewModel { get; }
    }
}