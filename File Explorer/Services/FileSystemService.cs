namespace FileExplorer.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Caliburn.Micro;

    using FileExplorer.Services.Interfaces;
    using FileExplorer.ViewModels.FileSystem.Interfaces;

    internal class FileSystemService : IFileSystemService
    {
        public IEnumerable<IFolderViewModel> GetRootDrives()
        {
            return DriveInfo.GetDrives().Select(rootDrive => MakeFolder(rootDrive.Name));
        }

        public IEnumerable<IFolderViewModel> GetFolders(string path)
        {
            try
            {
                return Directory.GetDirectories(path).Select(MakeFolder);
            }
            catch
            {
                return new IFolderViewModel[0];
            }
        }

        private static IFolderViewModel MakeFolder(string path)
        {
            IFolderViewModel folderViewModel = IoC.Get<IFolderViewModel>();
            folderViewModel.Path = path;

            return folderViewModel;
        }
    }
}