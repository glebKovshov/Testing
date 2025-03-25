using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        private readonly bool _isTestMode;
        public Registration() : this(false) { }

        public Registration(bool isTestMode)
        {
            InitializeComponent();
            _isTestMode = isTestMode;
        }

        public bool SignUp(string username, string email, string password1, string password2)
        {
            if (string.IsNullOrEmpty(username))
            {
                if (!_isTestMode) MessageBox.Show("Введите логин");
                return false;
            }
            using (var db = new Entities())
            {
                var user = db.Users.AsNoTracking().FirstOrDefault(u => u.username == username);
                if (user != null)
                {
                    if (!_isTestMode)  MessageBox.Show("Пользователь с таким логином уже создан");
                    UsernameTextBox.Text = "";
                    return false;
                }
            }
            string pattern = @"^\S+@\S+\.\S+$";
            if (!Regex.IsMatch(email, pattern))
            {
                if (!_isTestMode)  MessageBox.Show("Неверно введен email");
                EmailTextBox.Text = "";
                return false;
            }

            if (string.IsNullOrEmpty(password1) || string.IsNullOrEmpty(password2)) {
                if (!_isTestMode)  MessageBox.Show("Не все поля паролей заполнены");
                return false;
            }

            pattern = @"[\u0400-\u04FF]";
            if (Regex.IsMatch(password1, pattern) || Regex.IsMatch(password2, pattern))
            {
                if (!_isTestMode)  MessageBox.Show("Пароль не должен содержать кириллицу");
                PassWordTextBoxFirst.Password = "";
                PassWordTextBoxSecond.Password = "";
                return false;
            }
            
            if (password1 != password2)
            {
                if (!_isTestMode) MessageBox.Show("Пароль не совпадают");
                PassWordTextBoxFirst.Password = "";
                PassWordTextBoxSecond.Password = "";
                return false;
            }

            using (var db = new Entities())
            {
                Users newUser = new Users
                {
                    username = username,
                    email = email,
                    password = GetHashCode(password2),
                    profile_picture = "Default",
                    bio = "",
                    created_at = DateTime.Now,
                };
                db.Users.Add(newUser);
                db.SaveChanges();
                if (!_isTestMode)
                {
                    MessageBox.Show("Вы успешно зарегистрированы", "Успешно", MessageBoxButton.OK);
                    NavigationService.Navigate(new Authorization());
                }
                return true;
            }
        }
        private string GetHashCode(string password)
        {
            using (var hash = SHA256.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("X2")));
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Entry_Click(object sender, RoutedEventArgs e)
        {
            SignUp(UsernameTextBox.Text, EmailTextBox.Text, PassWordTextBoxFirst.Password, PassWordTextBoxSecond.Password);
        }
    }
}
