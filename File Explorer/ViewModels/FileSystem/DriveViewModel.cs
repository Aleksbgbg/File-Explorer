namespace FileExplorer.ViewModels.FileSystem
{
    using FileExplorer.Services.Interfaces;
    using FileExplorer.ViewModels.FileSystem.Interfaces;

    internal class DriveViewModel : FolderViewModel, IDriveViewModel
    {
        public DriveViewModel(IFileSystemService fileSystemService) : base(fileSystemService)
        {
        }
    }
}