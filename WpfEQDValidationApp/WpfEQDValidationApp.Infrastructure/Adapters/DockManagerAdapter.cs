using System.ComponentModel.Composition;
using System.Windows.Controls;
using DevExpress.Xpf.Docking;
using Prism.Regions;

namespace WpfEQDValidationApp.Infrastructure.Adapters
{
    public class DockManagerAdapter : RegionAdapterBase<DockLayoutManager>
    {
        [ImportingConstructor]
        public DockManagerAdapter(IRegionBehaviorFactory behaviorFactory) :
            base(behaviorFactory)
        {
        }

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }

        protected override void Adapt(IRegion region, DockLayoutManager regionTarget)
        {
            var items = regionTarget.GetItems();
            foreach (var item in items)
            {
                var regionName = RegionManager.GetRegionName(item);
                if (!string.IsNullOrEmpty(regionName))
                {
                    var panel = item as LayoutPanel;
                    if (panel != null && panel.Content == null)
                    {
                        var control = new ContentControl();
                        RegionManager.SetRegionName(control, regionName);
                        panel.Content = control;
                    }
                }
            }
        }
    }
}