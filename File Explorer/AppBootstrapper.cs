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
    using FileExplorer.ViewModels.FileSystem;
    using FileExplorer.ViewModels.FileSystem.Interfaces;
    using FileExplorer.ViewModels.Interfaces;

    internal class AppBootstrapper : BootstrapperBase
    {
        private readonly SimpleContainer container = new SimpleContainer();

        internal AppBootstrapper() => Initialize();

        protected override void BuildUp(object instance) => container.BuildUp(instance);

        protected override void Configure()
        {
            // Register Services
            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IFileSystemService, FileSystemService>();
            container.Singleton<IFolderFactory, FolderFactory>();

            // Register ViewModels
            container.Singleton<IShellViewModel, ShellViewModel>();
            container.Singleton<IMainViewModel, MainViewModel>();
            container.Singleton<IFolderStructureViewModel, FolderStructureViewModel>();

            // FileSystem ViewModels
            container.PerRequest<IDriveViewModel, DriveViewModel>();
            container.PerRequest<IFolderViewModel, FolderViewModel>();
        }

        protected override object GetInstance(Type service, string key) => container.GetInstance(service, key);

        protected override IEnumerable<object> GetAllInstances(Type serviceType) => container.GetAllInstances(serviceType);

        protected override void OnStartup(object sender, StartupEventArgs e) => DisplayRootViewFor<IShellViewModel>();
    }
}