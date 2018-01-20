namespace FileExplorer.Factories
{
    using System.IO;

    using Caliburn.Micro;

    using FileExplorer.Factories.Interfaces;
    using FileExplorer.Models;
    using FileExplorer.ViewModels.ListView.Interfaces;
    using FileExplorer.ViewModels.TreeView.Interfaces;

    using File = FileExplorer.Models.File;
    using IListViewFolder = FileExplorer.ViewModels.ListView.Interfaces.IFolderViewModel;
    using ITreeViewFolder = FileExplorer.ViewModels.TreeView.Interfaces.IFolderViewModel;

    internal class FileSystemFactory : IFileSystemFactory
    {
        public IDriveViewModel MakeDrive(DriveInfo driveInfo)
        {
            IDriveViewModel driveViewModel = IoC.Get<IDriveViewModel>();
            driveViewModel.Folder = new Drive(driveInfo);

            return driveViewModel;
        }

        public ITreeViewFolder MakeTreeViewFolder(string path)
        {
            ITreeViewFolder folderViewModel = IoC.Get<ITreeViewFolder>();
            folderViewModel.Folder = new Folder(path);

            return folderViewModel;
        }

        public IFileViewModel MakeFile(string path)
        {
            IFileViewModel fileViewModel = IoC.Get<IFileViewModel>();
            fileViewModel.Model = new File(path);

            return fileViewModel;
        }

        public IListViewFolder MakeListViewFolder(string path)
        {
            IListViewFolder folderViewModel = IoC.Get<IListViewFolder>();
            folderViewModel.Model = new Folder(path);

            return folderViewModel;
        }
    }
}