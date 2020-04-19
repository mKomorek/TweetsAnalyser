using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;


namespace TweetsAnalyser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Close_app_button(object sender, RoutedEventArgs e)
        {
            Close();
        }
        void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Text = string.Empty;
            box.Foreground = Brushes.Black;
            box.GotFocus -= TextBox_GotFocus;
        }

        public void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = "e.g. StackOverflow";
                box.Foreground = Brushes.LightGray;
                box.GotFocus += TextBox_GotFocus;
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            grid.Focus();
        }
    }
}
