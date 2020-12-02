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

namespace ST.ShopifyCrawler.Views
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Setting : UserControl
    {
        MainWindow _context;
        public Setting(MainWindow context)
        {
            InitializeComponent();
            _context = context;
        }

        private void Window_Minimize(object sender, MouseButtonEventArgs e)
        {
            _context.WindowState = WindowState.Minimized;
        }
        private void Window_Close(object sender, MouseButtonEventArgs e)
        {
            _context.Close();
        }
    }
}
