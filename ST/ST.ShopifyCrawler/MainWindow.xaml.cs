using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var menuCrawler = new ShopifyMenuItem("Crawler", new Crawler(this), PackIconKind.TextBoxSearch);
            var menuSetting = new ShopifyMenuItem("Setting", new Setting(this), PackIconKind.Settings);
            var menuSupport = new ShopifyMenuItem("Support", new Setting(this), PackIconKind.HelpCircleOutline);

            // add to menu
            Menu.Children.Add(new UserControlMenuItem(menuCrawler, this));
            Menu.Children.Add(new UserControlMenuItem(menuSetting, this));
            Menu.Children.Add(new UserControlMenuItem(menuSupport, this));

        }

        internal void SwichScreen(string menuName, object sender)
        {
            var screen = (UserControl)sender;
            if(screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);

                foreach(UserControlMenuItem menu in Menu.Children)
                {
                    BrushConverter bc = new BrushConverter();
                    menu.Background = (Brush)bc.ConvertFrom("#1395a3");
                    if(menu.ListViewItemMenu.Content.ToString() == menuName)
                    {
                        menu.Background = (Brush)bc.ConvertFrom("#06717d");
                    }
                    
                }
            }
        }
    }
}
