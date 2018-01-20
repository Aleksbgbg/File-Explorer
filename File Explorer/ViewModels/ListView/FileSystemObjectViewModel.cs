namespace FileExplorer.ViewModels.ListView
{
    using FileExplorer.Models;
    using FileExplorer.ViewModels.ListView.Interfaces;

    internal abstract class FileSystemObjectViewModel : ViewModelBase, IFileSystemObjectViewModel
    {
        public abstract FileSystemObject Model { get; set; }

        public override string DisplayName => Model.Name;

        public abstract void DoubleClick();
    }
}