using System.Windows;
using System.Windows.Controls;

namespace XPSGeneration.Extensions
{
    public static class ControlExtensions
    {
        public static void ShowInWindow(this Control control)
        {
            var window = new Window();
            window.Content = control;
            window.Show();
        }

        public static void ShowInDialog(this Control control)
        {
            var window = new Window();
            window.Content = control;
            window.ShowDialog();
        }
    }
}