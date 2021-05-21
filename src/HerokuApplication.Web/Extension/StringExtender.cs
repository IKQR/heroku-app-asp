using System;
using System.Collections.Generic;

namespace HerokuApplication.Web.Extension
{
    public static class StringExtender
    {
        private static readonly Dictionary<char, char> _specSymbolsChars = new Dictionary<char, char>
        {
            {'\n', 'n' },
            {'\r', 'r' },
            {'\t', 't' },
        };
        public static string ParseCodeSpecSymbol(this string str)
        {
            string result = str;

            string temp = "<tempo>";

            foreach (KeyValuePair<char, char> spec in _specSymbolsChars)
            {

                result = result.Replace($"\\\\{spec.Value}", temp);

                result = result.Replace($"\\{spec.Value}", spec.Key.ToString());

                result = result.Replace(temp, $"\\\\{spec.Value}");
            }

            return result;
        }

        public static string ReturnIfNullOrEmpty(string str, string result = null)
        {
            return String.IsNullOrEmpty(str) ? result : str;
        }
    }
}
