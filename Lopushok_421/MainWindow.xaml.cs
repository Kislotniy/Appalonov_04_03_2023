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
using Lopushok_421.Model;

namespace Lopushok_421
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BProd_Click(object sender, RoutedEventArgs e)
        {
            Windows.ProductWindow product = new Windows.ProductWindow();
            this.Close();
            product.ShowDialog();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Это не сделал,Next :)");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Windows.MaterialsWindow materialsWindow = new Windows.MaterialsWindow();
            this.Close();
            materialsWindow.ShowDialog();
        }
    }
}
