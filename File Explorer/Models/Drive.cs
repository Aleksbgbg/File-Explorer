namespace FileExplorer.Models
{
    using System.IO;

    internal class Drive : Folder
    {
        internal Drive(DriveInfo driveInfo) : base($"[{driveInfo.Name.TrimEnd('\\')}] {driveInfo.VolumeLabel}", driveInfo.Name)
        {
        }
    }
}