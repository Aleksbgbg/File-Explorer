namespace FileExplorer.ViewModels.TreeView
{
    using Caliburn.Micro;

    using FileExplorer.Services.Interfaces;
    using FileExplorer.ViewModels.TreeView.Interfaces;

    internal class DriveViewModel : FolderViewModel, IDriveViewModel
    {
        public DriveViewModel(IEventAggregator eventAggregator, IFileSystemService fileSystemService) : base(eventAggregator, fileSystemService)
        {
        }
    }
}