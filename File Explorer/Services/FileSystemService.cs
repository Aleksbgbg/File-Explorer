namespace FileExplorer.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using FileExplorer.Factories.Interfaces;
    using FileExplorer.Services.Interfaces;
    using FileExplorer.ViewModels.ListView.Interfaces;
    using FileExplorer.ViewModels.TreeView.Interfaces;

    using IFolderViewModel = FileExplorer.ViewModels.TreeView.Interfaces.IFolderViewModel;

    internal class FileSystemService : IFileSystemService
    {
        private readonly IFileSystemFactory fileSystemFactory;

        public FileSystemService(IFileSystemFactory fileSystemFactory)
        {
            this.fileSystemFactory = fileSystemFactory;
        }

        public IEnumerable<IDriveViewModel> GetDrives()
        {
            return DriveInfo.GetDrives().Where(drive => drive.IsReady && drive.VolumeLabel != null).Select(fileSystemFactory.MakeDrive);
        }

        public IEnumerable<IFolderViewModel> GetFolders(string path)
        {
            return GetDirectories(path).Select(fileSystemFactory.MakeTreeViewFolder);
        }

        public IEnumerable<IFileSystemObjectViewModel> GetFileSystemObjects(string path)
        {
            return GetDirectories(path).Select(fileSystemFactory.MakeListViewFolder).Concat<IFileSystemObjectViewModel>(GetFiles(path).Select(fileSystemFactory.MakeFile));
        }

        public int GetDirectoryLength(string path)
        {
            return GetDirectories(path).Length;
        }

        private static string[] GetDirectories(string path)
        {
            return GetFileSystemObjects(path, Directory.GetDirectories);
        }

        private static string[] GetFiles(string path)
        {
            return GetFileSystemObjects(path, Directory.GetFiles);
        }

        private static string[] GetFileSystemObjects(string path, Func<string, string[]> method)
        {
            try
            {
                return method(path);
            }
            catch (UnauthorizedAccessException)
            {
                return new string[0];
            }
        }
    }
}