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

namespace PR1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private delegate double func(double x);

        double hyperbolic_sine(double x)
        {
            return Math.Sinh(x);
        }

        double porab(double x)
        {
            return x * x;
        }

        double exp(double x)
        {
            return Math.Exp(x);
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Execute(object sender, RoutedEventArgs e)
        {
            if (!(bool)sh.IsChecked && !(bool)porabola.IsChecked && !(bool)exponent.IsChecked) return;
            if (x.Text == "" || i.Text == "") return;

            func selectedFunc;

            if ((bool)sh.IsChecked) selectedFunc = hyperbolic_sine;
            else if ((bool)porabola.IsChecked) selectedFunc = porab;
            else selectedFunc = exp;

            if (double.TryParse(x.Text, out double x_var) && double.TryParse(i.Text, out double i_var)) {
                if (i_var % 2 != 0 && x_var > 0)
                {
                    result.Text = Convert.ToString(i_var * Math.Sqrt(selectedFunc(x_var)));
                }
                else if (i_var % 2 == 0 && x_var < 0)
                {
                    result.Text = Convert.ToString(i_var / 2 * Math.Sqrt(Math.Abs(selectedFunc(x_var))));
                }
                else result.Text = Convert.ToString(Math.Sqrt(Math.Abs(i_var * selectedFunc(x_var))));
            }
            else MessageBox.Show("Неверный ввод");

        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            x.Text = "";
            i.Text = "";
            result.Text = "";
            if ((bool)sh.IsChecked) sh.IsChecked = false;
            if ((bool)porabola.IsChecked) porabola.IsChecked = false;
            if ((bool)exponent.IsChecked) exponent.IsChecked = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите закрыть окно?", "Подтвердите закрытие", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
