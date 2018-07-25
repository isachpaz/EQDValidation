using System.Collections.Specialized;
using System.ComponentModel.Composition;
using DevExpress.Xpf.Docking;
using Prism.Regions;

namespace WpfEQDValidationApp.Infrastructure.Adapters
{
    public class TabbedGroupAdapter : RegionAdapterBase<TabbedGroup>
    {
        [ImportingConstructor]
        public TabbedGroupAdapter(IRegionBehaviorFactory behaviorFactory) :
            base(behaviorFactory)
        {
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }

        protected override void Adapt(IRegion region, TabbedGroup regionTarget)
        {
            region.Views.CollectionChanged += (s, e) => { OnViewsCollectionChanged(region, regionTarget, s, e); };
        }

        private void OnViewsCollectionChanged(IRegion region, TabbedGroup regionTarget, object sender,
            NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var view in e.NewItems)
                {
                    var panel = new LayoutPanel();
                    panel.Content = view;
                    panel.Caption = "new Page";
                    regionTarget.Items.Add(panel);
                    regionTarget.SelectedTabIndex = regionTarget.Items.Count - 1;
                }
            }
        }
    }
}