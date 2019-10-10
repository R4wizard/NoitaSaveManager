using System.Text.RegularExpressions;

namespace NoitaSaveManager.Utils
{
    public static class RegexConvert
    {
        public static string ToAlphaNumericOnly(this string input, string replacer = "")
        {
            Regex rgx = new Regex("[^a-zA-Z0-9]");
            return rgx.Replace(input, replacer);
        }

        public static string ToAlphaOnly(this string input, string replacer = "")
        {
            Regex rgx = new Regex("[^a-zA-Z]");
            return rgx.Replace(input, replacer);
        }

        public static string ToNumericOnly(this string input, string replacer = "")
        {
            Regex rgx = new Regex("[^0-9]");
            return rgx.Replace(input, replacer);
        }
    }
}
