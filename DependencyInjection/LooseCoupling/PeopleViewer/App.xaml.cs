using Autofac;
using Common;
using PersonReader.Service;
using PersonReader.Caching;
using System.Windows;

namespace PeopleViewer
{
    public partial class App : Application
    {
        IContainer Container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Application.Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ServiceReader>().Named<IPersonReader>("reader").SingleInstance();
            builder.RegisterDecorator<IPersonReader>((c, inner) => new CachingReader(inner), fromKey: "reader");
            
            builder.RegisterType<MainWindow>().InstancePerDependency();
            builder.RegisterType<PeopleViewModel>().InstancePerDependency();

            Container = builder.Build();
        }

        private void ComposeObjects()
        {
            Application.Current.MainWindow = Container.Resolve<MainWindow>();
        }

        #region Without DI Container

        //private void ConfigureContainer()
        //{
        //}

        //private static void ComposeObjects()
        //{
        //    var wrappedReader = new ServiceReader();
        //    var reader = new CachingReader(wrappedReader);
        //    var viewModel = new PeopleViewModel(reader);
        //    Current.MainWindow = new MainWindow(viewModel);
        //}

        #endregion
    }
}
