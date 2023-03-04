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
    /// Логика взаимодействия для MaterialsWindow.xaml
    /// </summary>
    public partial class MaterialsWindow : Window
    {
        public MaterialsWindow()
        {
            InitializeComponent();
            ListProduct.ItemsSource = null;
            ListProduct.ItemsSource = Connection.con.Materials.ToList();
            InitializeComponent();
            RefreshComboBox();
            UpdateTovar();
            RefreshFilter();
        }
        
        public static Model.Lopushok_DBEntities db = new Model.Lopushok_DBEntities();
        public List<Model.Materials> products = new List<Model.Materials>();


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
        List<Model.Materials> users = Connection.con.Materials.ToList();

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
            var currentKeyboard = Connection.con.Materials.ToList();

            currentKeyboard = currentKeyboard.Where(p => p.Name_Material.ToLower().Contains(Poisk.Text.ToLower())).ToList();

            ListProduct.ItemsSource = null;
            ListProduct.ItemsSource = currentKeyboard.ToList();

        }
        private void Mouse_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Connection.con.ChangeTracker.Entries().ToList().ForEach(a => a.Reload());
                ListProduct.ItemsSource = Connection.con.Materials.ToList();
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
                ListProduct.ItemsSource = Connection.con.Materials.OrderBy(z => z.QuantityInStorage > 500).ToList();
            }
            if (SortCB.SelectedIndex == 1)
            {
                ListProduct.ItemsSource = null;
                ListProduct.ItemsSource = Connection.con.Materials.OrderBy(z => z.QuantityInStorage < 500).ToList();
            }
            if (SortCB.SelectedIndex == 2)
            {
                ListProduct.ItemsSource = null;
                ListProduct.ItemsSource = Connection.con.Materials.OrderBy(z => z.Name_Material).ToList();
            }
        }

        private void FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = (ComboBox)sender;
            string item = Convert.ToString(combobox.SelectedItem);
            if (item == "Меньше чем 500")
            {
                ListProduct.ItemsSource = users;
                return;
                var agents = db.Materials.Where(z => z.QuantityInStorage <= 500).ToList();
                ListProduct.ItemsSource = agents;
            }
            else
            {
                var agents = db.Materials.Where(z => z.QuantityInStorage> 500).ToList();
                ListProduct.ItemsSource = agents;
            }

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var listik = ListProduct.SelectedItem as Model.Materials;
       
            
            if (listik != null)
            {
                Connection.con.Materials.Remove(listik);
            }

            Connection.con.SaveChanges();
            MessageBox.Show("Removed");
            ListProduct.ItemsSource = Connection.con.Materials.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Copy_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
