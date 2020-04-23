using System.Windows;
using System.Windows.Input;

namespace TweetsAnalyser.View
{
    /// <summary>
    /// This is a simple logic class for UserNotFoundDialog window.
    /// This is barely used since its just an error dialog AND we are using MVVM design pattern.
    /// </summary>
    public partial class UserNotFoundDialog : Window
    {
        /// <summary>
        /// Initalizes the window (forces it to appear on the screen).
        /// </summary>
        public UserNotFoundDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method which is wired to OK button. It is closing the window.
        /// </summary>
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Method which is wired to the dialog' keydown event.
        /// If enter key was hit then the dialog will be closed.
        /// </summary>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Close();
            }
        }
    }
}
