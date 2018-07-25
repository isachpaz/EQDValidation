using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfEQDValidationApp.Infrastructure.Adapters;

namespace WpfEQDValidationApp.DoseModule.Views
{
    /// <summary>
    /// Interaction logic for DoseConfigurationView.xaml
    /// </summary>
    public partial class DoseConfigurationView : UserControl, IPanelInfo
    {
        public DoseConfigurationView()
        {
            InitializeComponent();
            ShowCloseButton = false;
        }

        public string GetPanelCaption()
        {
            return $"Dose configuration";
        }

        public bool ShowCloseButton { get; set; }
    }
}
