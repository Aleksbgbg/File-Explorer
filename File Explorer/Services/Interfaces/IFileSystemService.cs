namespace FileExplorer.Services.Interfaces
{
    using System.Collections.Generic;

    using FileExplorer.ViewModels.FileSystem.Interfaces;

    internal interface IFileSystemService
    {
        IEnumerable<IDriveViewModel> GetDrives();

        IEnumerable<IFolderViewModel> GetFolders(string path);

        int GetDirectoryLength(string path);
    }
}