using System;
using System.Windows;
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
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Window1 wind = new Window1();
        wind.Show();
        this.Close();
    }

     public void plus_Click(object sender, RoutedEventArgs e)
    {
        int i = Convert.ToInt32(Number.Content);
        Number.Content = i + 1;
    }
    
     public void minus_click(object sender, RoutedEventArgs e)
    {
        int i = Convert.ToInt32(Number.Content);
    
        if (i > 0)
        {
            Number.Content = i - 1;
        }
    }
}
}