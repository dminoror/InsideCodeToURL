using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace InsideCodeToURL
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        CheckBox[] checks;
        TextBox[] boxs;
        string[] sourceURLs;
        int indexCheck = 0;

        public MainWindow()
        {
            InitializeComponent();
            checks = new CheckBox[] { checkMagnet, checkBaidu, checkBaiduS };
            boxs = new TextBox[] { boxMagnet, boxBaidu, boxBaiduS };
            sourceURLs = new string[] {
                "magnet:?xt=urn:btih:",
                "http://pan.baidu.com",
                "http://pan.baidu.com/s/" };
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                checks[indexCheck].IsChecked = false;
                indexCheck++;
                if (indexCheck >= checks.Length)
                    indexCheck = 0;
                checks[indexCheck].IsChecked = true;
            }
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                Clipboard.SetText(boxs[indexCheck].Text);
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            var text = Clipboard.GetData(DataFormats.Text) as string;
            if (text != null && text.Length < 50)
            {
                for (int i = 0; i < boxs.Length; i++)
                {
                    boxs[i].Text = sourceURLs[i] + text;
                }
            }
        }
    }
}
