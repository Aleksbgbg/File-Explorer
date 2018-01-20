namespace FileExplorer.ViewModels
{
    using Caliburn.Micro;

    using FileExplorer.Models;
    using FileExplorer.Services.Interfaces;
    using FileExplorer.ViewModels.Interfaces;
    using FileExplorer.ViewModels.ListView.Interfaces;

    internal class FolderContentViewModel : ViewModelBase, IFolderContentViewModel, IHandle<Folder>
    {
        private readonly IFileSystemService fileSystemService;

        public FolderContentViewModel(IEventAggregator eventAggreagtor, IFileSystemService fileSystemService)
        {
            eventAggreagtor.Subscribe(this);

            this.fileSystemService = fileSystemService;
        }

        public IObservableCollection<IFileSystemObjectViewModel> Entries { get; } = new BindableCollection<IFileSystemObjectViewModel>();

        private string path;
        public string Path
        {
            get => path;

            set
            {
                if (path == value) return;

                path = value;
                NotifyOfPropertyChange(() => Path);

                Entries.Clear();
                Entries.AddRange(fileSystemService.GetFileSystemObjects(path));
            }
        }

        public void Handle(Folder message)
        {
            Path = message.Path;
        }
    }
}