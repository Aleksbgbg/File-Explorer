namespace FileExplorer.Factories
{
    using System.IO;

    using Caliburn.Micro;

    using FileExplorer.Factories.Interfaces;
    using FileExplorer.Models;
    using FileExplorer.ViewModels.FileSystem.Interfaces;

    internal class FolderFactory : IFolderFactory
    {
        public IDriveViewModel MakeDrive(DriveInfo driveInfo)
        {
            IDriveViewModel driveViewModel = IoC.Get<IDriveViewModel>();
            driveViewModel.Folder = new Drive(driveInfo);

            return driveViewModel;
        }

        public IFolderViewModel MakeFolder(string path)
        {
            IFolderViewModel folderViewModel = IoC.Get<IFolderViewModel>();
            folderViewModel.Folder = new Folder(path);

            return folderViewModel;
        }
    }
}