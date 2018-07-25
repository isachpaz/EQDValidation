using System;
using System.Windows.Input;
using DevExpress.Mvvm;
using Prism.Common;
using Prism.Events;
using Prism.Logging;
using WpfEQDValidationApp.DataServices;


namespace WpfEQDValidationApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel(IEventAggregator aggregator,
                                    ILoggerFacade logger, 
                                    IApplicationDataService applicationDataService)
        {
            Aggregator = aggregator;
            Logger = logger;
            ApplicationDataService = applicationDataService;
            Initialize();
        }

        private void Initialize()
        {
            ApplicationTitle = new ObservableObject<string>();
            ApplicationTitle.Value = ApplicationDataService.ApplicationTitle;
            NewCommand = new DelegateCommand(NewCommandExecution);
        }

        private void NewCommandExecution()
        {
            
        }

        public IEventAggregator Aggregator { get; }
        public ILoggerFacade Logger { get; }
        public IApplicationDataService ApplicationDataService { get; }
        public ObservableObject<string> ApplicationTitle { get; set; }
        public ICommand NewCommand { get; set; }

    }
}