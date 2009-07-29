using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Ink;
using System.IO;
using System.Globalization;

namespace XPSGeneration
{
    [ValueConversion(typeof(byte[]), typeof(StrokeCollection))]
    public class InkDataToStrokeCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var strokeCollection = new StrokeCollection();
            var inkData = value as byte[];
            if (inkData != null)
            {
                Stream strokesStream = StreamHelper.FromArray(inkData);
                if (strokesStream != null && strokesStream.Length > 1)
                {
                    strokesStream.Seek(0, 0);
                    try
                    {
                        strokeCollection = new StrokeCollection(strokesStream);
                    }
                    catch
                    {
                    }
                }
            }
            return strokeCollection;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var strokes = value as StrokeCollection;
            if (strokes != null)
            {
                var stream = new MemoryStream();
                strokes.Save(stream);
                byte[] rawData = StreamHelper.ToArray(stream);
                return rawData;
            }
            return null;
        }
    }
}
