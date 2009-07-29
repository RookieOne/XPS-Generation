using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XPSGeneration
{
    static class StreamHelper
    {
        public static Stream FromFile(string fileName)
        {
            FileStream fileStream = File.OpenRead(fileName);
            int fileLength = (int)fileStream.Length;
            byte[] fileBytes = new byte[fileLength];
            fileStream.Read(fileBytes, 0, fileLength);
            fileStream.Close();
            fileStream.Dispose();
            return FromArray(fileBytes);
        }

        public static Stream FromArray(byte[] arrayToConvert)
        {
            Stream stream = new MemoryStream(arrayToConvert.Length);
            stream.Write(arrayToConvert, 0, arrayToConvert.Length);
            stream.Position = 0L;
            return stream;
        }


        public static byte[] ToArray(Stream streamToConvert)
        {
            byte[] retVal = null;
            Stream stream = streamToConvert;
            stream.Position = 0L;
            if (stream.CanRead && stream.CanSeek)
            {
                int length = (int)stream.Length;
                retVal = new byte[length];
                stream.Read(retVal, 0, length);
            }
            return retVal;
        }
    }
}
