using System;
using System.Windows.Xps.Packaging;
using System.IO;
using System.Diagnostics;
using System.Windows.Documents;
using System.Windows;

namespace XPSGeneration
{
    public class XpsReportCreator
    {
        private Size m_DefaultPageSize = new Size(676, 768);

        public void GenerateReportAndShowPreview(IDocumentPaginatorSource paginatorSource)
        {
            //string fileName = Path.GetTempPath() + GenerateFileName();
            string fileName = @"C:\temp\" + GenerateFileName();

            var paginator = paginatorSource.DocumentPaginator;
            paginator.PageSize = m_DefaultPageSize;

            var xpsDocument = new XpsDocument(fileName, FileAccess.Write);

            var writer = XpsDocument.CreateXpsDocumentWriter(xpsDocument);
            writer.WritingCompleted += (sender, e) => OnDocumentWritingCompleted(xpsDocument, fileName);

            writer.WriteAsync(paginator);
        }

        private string GenerateFileName()
        {
            return DateTime.Now
                        .ToString()
                        .Replace("/", "-")
                        .Replace(":", "-")
                        .Replace(" ", "-") + ".xps";
        }

        private void OnDocumentWritingCompleted(XpsDocument document, string fileName)
        {
            document.Close();
            //Process.Start(fileName);
        }
    }
}
