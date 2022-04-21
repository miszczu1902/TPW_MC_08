using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using WpfApp1;

namespace TP.ConcurrentProgramming.PresentationView
{
    /// <summary>
    /// View implementation
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]{0,2}");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}