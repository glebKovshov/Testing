using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace SocialNetwork.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        private readonly bool _isTestMode;

        public Authorization() : this(false) {
        }

        public Authorization(bool isTestMode)
        {
            InitializeComponent();
            _isTestMode = isTestMode;
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Entry_Click(sender, e);
            }
        }

        public bool SignIn(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                if (!_isTestMode)  MessageBox.Show("Введите логин и пароль");
                return false;
            }

            password = GetHashCode(password);

            using (var db = new Entities())
            {
                var user = db.Users.FirstOrDefault(u => u.username == login && u.password == password);

                if (user == null)
                {
                    if (!_isTestMode) MessageBox.Show("Неверный логин или пароль");
                    return false;
                }

                user.last_login = DateTime.Now;
                db.SaveChanges();
                if (!_isTestMode) MessageBox.Show("Успешная авторизация");
                
            }
            if (!_isTestMode) NavigationService.Navigate(new Main());
            return true;
        }

        private string GetHashCode(string password)
        {
            using (var hash = SHA256.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("X2")));
            }
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }

        private void Entry_Click(object sender, RoutedEventArgs e)
        {
            SignIn(Login.Text, Password.Password);
        }
    }
}
