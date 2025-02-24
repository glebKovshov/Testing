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

namespace PR3._2
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

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Sum.Text) || !double.TryParse(Sum.Text, out double sum)) { 
                MessageBox.Show("Поле Сумма указано некорректно");
                return;
            }

            if (string.IsNullOrEmpty(Term.Text) || !int.TryParse(Term.Text, out int term))
            {
                MessageBox.Show("Поле Срок указано некорректно");
                return;
            }

            if (string.IsNullOrEmpty(Rate.Text) || !int.TryParse(Rate.Text, out int rate))
            {
                MessageBox.Show("Поле Процентная ставка указано некорректно");
                return;
            }

            if ((bool)Simple.IsChecked)
            {
                double result = (double)rate/100 * sum + sum;
                Result.Content = $"Доход по вкладу = {Math.Round(result-sum), 2}";
                return;
            }

            if ((bool)Compound.IsChecked)
            {
                double result = sum;
                for (int i = 0; i<term; i++)
                {
                    result += (double)rate / 100 * result;
                }

                Result.Content = $"Доход по вкладу = {Math.Round(result-sum), 2}";
                return;
            }

            MessageBox.Show("Не выбрана Схема начисления %");


        }
    }
}
