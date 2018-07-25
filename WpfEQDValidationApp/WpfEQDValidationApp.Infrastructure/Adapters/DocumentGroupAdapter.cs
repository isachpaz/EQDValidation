using System.Collections.Specialized;
using System.ComponentModel.Composition;
using DevExpress.Xpf.Docking;
using Prism.Regions;

namespace WpfEQDValidationApp.Infrastructure.Adapters
{
    public class DocumentGroupAdapter : RegionAdapterBase<DocumentGroup>
    {
        [ImportingConstructor]
        public DocumentGroupAdapter(IRegionBehaviorFactory behaviorFactory) :
            base(behaviorFactory)
        {
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }

        protected override void Adapt(IRegion region, DocumentGroup regionTarget)
        {
            region.Views.CollectionChanged += (s, e) => { OnViewsCollectionChanged(region, regionTarget, s, e); };
        }

        private void OnViewsCollectionChanged(IRegion region, DocumentGroup regionTarget, object sender,
            NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var view in e.NewItems)
                {
                    var manager = regionTarget.GetDockLayoutManager();
                    var panel = manager.DockController.AddDocumentPanel(regionTarget);
                    panel.Content = view;
                    if (view is IPanelInfo)
                    {
                        panel.Caption = ((IPanelInfo)view).GetPanelCaption();
                        panel.ShowCloseButton = ((IPanelInfo)view).ShowCloseButton;
                    }
                    else panel.Caption = "new Page";
                    manager.DockController.Activate(panel);
                }
            }
        }
    }
}