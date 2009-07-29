using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Windows.Interop;
using System.Windows;
using System.IO;
using System.Globalization;

namespace XPSGeneration
{
    [ValueConversion(typeof(byte[]), typeof(BitmapSource))]
    public class ByteArrayBitmapToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte[] rawBmp = value as byte[];

            if (rawBmp == null)
                return null;

            var bitmapimage = new BitmapImage();
            bitmapimage.BeginInit();            
            bitmapimage.StreamSource = new MemoryStream(rawBmp);
            bitmapimage.EndInit();

            return bitmapimage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
