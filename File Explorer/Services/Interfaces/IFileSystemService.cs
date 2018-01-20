namespace FileExplorer.Services.Interfaces
{
    using System.Collections.Generic;

    using FileExplorer.ViewModels.ListView.Interfaces;
    using FileExplorer.ViewModels.TreeView.Interfaces;

    using IFolderViewModel = FileExplorer.ViewModels.TreeView.Interfaces.IFolderViewModel;

    internal interface IFileSystemService
    {
        IEnumerable<IDriveViewModel> GetDrives();

        IEnumerable<IFolderViewModel> GetFolders(string path);

        IEnumerable<IFileSystemObjectViewModel> GetFileSystemObjects(string path);

        int GetDirectoryLength(string path);
    }
}