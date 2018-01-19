namespace FileExplorer.ViewModels.FileSystem.Interfaces
{
    using FileExplorer.ViewModels.Interfaces;

    internal interface INodeViewModel : IViewModelBase
    {
        string Path { get; set; }
    }
}