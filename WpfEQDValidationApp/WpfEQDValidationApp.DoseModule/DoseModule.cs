using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;
using WpfEQDValidationApp.DoseModule.Views;
using WpfEQDValidationApp.Infrastructure;

namespace WpfEQDValidationApp.DoseModule
{
    public class DoseModule : IModule
    {
        public DoseModule(IEventAggregator eventAggregator, 
                            IRegionManager regionManager)
        {
            EventAggregator = eventAggregator;
            RegionManager = regionManager;
        }

        public IEventAggregator EventAggregator { get; }
        public IRegionManager RegionManager { get; }

        public void Initialize()
        {
            if (RegionManager.Regions.Any())
            {
                RegionManager.RegisterViewWithRegion(RegionNames.LeftRegion, typeof(DoseConfigurationView));
            }
        }
    }
}
