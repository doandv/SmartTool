using ST.ShopifyCrawler.ViewModel;
using ST.ShopifyCrawler.Views;
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

namespace ST.ShopifyCrawler
{
    /// <summary>
    /// Interaction logic for UserControlMenuItem.xaml
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {
        MainWindow _context;
        public UserControlMenuItem(ShopifyMenuItem menuItem, MainWindow context)
        {
            InitializeComponent();
            _context = context;
            //ExpanderMenu.Visibility = menuItem.Screen != null ? Visibility.Collapsed : Visibility.Visible;

            this.DataContext = menuItem;
        }

        //private void MenuSelected(object sender, MouseButtonEventArgs e)
        //{
        //    TextBlock textClick = (TextBlock)sender;
        //    if (textClick.Text == "Crawler")
        //    {
        //        _context.SwichScreen(new Crawler());
        //    }
        //    else if (textClick.Text == "Setting")
        //    {
        //        _context.SwichScreen(new Setting());
        //    }
        //    else if (textClick.Text == "Support")
        //    {
        //        _context.SwichScreen(new Setting());
        //    }
        //    //textClick.Background = SolidColorBrush.OpacityProperty;
        //}

        private void MenuSelected(object sender, MouseButtonEventArgs e)
        {
            ListViewItem menuItem = e.Source as ListViewItem;
            
            if (menuItem != null)
            {
                var menuName = menuItem.Content.ToString();
                if (menuName == "Crawler")
                {
                    _context.SwichScreen(menuName, new Crawler());
                }
                else if (menuName == "Setting")
                {
                    _context.SwichScreen(menuName, new Setting());
                }
                else if (menuName == "Support")
                {
                    _context.SwichScreen(menuName, new Setting());
                }
            }
        }
    }
}
