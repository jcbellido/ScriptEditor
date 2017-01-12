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

namespace ScriptEditor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainScriptpane.ScriptEditorRichTextBox.DataContext = null;
        }

        private void buttonQuit_Click(object sender, RoutedEventArgs e)
        {
            // TODO verify the model is properly persisted before quitting
            this.Close();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonPurge_Click(object sender, RoutedEventArgs e)
        {
            mainScriptpane.PurgeDocument();
        }

        private void buttonGenerateFixed_Click(object sender, RoutedEventArgs e)
        {
            mainScriptpane.GenerateFixedDocument();
        }
    }
}
