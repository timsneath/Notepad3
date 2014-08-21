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

namespace Notepad3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string filename;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CommandNew_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (textEditor.IsModified)
            {
                MessageBoxResult mbr = MessageBox.Show("Save changes to \"" + (filename ?? "untitled") + "\"?", "Notepad3", MessageBoxButton.YesNoCancel);
                if (mbr == MessageBoxResult.Cancel)
                {
                    return;
                }

                if (mbr == MessageBoxResult.Yes)
                {
                    CommandSave_Executed(sender, e);
                }
                
                filename = null;
                textEditor.Clear();
            }
        }

        private void CommandOpen_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension 

            // Process open file dialog box results 
            if (dlg.ShowDialog() ?? false)
            {
                // Open document 
                filename = dlg.FileName;
                textEditor.Load(dlg.FileName);
            }
        }

        private void CommandSave_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (filename != null)
            {
                textEditor.Save(filename);
            }
            else
            {
                CommandSaveAs_Executed(sender, e);
            }
        }

        private void CommandSaveAs_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension 

            // Process save file dialog box results 
            if (dlg.ShowDialog() ?? false)
            {
                // Save document 
                filename = dlg.FileName;
                textEditor.Save(dlg.FileName);
            }
        }

        private void CommandExit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void CommandTimeDate_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // insert current time and date in locale format
            // Windows Notepad uses "1:40 PM 8/21/2014", but we use default .NET format
            textEditor.Document.Insert(textEditor.CaretOffset, System.DateTime.Now.ToString());
        }

        private void CommandFont_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // show font dialog and set settings appropriately

            // unfortunately there's no FontDialog in WPF, so we have to use the WinForms one
            // that requires we convert between System.Windows.Typeface and System.Drawing.Font
            var dialog = new System.Windows.Forms.FontDialog();

            System.Drawing.FontStyle winformsFontStyle = System.Drawing.FontStyle.Regular;

            if (textEditor.FontStyle == FontStyles.Italic || textEditor.FontStyle == FontStyles.Oblique) {
                winformsFontStyle = winformsFontStyle | System.Drawing.FontStyle.Italic;
            }

            if (textEditor.FontWeight == FontWeights.Bold) {
                winformsFontStyle = winformsFontStyle | System.Drawing.FontStyle.Bold;
            }


            var winformsFont = new System.Drawing.Font(
                                textEditor.FontFamily.ToString(),
                                (float)(textEditor.FontSize * 72.0 / 92.0), // WPF uses a logical 96dpi
                                winformsFontStyle
                               );

            dialog.Font = winformsFont;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                winformsFont = dialog.Font;
                
                textEditor.FontFamily = new FontFamily(winformsFont.FontFamily.Name);
                textEditor.FontSize = winformsFont.SizeInPoints * 96.0 / 72.0; // WPF uses a logical 96dpi
                textEditor.FontStyle = winformsFont.Italic ? FontStyles.Italic : FontStyles.Normal;
                textEditor.FontWeight = winformsFont.Bold   ? FontWeights.Bold : FontWeights.Normal;
                textEditor.FontStretch = FontStretches.Normal;

                //Properties.Settings["EditorFont"] = dialog.Font;
            }

        }

        private void CommandWordWrap_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            textEditor.WordWrap = !textEditor.WordWrap;

        }

        private void CommandShowWhitespace_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            textEditor.Options.ShowSpaces = !textEditor.Options.ShowSpaces;
            textEditor.Options.ShowTabs = !textEditor.Options.ShowTabs;
        }

        private void CommandShowLineEndings_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            textEditor.Options.ShowEndOfLine = !textEditor.Options.ShowEndOfLine;
        }

        private void CommandShowWrapSymbols_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CommandShowLineNumbers_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            textEditor.ShowLineNumbers = !textEditor.ShowLineNumbers;
        }

        private void CommandAbout_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var about = new AboutBox();
            about.ShowDialog();
        }
    }
}
