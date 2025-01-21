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
            // Превращает текст из полей в числа. Значение сток сокраняется в переменные x и y
            if (!double.TryParse(input_x.Text, out double x) || !double.TryParse(input_y.Text, out double y))
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения для x и m.", "Ошибка ввода");
                return;
            }
            // Сохраняет результат выполения функции в переменную result
            double result = CalculateFunction(x, y);
            // Преобразует число в строку
            result_tb.Text = result.ToString();
        }
        // Короч, это сам прмер. Вооооооть
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
                return 0; // Или как обработать некорректные условия
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
                return x => 0; // По умолчанию
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

//Необходимо реализвать функцию расчета, организовать проверку на пустоту, выводить ошибку в случае заполнения не числовыми значениями или если ничем не заполнено.