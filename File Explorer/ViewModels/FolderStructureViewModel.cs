namespace FileExplorer.ViewModels
{
    using Caliburn.Micro;

    using FileExplorer.Services.Interfaces;
    using FileExplorer.ViewModels.FileSystem.Interfaces;
    using FileExplorer.ViewModels.Interfaces;

    internal class FolderStructureViewModel : ViewModelBase, IFolderStructureViewModel
    {
        public FolderStructureViewModel(IFileSystemService fileSystemService)
        {
            Drives = new BindableCollection<IFolderViewModel>(fileSystemService.GetRootDrives());
        }

        public IObservableCollection<IFolderViewModel> Drives { get; }
    }
}