using System.Windows.Controls;

namespace XPSGeneration
{
    /// <summary>
    /// Interaction logic for DocumentReviewPrintView.xaml
    /// </summary>
    public partial class DocumentReviewPrintView : UserControl
    {
        public DocumentReviewPrintView()
        {
            InitializeComponent();
        }

        public DocumentReviewPrintPresentationModel Model
        {
            get { return DataContext as DocumentReviewPrintPresentationModel; }
            set { DataContext = value; }
        }
    }
}