namespace FileExplorer.ViewModels.FileSystem
{
    using FileExplorer.ViewModels.FileSystem.Interfaces;

    internal abstract class NodeViewModel : ViewModelBase, INodeViewModel
    {
        private string path;
        public string Path
        {
            get => path;

            set
            {
                if (path == value) return;

                path = value;
                NotifyOfPropertyChange(() => Path);
            }
        }
    }
}