namespace FileExplorer.ViewModels.ListView
{
    using Caliburn.Micro;

    using FileExplorer.Models;
    using FileExplorer.ViewModels.ListView.Interfaces;

    internal class FolderViewModel : FileSystemObjectViewModel, IFolderViewModel
    {
        private readonly IEventAggregator eventAggregator;

        public FolderViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }

        private Folder folder;
        public Folder Folder
        {
            get => folder;

            set
            {
                if (folder == value) return;

                folder = value;
                NotifyOfPropertyChange(() => Folder);
            }
        }

        public override FileSystemObject Model
        {
            get => folder;

            set => Folder = (Folder)value;
        }

        public override void DoubleClick()
        {
            eventAggregator.BeginPublishOnUIThread(Folder);
        }
    }
}