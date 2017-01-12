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

namespace ScriptEditor.Controls
{
    public partial class scriptPane : UserControl
    {
        public scriptPane()
        {
            InitializeComponent();
        }

        public void PurgeDocument()
        {
            ScriptEditorRichTextBox.Document.Blocks.Clear();
        }

        private void ScriptEditorRichTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                e.Handled = true;   // Absorbs the event == as if no key was ever pressed
            }
        }

        public void GenerateFixedDocument()
        {
            var pageContent = new PageContent();

            var fixedPage = new FixedPage();

            pageContent.Child = fixedPage;

            // But this is not a flow document ... so I'm not creating a new page 
            var stackPane = new StackPanel();
            stackPane.Orientation = Orientation.Vertical;
            for(int i = 0; i < 200; i++)
            {
                TextBlock page1Text = new TextBlock();
                page1Text.Text = "This is a test";
                page1Text.FontSize = 24;
                page1Text.Margin = new Thickness(0);
                stackPane.Children.Add(page1Text);
            }

            fixedPage.Children.Add(stackPane);

            var fixedDocument = new FixedDocument();
            fixedDocument.Pages.Add(pageContent);

            pageContent.Width = 800;
            pageContent.Height = 800;

            ScriptEditorFixedPage.Document = fixedDocument;
        }

        private void ScriptEditorFixedPage_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
