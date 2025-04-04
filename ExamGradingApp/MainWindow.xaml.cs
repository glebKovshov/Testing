using System;
using System.Windows;

namespace ExamGradingApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int module1 = int.Parse(txtModule1.Text);
                int module2 = int.Parse(txtModule2.Text);
                int module3 = int.Parse(txtModule3.Text);

                lblGrade.Text = $"Оценка: {Calculate(module1, module2, module3)}";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка ввода: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public string Calculate(int module1, int module2, int module3)
        {
            if (module1 < 0 || module1 > 22) return "None";
            if (module2 < 0 || module2 > 38) return "None";
            if (module3 < 0 || module3 > 20) return "None";

            int total = module1 + module2 + module3;

            lblTotal.Text = $"Общая сумма баллов: {total}";

            string grade = GetGrade(total);
            return grade;

        }

        public string GetGrade(int total)
        {
            if (total >= 56) return "5 (отлично)";
            if (total >= 32) return "4 (хорошо)";
            if (total >= 16) return "3 (удовлетворительно)";
            return "2 (неудовлетворительно)";
        }
    }
}
