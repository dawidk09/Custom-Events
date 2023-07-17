using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Events
{
    /// <summary>
    /// Interaction logic for Suwak.xaml
    /// </summary>
    public partial class Slider : Window
    {
        public Slider()
        {
            InitializeComponent();
        }

        public event EventHandler MyTextChanged;
        public int MyNumber { get; set; }

        protected virtual void OnMyTextChanged(EventArgs e)
        {
            MyTextChanged?.Invoke(this, e);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {    
            yourNumber.Text = slider.Value.ToString();
            numberInput.Text = slider.Value.ToString();
            MyNumber = int.Parse(yourNumber.Text);
            OnMyTextChanged(EventArgs.Empty);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }

        private void tb_number_TextChanged(object sender, TextChangedEventArgs e)
        {
            yourNumber.Text = numberInput.Text;

            if (!string.IsNullOrEmpty(yourNumber.Text))
            {
                MyNumber = int.Parse(yourNumber.Text);
            }
            OnMyTextChanged(EventArgs.Empty);
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
