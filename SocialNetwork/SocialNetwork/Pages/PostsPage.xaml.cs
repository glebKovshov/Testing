﻿using System;
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
    /// Логика взаимодействия для PostsPage.xaml
    /// </summary>
    public partial class PostsPage : Page
    {
        public PostsPage()
        {
            InitializeComponent();
            DataGridPosts.ItemsSource = Entities.GetContext().Posts.ToList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CommentsPage());
        }
    }
}
