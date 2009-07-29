using System;
using System.IO;
using System.IO.Packaging;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;
using System.Windows.Xps.Serialization;

namespace XPSGeneration.XpsDocumentUtilities
{
    public static class MyXpsDocumentHelper
    {
        public static void Create(IDocumentPaginatorSource paginator)
        {
            using (var container = Package.Open(@"C:\temp\" + GetFileName(), FileMode.Create))
            {
                using (var xpsDoc = new XpsDocument(container, CompressionOption.Maximum))
                {
                    var xpsSM = new XpsSerializationManager(new XpsPackagingPolicy(xpsDoc), false);
                    xpsSM.SaveAsXaml(paginator);
                }
            }
        }

        private static string GetFileName()
        {
            return DateTime.Now
                       .ToString()
                       .Replace("/", "-")
                       .Replace(":", "-")
                       .Replace(" ", "-") + ".xps";
        }
    }
}