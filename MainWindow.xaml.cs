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
using System.Windows.Threading;

namespace SimpleCalculator
{
    public partial class MainWindow : Window
    {
        private double _firstNumber = 0;
        private string _operator = "";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            if (button != null)
            {
                if (txtDisplay.Text == "0")
                {
                    txtDisplay.Text = button.Content.ToString();
                }
                else
                {
                    txtDisplay.Text += button.Content.ToString();
                }

            }
        }
        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            if (button != null)
            {
                if (txtDisplay.Text != "")
                {
                    _firstNumber = double.Parse(txtDisplay.Text);
                    _operator = button.Content.ToString();
                    txtDisplay.Text += $" {_operator} ";
                }
            }
        }
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            var parts = txtDisplay.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 3)
            {
                _firstNumber = double.Parse(parts[0]);
                _operator = parts[1];
                double secondNumber = double.Parse(parts[2]);
                double result = 0;

                switch (_operator)
                {
                    case "+":
                        result = _firstNumber + secondNumber;
                        break;
                    case "-":
                        result = _firstNumber - secondNumber;
                        break;
                    case "*":
                        result = _firstNumber * secondNumber;
                        break;
                    case "/":
                        result = _firstNumber / secondNumber;
                        break;
                }
                txtDisplay.Text = result.ToString();
            }
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "0";
            _firstNumber = 0;
            _operator = "";
        }
    }
}