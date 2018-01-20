namespace FileExplorer.ViewModels.ListView
{
    using FileExplorer.Models;
    using FileExplorer.ViewModels.ListView.Interfaces;

    internal class FileViewModel : FileSystemObjectViewModel, IFileViewModel
    {
        private File file;
        public File File
        {
            get => file;

            set
            {
                if (file == value) return;

                file = value;
                NotifyOfPropertyChange(() => File);
            }
        }

        public override FileSystemObject Model
        {
            get => file;

            set => File = (File)value;
        }
    }
}