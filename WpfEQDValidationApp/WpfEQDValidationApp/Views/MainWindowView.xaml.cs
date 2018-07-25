using DevExpress.Xpf.Ribbon;
using WpfEQDValidationApp.ViewModels;

namespace WpfEQDValidationApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : DXRibbonWindow
    {
        public MainWindowView(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            MainWindowViewModel = mainWindowViewModel;
            DataContext = MainWindowViewModel;
        }

        public MainWindowViewModel MainWindowViewModel { get; }
    }
}
