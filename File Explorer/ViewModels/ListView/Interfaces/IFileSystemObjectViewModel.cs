namespace FileExplorer.ViewModels.ListView.Interfaces
{
    using FileExplorer.Models;
    using FileExplorer.ViewModels.Interfaces;

    internal interface IFileSystemObjectViewModel : IViewModelBase
    {
        FileSystemObject Model { get; set; }
    }
}