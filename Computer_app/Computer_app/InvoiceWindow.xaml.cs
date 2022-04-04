using Computer_app.Models;
using Computer_app.ViewModels;
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
using System.Windows.Shapes;

namespace Computer_app
{
    /// <summary>
    /// Interaction logic for InvoiceWindow.xaml
    /// </summary>
    public partial class InvoiceWindow : Window
    {
        public InvoiceWindow(IList<ComponentAsset> componentAssets)
        {
            InitializeComponent();
            this.DataContext = new InvoiceWindowViewModel();
            (this.DataContext as InvoiceWindowViewModel).Setup(componentAssets);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var Actual = ls_box.Items.Cast<ComponentAsset>().ToList();
        }
    }
}
