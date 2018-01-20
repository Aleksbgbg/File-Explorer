namespace FileExplorer.ViewModels
{
    using Caliburn.Micro;

    using FileExplorer.Services.Interfaces;
    using FileExplorer.ViewModels.Interfaces;
    using FileExplorer.ViewModels.TreeView.Interfaces;

    internal class FolderStructureViewModel : ViewModelBase, IFolderStructureViewModel
    {
        public FolderStructureViewModel(IFileSystemService fileSystemService)
        {
            Drives = new BindableCollection<IDriveViewModel>(fileSystemService.GetDrives());
        }

        public IObservableCollection<IDriveViewModel> Drives { get; }
    }
}