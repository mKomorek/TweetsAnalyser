using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;


namespace TweetsAnalyser
{
    /// <summary>
    /// This class introduces simple logic for the main window in the app.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initalizes the window (forces it to appear on the screen)
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Wires up the close button. If its clicked -> the app will quit.
        /// </summary>
        private void Close_app_button(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Sets the GotFocus event of the SearchTextBox.
        /// <see cref="SearchTextBox"/>
        /// </summary>
        void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Text = string.Empty;
            box.Foreground = Brushes.Black;
            box.GotFocus -= TextBox_GotFocus;
        }

        /// <summary>
        /// Sets the LostFocus event of the SearchTextBox.
        /// <see cref="SearchTextBox"/>
        /// </summary>
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

        /// <summary>
        /// Sets the MouseDown event of the main window.
        /// </summary>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            grid.Focus();
        }
    }
}
