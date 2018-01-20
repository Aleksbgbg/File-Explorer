namespace FileExplorer.ViewModels.FileSystem.Interfaces
{
    using FileExplorer.Models;
    using FileExplorer.ViewModels.Interfaces;

    internal interface IFolderViewModel : IViewModelBase
    {
        Folder Folder { get; set; }
    }
}