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
using System.Windows.Shapes;

namespace Notepad3
{
    /// <summary>
    /// Interaction logic for AboutBox.xaml
    /// </summary>
    public partial class AboutBox : Window
    {
        public void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            // http://github.com/timsneath/Notepad3
        }

        public AboutBox()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
