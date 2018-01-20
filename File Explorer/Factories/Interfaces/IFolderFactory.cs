namespace FileExplorer.Factories.Interfaces
{
    using System.IO;

    using FileExplorer.ViewModels.FileSystem.Interfaces;

    internal interface IFolderFactory
    {
        IDriveViewModel MakeDrive(DriveInfo driveInfo);

        IFolderViewModel MakeFolder(string path);
    }
}