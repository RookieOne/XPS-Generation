using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.IO;
using XPSGeneration.Extensions;
using XPSGeneration.XpsDocumentUtilities;

namespace XPSGeneration
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;

            var documentOnFilePrintView = new DocumentOnFilePrintView();
            FlowDocument flowDocument = documentOnFilePrintView.GetFlowDocument();

            for (int i = 1; i <= 3; i++)
            {
                var view = new DocumentReviewPrintView();
                var documentPrintPresenter = new DocumentReviewPrintPresentationModel(view);

                view.ShowInDialog();

                var w = view.image.ActualWidth;
                var h = view.image.ActualHeight;

                Stream pageStream = StreamHelper.FromFile(@"data\Page{0}.jpg".Format(i));
                documentPrintPresenter.Page = StreamHelper.ToArray(pageStream);

                Stream inkStream = StreamHelper.FromFile(@"data\Ink{0}.ink".Format(i));
                documentPrintPresenter.InkedAnnotation = StreamHelper.ToArray(inkStream);

                //documentPrintPresenter.View.ShowInDialog();

                flowDocument.Blocks.Add(new BlockUIContainer(documentPrintPresenter.View));
            }

            documentOnFilePrintView.ShowInDialog();

            new XpsReportCreator().GenerateReportAndShowPreview(flowDocument);

            //MyXpsDocumentHelper.Create(flowDocument);

            Cursor = Cursors.Arrow;
            MessageBox.Show("Done");
        }
    }
}