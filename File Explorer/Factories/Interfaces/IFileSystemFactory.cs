namespace FileExplorer.Factories.Interfaces
{
    using System.IO;

    using FileExplorer.ViewModels.ListView.Interfaces;
    using FileExplorer.ViewModels.TreeView.Interfaces;

    using IListViewFolder = FileExplorer.ViewModels.ListView.Interfaces.IFolderViewModel;
    using ITreeViewFolder = FileExplorer.ViewModels.TreeView.Interfaces.IFolderViewModel;

    internal interface IFileSystemFactory
    {
        #region TreeView

        IDriveViewModel MakeDrive(DriveInfo driveInfo);

        ITreeViewFolder MakeTreeViewFolder(string path);

        #endregion TreeView

        #region ListView

        IFileViewModel MakeFile(string path);

        IListViewFolder MakeListViewFolder(string path);

        #endregion ListView
    }
}