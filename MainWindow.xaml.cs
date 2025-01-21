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