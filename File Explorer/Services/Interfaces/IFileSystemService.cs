namespace FileExplorer.Services.Interfaces
{
    using System.Collections.Generic;

    using FileExplorer.ViewModels.FileSystem.Interfaces;

    internal interface IFileSystemService
    {
        IEnumerable<IFolderViewModel> GetRootDrives();

        IEnumerable<IFolderViewModel> GetFolders(string path);
    }
}