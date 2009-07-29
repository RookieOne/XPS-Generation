using System.ComponentModel;

namespace XPSGeneration
{
    public class DocumentReviewPrintPresentationModel : INotifyPropertyChanged
    {
        public DocumentReviewPrintPresentationModel(DocumentReviewPrintView view)
        {
            View = view;
            View.Model = this;
        }

        private byte[] m_InkedAnnotation;
        private byte[] m_Page;

        public byte[] InkedAnnotation
        {
            get { return m_InkedAnnotation; }
            set
            {
                m_InkedAnnotation = value;
                PropertyChanged(this, new PropertyChangedEventArgs("InkedAnnotation"));
            }
        }

        public byte[] Page
        {
            get { return m_Page; }
            set
            {
                m_Page = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Page"));
            }
        }

        public DocumentReviewPrintView View { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}