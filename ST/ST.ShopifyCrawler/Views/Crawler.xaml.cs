using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using UserControl = System.Windows.Controls.UserControl;

namespace ST.ShopifyCrawler.Views
{
    /// <summary>
    /// Interaction logic for Crawler.xaml
    /// </summary>
    public partial class Crawler : UserControl
    {
        MainWindow _context;

        public Crawler(MainWindow context)
        {
            InitializeComponent();
            _context = context;
        }

        public void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame(true);
            Dispatcher.CurrentDispatcher.BeginInvoke
            (
                DispatcherPriority.Background,
                (SendOrPostCallback)delegate (object arg)
                {
                    var f = arg as DispatcherFrame;
                    f.Continue = false;
                },
                frame
            );
            Dispatcher.PushFrame(frame);
        }

        public void AddTextProccessing(string message, bool isError)
        {
            TextBlock textMessage = new TextBlock();
            textMessage.TextWrapping = TextWrapping.Wrap;
            textMessage.Margin = new Thickness(5, 0, 0, 0);
            textMessage.Foreground = isError ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Green);
            textMessage.Text = message;
            textMessage.FontSize = 13;
            MessageStackPanel.Children.Add(textMessage);
            DoEvents();
        }

        private void Window_Minimize(object sender, MouseButtonEventArgs e)
        {
            _context.WindowState = WindowState.Minimized;
        }
        private void Window_Close(object sender, MouseButtonEventArgs e)
        {
            _context.Close();
        }

        private void btnSelectOuputFolder_Click(object sender, RoutedEventArgs e)
        {
            var openFolderDialog = new FolderBrowserDialog();
            openFolderDialog.Description = "Select the Output folder.";
            openFolderDialog.RootFolder = Environment.SpecialFolder.Desktop;
            DialogResult result = openFolderDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFolderDialog.SelectedPath))
            {
                txtFolderOutput.Text = openFolderDialog.SelectedPath;
            }
        }

        [Obsolete]
        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInfoInput())
            {

            }
        }

        [Obsolete]
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            
        }

        [Obsolete]
        private bool ValidateInfoInput()
        {
            bool status = true;
            var message = string.Empty;

            var txtLinkCrawlVal = txtLinkCrawl.Text.Trim();
            var txtPageFromVal = txtPageFrom.Text.Trim();
            var txtPageToVal = txtPageFrom.Text.Trim();
            var txtFolderOutputVal = txtFolderOutput.Text.Trim();
            var txtFileOutputVal = txtFileOutput.Text.Trim();

            // LinkCrawl
            if(string.IsNullOrEmpty(txtLinkCrawlVal))
            {
                message = "[Error] LinkCrawl cann't blank.";
                AddTextProccessing(message, true);
            }

            // PageFrom
            if (string.IsNullOrEmpty(txtPageFromVal))
            {
                message = "[Error] PageFrom cann't blank.";
                AddTextProccessing(message, true);
            } else
            {
                var pageFrom = 0;
                Int32.TryParse(txtPageFromVal, out pageFrom);
                if(pageFrom <= 0)
                {
                    message = "[Error] PageFrom must greater than 0.";
                    AddTextProccessing(message, true);
                }
            }

            // PageTo
            if (string.IsNullOrEmpty(txtPageToVal))
            {
                message = "[Error] PageTo cann't blank.";
                AddTextProccessing(message, true);
            }
            else
            {
                var pageTo = 0;
                Int32.TryParse(txtPageFromVal, out pageTo);
                if (pageTo <= 0)
                {
                    message = "[Error] PageTo must greater than 0.";
                    AddTextProccessing(message, true);
                }
            }

            // FolderOutput
            if (string.IsNullOrEmpty(txtFolderOutputVal))
            {
                message = "[Error] FolderOutput cann't blank.";
                AddTextProccessing(message, true);
            } else
            {
                if(Directory.Exists(txtFolderOutputVal))
                {
                    message = "[Error] FolderOutput isn't exists.";
                    AddTextProccessing(message, true);
                }
            }

            // FileOutput
            if (string.IsNullOrEmpty(txtFileOutputVal))
            {
                message = "[Error] FileOutput cann't blank.";
                AddTextProccessing(message, true);
            }

            if (!string.IsNullOrEmpty(message))
            {
                return false;
            }
            return status;
        }
    }
}
