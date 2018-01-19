namespace FileExplorer.ViewModels.FileSystem
{
    using Caliburn.Micro;

    using FileExplorer.Services.Interfaces;
    using FileExplorer.ViewModels.FileSystem.Interfaces;

    using IOPath = System.IO.Path;

    internal class FolderViewModel : NodeViewModel, IFolderViewModel
    {
        private readonly IFileSystemService fileSystemService;

        public FolderViewModel(IFileSystemService fileSystemService)
        {
            this.fileSystemService = fileSystemService;
        }

        private IObservableCollection<IFolderViewModel> folders;
        public IObservableCollection<IFolderViewModel> Folders => folders ?? (folders = new BindableCollection<IFolderViewModel>(fileSystemService.GetFolders(Path)));

        public override string DisplayName
        {
            get => IOPath.GetFileName(Path);

            set
            {
            }
        }
    }
}