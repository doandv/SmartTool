using System.Windows.Controls;
using MaterialDesignThemes.Wpf;

namespace ST.ShopifyCrawler.ViewModel
{
    public class ShopifyMenuItem
    {
        public string Header { get; set; }
        public PackIconKind Icon { get; set; }
        public UserControl Screen { get; set; }

        public ShopifyMenuItem(string header, PackIconKind icon)
        {
            Header = header;
            Icon = icon;
        }

        public ShopifyMenuItem(string header, UserControl screen, PackIconKind icon)
        {
            Header = header;
            Screen = screen;
            Icon = icon;
        }
    }
}
