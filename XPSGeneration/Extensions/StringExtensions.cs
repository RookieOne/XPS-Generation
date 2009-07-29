using System;
using System.IO;

namespace XPSGeneration.Extensions
{
    public static class StringExtensions
    {
        public static string Format(this string input, params object[] args)
        {
            return string.Format(input, args);
        }
    }
}