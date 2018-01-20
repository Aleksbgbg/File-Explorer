namespace FileExplorer.ViewModels.TreeView
{
    using Caliburn.Micro;

    using FileExplorer.Models;
    using FileExplorer.Services.Interfaces;
    using FileExplorer.ViewModels.TreeView.Interfaces;

    internal class FolderViewModel : ViewModelBase, IFolderViewModel
    {
        private readonly IEventAggregator eventAggregator;

        private readonly IFileSystemService fileSystemService;

        public FolderViewModel(IEventAggregator eventAggregator, IFileSystemService fileSystemService)
        {
            this.eventAggregator = eventAggregator;
            this.fileSystemService = fileSystemService;
        }

        public override string DisplayName => Folder.Name;

        public IObservableCollection<IFolderViewModel> Folders { get; } = new BindableCollection<IFolderViewModel>();

        private Folder folder;
        public virtual Folder Folder
        {
            get => folder;

            set
            {
                if (folder == value) return;

                folder = value;
                NotifyOfPropertyChange(() => Folder);

                AddPlaceholderFolder();
            }
        }

        private bool isExpanded;
        public bool IsExpanded
        {
            get => isExpanded;

            set
            {
                if (isExpanded == value) return;

                isExpanded = value;
                NotifyOfPropertyChange(() => IsExpanded);

                Folders.Clear();

                if (isExpanded)
                {
                    Folders.AddRange(fileSystemService.GetFolders(Folder.Path));
                }
                else
                {
                    AddPlaceholderFolder();
                }
            }
        }

        private bool isSelected;
        public bool IsSelected
        {
            get => isSelected;

            set
            {
                if (isSelected == value) return;

                isSelected = value;
                NotifyOfPropertyChange(() => IsSelected);

                if (isSelected)
                {
                    eventAggregator.BeginPublishOnUIThread(Folder);
                }
            }
        }

        private void AddPlaceholderFolder()
        {
            if (fileSystemService.GetDirectoryLength(folder.Path) > 0)
            {
                Folders.Add(null);
            }
        }
    }
}