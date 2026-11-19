using System.Linq;
using System.Windows;
using WpfApp1.Data;

namespace WpfApp1
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AppDbContext())
            {
                var userObj = db.Users.FirstOrDefault(u => u.Login == TxtLogin.Text && u.Password == TxtPassword.Password);

                if (userObj == null)
                {
                    MessageBox.Show("Неверный логин или пароль!");
                    return;
                }
                
                this.Hide();
                MainWindow main = new MainWindow(userObj);
                main.Show();
            }
        }

        private void BtnGuest_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow(null);
            main.Show();
        }
    }
}