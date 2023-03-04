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
using Lopushok_421.Model;

namespace Lopushok_421.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        public ProductWindow()
        {
            InitializeComponent();
            ListProduct.ItemsSource = null;
            ListProduct.ItemsSource = Connection.con.Products.ToList();
            InitializeComponent();
            RefreshComboBox();
            UpdateTovar();
            RefreshFilter();
        }
        public static Model.Lopushok_DBEntities db = new Model.Lopushok_DBEntities();
        public List<Model.Products> products = new List<Model.Products>();

       
        private void CBNumberWrite_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pageSize = Convert.ToInt32(CBNumberWrite.SelectedItem.ToString());
            RefreshPagination();
        }
        private void BLeft_Click(object sender, RoutedEventArgs e)
        {
            if (pageNumber == 0)
                return;
            pageNumber--;
            RefreshPagination();
        }

        private void BRight_Click(object sender, RoutedEventArgs e)
        {
            if (users.Count % pageSize == 0)
            {
                if (pageNumber == (users.Count / pageSize) - 1)
                    return;
            }
            else
            {

                if (pageNumber == (users.Count / pageSize))
                    return;
            }
            pageNumber++;
            RefreshPagination();
        }

        int pageSize;
        int pageNumber;
        List<Model.Products> users = Connection.con.Products.ToList();

        private void RefreshPagination()
        {
            ListProduct.ItemsSource = null;
            ListProduct.ItemsSource = users.Skip(pageNumber * pageSize).Take(pageSize).ToList();
        }

        private void RefreshComboBox()
        {
            CBNumberWrite.Items.Add("10");
            SortCB.Items.Add("Меньше чем 5000");
            SortCB.Items.Add("Больше чем 5000");
            SortCB.Items.Add("По типу");
        }
        private void RefreshFilter()
        {
            foreach (var item in db.Products)
                FilterCB.Items.Add(item.MinPriceForAgent);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            pageNumber = Convert.ToInt32(button.Content) - 1;
            RefreshPagination();
        }
        private void Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTovar();
        }
        private void UpdateTovar()
        {
            var currentKeyboard = Connection.con.Products.ToList();

            currentKeyboard = currentKeyboard.Where(p => p.Name_Product.ToLower().Contains(Poisk.Text.ToLower())).ToList();

            ListProduct.ItemsSource = null;
            ListProduct.ItemsSource = currentKeyboard.ToList();

        }
        private void Mouse_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Connection.con.ChangeTracker.Entries().ToList().ForEach(a => a.Reload());
                ListProduct.ItemsSource = Connection.con.Products.ToList();
            }
        }
        private void Red_Click(object sender, RoutedEventArgs e)
        {
            //AddAgent page = new AddAgent((sender as Button).DataContext as products);
            //page.Show();
            //this.Close();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortCB.SelectedIndex == 0)
            {
                ListProduct.ItemsSource = null;
                ListProduct.ItemsSource = Connection.con.Products.OrderBy(z => z.MinPriceForAgent > 5000).ToList();
            }
            if (SortCB.SelectedIndex == 1)
            {
                ListProduct.ItemsSource = null;
                ListProduct.ItemsSource = Connection.con.Products.OrderBy(z => z.MinPriceForAgent < 5000).ToList();
            }
            if (SortCB.SelectedIndex == 2)
            {
                ListProduct.ItemsSource = null;
                ListProduct.ItemsSource = Connection.con.Products.OrderBy(z => z.Name_Product).ToList();
            }
        }

        private void FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = (ComboBox)sender;
            string item = Convert.ToString(combobox.SelectedItem);
            if (item == "Меньше чем 1000")
            {
                ListProduct.ItemsSource = users;
                return;
                var agents = db.Products.Where(z => z.MinPriceForAgent <= 5000).ToList();
                ListProduct.ItemsSource = agents;
            }
            else
            {
                var agents = db.Products.Where(z => z.MinPriceForAgent > 5000).ToList();
                ListProduct.ItemsSource = agents;
            }

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var listik = ListProduct.SelectedItem as Model.Products;

            var eto = Connection.con.Products.Where(z => z.id_Product == listik.id_Product).FirstOrDefault();

            var drugoe = Connection.con.Products_Material.Where(z => z.id_Product == listik.id_Product).FirstOrDefault();

            var inoe = Connection.con.Application.Where(z => z.id_Product == listik.id_Product).FirstOrDefault();

            if (inoe != null)
            {
                Connection.con.Application.Remove(inoe);
            }

            Connection.con.Products_Material.Remove(drugoe);
            Connection.con.Products.Remove(eto);
            Connection.con.Products.Remove(listik);
            
            
           
            Connection.con.SaveChanges();
            MessageBox.Show("Removed");
            ListProduct.ItemsSource = Connection.con.Products.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DeleteBtn_Copy_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}

