using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace _522_Yatsuk_Katan
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Плейсхолдер текста
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string placeholderText = textBox.Tag as string;
            if (textBox.Text == placeholderText)
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string placeholderText = textBox.Tag as string;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholderText;
                textBox.Foreground = Brushes.Gray;
            }
        }
        //---
        
        //Реализация функции расчета
        private void calc_btn_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(input_x.Text, out double x) || !double.TryParse(input_y.Text, out double y))
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения для x и y.", "Ошибка ввода");
                return;
            }
            if (func_1.IsChecked == false& func_2.IsChecked == false& func_3.IsChecked == false)
            {
                MessageBox.Show("Выберите функцию.", "Ошибка ввода");
                return;
            }

                
            double result = CalculateFunction(x, y);
            result_tb.Text = result.ToString();
        }
        private double CalculateFunction(double x, double y)
        {
            Func<double, double> f = GetSelectedFunction();

            if (x - y == 0)
            {
                return Math.Pow(f(x), 2) + Math.Pow(y, 2) + Math.Sin(y);
            }
            else if (x - y > 0)
            {
                return Math.Pow(f(x) - y, 2) + Math.Cos(y);
            }
            else if (x - y < 0)
            {
                return Math.Pow(y - f(x), 2) + Math.Tan(y);
            }
            else
            {
                return 0; 
            }
        }
        private Func<double, double> GetSelectedFunction()
        {
            if (func_1.IsChecked == true)
                return x => Math.Sinh(x);
            else if (func_2.IsChecked == true)
                return x => Math.Pow(x, 2);
            else if (func_3.IsChecked == true)
                return x => Math.Exp(x);
            else
                return x => 0; 
        }

        //---

        //Реализация функции удаления
        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {
            input_x.Text = "Введите значение x";
            input_x.Foreground = Brushes.Gray;
            input_y.Text = "Введите значение y";
            input_y.Foreground = Brushes.Gray;
            result_tb.Text = "Результат";
            result_tb.Foreground = Brushes.Gray;
            func_1.IsChecked = false;
            func_2.IsChecked = false;
            func_3.IsChecked = false;
        }
        //---

    }
}


