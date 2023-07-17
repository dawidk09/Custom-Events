using System;
using System.Windows;
using System.Windows.Controls;

namespace Events
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            backgroundColor.ColorChanged += MyColorChanged;
            slider1.MyTextChanged += MyTextChanged;
            slider2.MyTextChanged += MyTextChanged2;

        }

        readonly BackgroundColor backgroundColor = new BackgroundColor();
        readonly Slider slider1 = new Slider();
        readonly Slider slider2 = new Slider();


        void MyColorChanged(object sender, EventArgs e)
        {
            this.Background = ((BackgroundColor)sender).MyColor;
        }
        void MyTextChanged(object sender, EventArgs e)
        {
            this.number1_Input.Text = ((Slider)sender).MyNumber.ToString();
        }

        void MyTextChanged2(object sender, EventArgs e)
        {
            this.number2_Input.Text = ((Slider)sender).MyNumber.ToString();
        }

        private void ChangeColor_Click(object sender, RoutedEventArgs e)
        {
            backgroundColor.Show();
        }

        private void PickNumber1_Click(object sender, RoutedEventArgs e)
        {
            slider1.Show();

            if (!string.IsNullOrEmpty(number1_Input.Text))
            {
                slider1.slider.Value = int.Parse(number1_Input.Text);
            }
        }

        private void PickNumber2_Click(object sender, RoutedEventArgs e)
        {
            slider2.Show();

            if (!string.IsNullOrEmpty(number2_Input.Text))
            {
                slider2.slider.Value = int.Parse(number2_Input.Text);
            }

        }

        private void PerformOperation(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            if (!string.IsNullOrWhiteSpace(number1_Input.Text) && !string.IsNullOrWhiteSpace(number2_Input.Text))
            {
                int number1 = int.Parse(number1_Input.Text);
                int number2 = int.Parse(number2_Input.Text);
                int resultValue = 0;

                switch (clickedButton.Name)
                {
                    case "sum":
                        resultValue = number1 + number2;
                        break;
                    case "subtract":
                        resultValue = number1 - number2;
                        break;
                    case "multiply":
                        resultValue = number1 * number2;
                        break;
                    case "divide":
                        if (number2 != 0)
                            resultValue = number1 / number2;
                        else
                        {
                            result.Text = "Cannot divide by zero";
                            return;
                        }
                        break;
                    default:
                        result.Text = "Invalid operation";
                        return;
                }

                result.Text = resultValue.ToString();
            }
            else
                result.Text = "Invalid input";
        }
    }
}
