using System.Windows.Controls;
using System.Windows.Documents;

namespace XPSGeneration
{
    /// <summary>
    /// Interaction logic for DocumentOnFilePrintView.xaml
    /// </summary>
    public partial class DocumentOnFilePrintView : UserControl
    {
        public DocumentOnFilePrintView()
        {
            InitializeComponent();
        }

        public FlowDocument GetFlowDocument()
        {
            flowDocument.Blocks.Clear();
            return flowDocument;
        }
    }
}