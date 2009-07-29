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
            if (rawBmp != null)
            {
                Bitmap bitmap = ByteArrayToBitmap(rawBmp);
                if (bitmap != null)
                {
                    BitmapSource bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(
                        bitmap.GetHbitmap(),
                        IntPtr.Zero,
                        Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions());
                    return bitmapSource;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static Bitmap ByteArrayToBitmap(byte[] imageIn)
        {
            if ((imageIn != null) && (imageIn.Length == 0))
            {
                return null;
            }
            var stream = new MemoryStream();
            new BinaryWriter(stream).Write(imageIn);
            return new Bitmap(stream);
        }
    }
}
