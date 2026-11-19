using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Data;
using WpfApp1.Models;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private User _currentUser;

        public MainWindow(User user)
        {
            InitializeComponent();
            _currentUser = user;
            ConfigureUIForRole();
            LoadData();
        }

        private void ApplyFilters()
        {
            if (LvProducts == null) return;
            if (FilterPanel.Visibility == Visibility.Collapsed) return;

            using (var db = new AppDbContext())
            {
                var query = db.Products.AsQueryable();

                if (!string.IsNullOrWhiteSpace(TxtSearch.Text))
                {
                    string search = TxtSearch.Text.Trim();
                    query = query.Where(p => (p.Name != null && p.Name.Contains(search)) ||
                                             (p.Article != null && p.Article.Contains(search)));
                }

                var resultList = query.ToList();

                if (CmbSort.SelectedIndex == 1)
                    resultList = resultList.OrderBy(p => p.FinalPrice).ToList();
                else if (CmbSort.SelectedIndex == 2)
                    resultList = resultList.OrderByDescending(p => p.FinalPrice).ToList();

                LvProducts.ItemsSource = resultList;
            }
        }

        private void ConfigureUIForRole()
        {
            if (_currentUser == null || _currentUser.Role == "Авторизированный клиент")
            {
                FilterPanel.Visibility = Visibility.Collapsed;
                AdminPanel.Visibility = Visibility.Collapsed;
                MainTabControl.Items.Remove(TabOrders);
            }
            else if (_currentUser.Role == "Менеджер")
            {
                AdminPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void LoadData()
        {
            using (var db = new AppDbContext())
            {
                LvProducts.ItemsSource = db.Products.ToList();

                if (_currentUser != null && (_currentUser.Role == "Администратор" || _currentUser.Role == "Менеджер"))
                {
                    LvOrders.ItemsSource = db.Orders.ToList();
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e) => ApplyFilters();
        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e) => ApplyFilters();

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ProductEditWindow editWindow = new ProductEditWindow(null);
            if (editWindow.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = LvProducts.SelectedItem as Product;
            if (selectedProduct != null)
            {
                ProductEditWindow editWindow = new ProductEditWindow(selectedProduct);
                if (editWindow.ShowDialog() == true)
                {
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Выберите товар!");
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var peremen_delete = LvProducts.SelectedItem as Product;

            if (peremen_delete != null)
            {
                if (MessageBox.Show("Удалить товар?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    using (var db = new AppDbContext())
                    {
                        var toDelete = db.Products.FirstOrDefault(p => p.Id == peremen_delete.Id);
                        if (toDelete != null)
                        {
                            db.Products.Remove(toDelete);
                            db.SaveChanges();
                        }

                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления!");
            }
        }
    }
}
