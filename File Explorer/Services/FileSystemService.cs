namespace FileExplorer.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using FileExplorer.Factories.Interfaces;
    using FileExplorer.Services.Interfaces;
    using FileExplorer.ViewModels.FileSystem.Interfaces;

    internal class FileSystemService : IFileSystemService
    {
        private readonly IFolderFactory folderFactory;

        public FileSystemService(IFolderFactory folderFactory)
        {
            this.folderFactory = folderFactory;
        }

        public IEnumerable<IDriveViewModel> GetDrives()
        {
            return DriveInfo.GetDrives().Where(drive => drive.IsReady && drive.VolumeLabel != null).Select(folderFactory.MakeDrive);
        }

        public IEnumerable<IFolderViewModel> GetFolders(string path)
        {
            return GetDirectories(path).Select(folderFactory.MakeFolder);
        }

        public int GetDirectoryLength(string path)
        {
            return GetDirectories(path).Length;
        }

        private static string[] GetDirectories(string path)
        {
            try
            {
                return Directory.GetDirectories(path);
            }
            catch (UnauthorizedAccessException)
            {
                return new string[0];
            }
        }
    }
}