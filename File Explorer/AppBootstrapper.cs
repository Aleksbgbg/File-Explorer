namespace FileExplorer
{
    using System;
    using System.Collections.Generic;
    using System.Windows;

    using Caliburn.Micro;

    using FileExplorer.Factories;
    using FileExplorer.Factories.Interfaces;
    using FileExplorer.Services;
    using FileExplorer.Services.Interfaces;
    using FileExplorer.ViewModels;
    using FileExplorer.ViewModels.Interfaces;
    using FileExplorer.ViewModels.ListView;
    using FileExplorer.ViewModels.ListView.Interfaces;
    using FileExplorer.ViewModels.TreeView;
    using FileExplorer.ViewModels.TreeView.Interfaces;

    using ListViewFolder = FileExplorer.ViewModels.ListView.FolderViewModel;
    using TreeViewFolder = FileExplorer.ViewModels.TreeView.FolderViewModel;
    using IListViewFolder = FileExplorer.ViewModels.ListView.Interfaces.IFolderViewModel;
    using ITreeViewFolder = FileExplorer.ViewModels.TreeView.Interfaces.IFolderViewModel;

    internal class AppBootstrapper : BootstrapperBase
    {
        private readonly SimpleContainer container = new SimpleContainer();

        internal AppBootstrapper() => Initialize();

        protected override void BuildUp(object instance) => container.BuildUp(instance);

        protected override void Configure()
        {
            // Register Services
            container.Singleton<IEventAggregator, EventAggregator>();
            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IFileSystemService, FileSystemService>();
            container.Singleton<IFileSystemFactory, FileSystemFactory>();
            container.Singleton<IFileIconService, FileIconService>();

            // Register ViewModels
            container.Singleton<IShellViewModel, ShellViewModel>();
            container.Singleton<IMainViewModel, MainViewModel>();
            container.Singleton<IFileSystemStructureViewModel, FileSystemStructureViewModel>();
            container.Singleton<ViewModels.Interfaces.IFolderContentViewModel, ViewModels.FolderContentViewModel>();

            // FileSystem ViewModels
            container.PerRequest<IDriveViewModel, DriveViewModel>();
            container.PerRequest<ITreeViewFolder, TreeViewFolder>();

            container.PerRequest<IFileViewModel, FileViewModel>();
            container.PerRequest<IListViewFolder, ListViewFolder>();
        }

        protected override object GetInstance(Type service, string key) => container.GetInstance(service, key);

        protected override IEnumerable<object> GetAllInstances(Type serviceType) => container.GetAllInstances(serviceType);

        protected override void OnStartup(object sender, StartupEventArgs e) => DisplayRootViewFor<IShellViewModel>();
    }
}