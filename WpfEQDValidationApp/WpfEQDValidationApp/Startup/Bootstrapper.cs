using System.Windows;
using DevExpress.Xpf.Docking;
using Microsoft.Practices.Unity;
using Prism.Logging;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using WpfEQDValidationApp.DataServices;
using WpfEQDValidationApp.Infrastructure.Adapters;
using WpfEQDValidationApp.Views;

namespace WpfEQDValidationApp.Startup
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IApplicationDataService, ApplicationDataService>(new ContainerControlledLifetimeManager());

        }

        protected override ILoggerFacade CreateLogger()
        {
            return new LogService();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            ModuleCatalog catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(DoseModule.DoseModule));
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var mappings = base.ConfigureRegionAdapterMappings();
            if (mappings != null)
            {
                mappings.RegisterMapping(typeof(LayoutPanel), Container.Resolve<LayoutPanelAdapter>());
                mappings.RegisterMapping(typeof(LayoutGroup), Container.Resolve<LayoutGroupAdapter>());
                mappings.RegisterMapping(typeof(DocumentGroup), Container.Resolve<DocumentGroupAdapter>());
                mappings.RegisterMapping(typeof(TabbedGroup), Container.Resolve<TabbedGroupAdapter>());
            }
            return mappings;
        }

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindowView>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow = Shell as Window;
            if (Application.Current.MainWindow != null) Application.Current.MainWindow.Show();
        }
    }

}