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

namespace WpfApp1
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 wind = new Window1();
            wind.Show();
            this.Close();
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32(number.Content);
            number.Content = i + 1;
        }

        private void minus_click(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32(number.Content);

            if (i > 0)
            {
                number.Content = i - 1;
            }
        }
    }
}
