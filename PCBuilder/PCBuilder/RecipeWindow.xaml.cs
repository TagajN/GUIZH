using Newtonsoft.Json;
using PCBuilder.Model;
using PCBuilder.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace PCBuilder
{
    /// <summary>
    /// Interaction logic for RecipeWindow.xaml
    /// </summary>
    public partial class RecipeWindow : Window
    {
        public RecipeWindow(IList<Part> part)
        {
            InitializeComponent();
            this.DataContext = new RecipeWindowViewModel();
            (this.DataContext as RecipeWindowViewModel).Setup(part);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var list = ls_box.Items.Cast<Part>().ToList();

            string jsonData = JsonConvert.SerializeObject(list);
            File.WriteAllText("Recipe.json", jsonData);
            
        }
    }
}
