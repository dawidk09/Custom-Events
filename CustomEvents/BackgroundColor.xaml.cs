using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace Events
{
    /// <summary>
    /// Interaction logic for KolorTla.xaml
    /// </summary>
    public partial class BackgroundColor : Window
    {
        public BackgroundColor()
        {
            InitializeComponent();

        }

        public event EventHandler ColorChanged;
        public SolidColorBrush MyColor { get; set; }

        public void Change()
        {  
            OnColorChanged(EventArgs.Empty);
        }

        protected virtual void OnColorChanged(EventArgs e)
        {
            ColorChanged?.Invoke(this, e);
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            MyColor = Brushes.Red;  
            Change();
        }

        private void Green_Click(object sender, RoutedEventArgs e)
        {
            MyColor = Brushes.Green;
            Change();
        }

        private void Blue_Click(object sender, RoutedEventArgs e)
        {
            MyColor = Brushes.Blue;
            Change();
        }

        private void Yellow_Click(object sender, RoutedEventArgs e)
        {
            MyColor = Brushes.Yellow;
            Change();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }

    }

}
