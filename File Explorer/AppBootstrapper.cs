namespace FileExplorer
{
    using System;
    using System.Collections.Generic;
    using System.Windows;

    using Caliburn.Micro;

    using FileExplorer.ViewModels;
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

            // Register ViewModels
            container.Singleton<IShellViewModel, ShellViewModel>();
            container.Singleton<IMainViewModel, MainViewModel>();
        }

        protected override object GetInstance(Type service, string key) => container.GetInstance(service, key);

        protected override IEnumerable<object> GetAllInstances(Type serviceType) => container.GetAllInstances(serviceType);

        protected override void OnStartup(object sender, StartupEventArgs e) => DisplayRootViewFor<IShellViewModel>();
    }
}