namespace FileExplorer.ViewModels
{
    using Caliburn.Micro;

    using FileExplorer.Services.Interfaces;
    using FileExplorer.ViewModels.Interfaces;
    using FileExplorer.ViewModels.TreeView.Interfaces;

    internal class FileSystemStructureViewModel : ViewModelBase, IFileSystemStructureViewModel
    {
        public FileSystemStructureViewModel(IFileSystemService fileSystemService)
        {
            Drives = new BindableCollection<IDriveViewModel>(fileSystemService.GetDrives());
        }

        public IObservableCollection<IDriveViewModel> Drives { get; }
    }
}