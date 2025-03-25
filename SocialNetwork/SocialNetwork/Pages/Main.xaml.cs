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

namespace SocialNetwork.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Friends_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FriendsPage());
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UsersPage());
        }

        private void Posts_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PostsPage());
        }

        private void Comments_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CommentsPage());
        }

        private void Messages_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MessagesPage());
        }
    }
}
