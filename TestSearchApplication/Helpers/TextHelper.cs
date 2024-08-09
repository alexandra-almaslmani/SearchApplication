using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace TestSearchApplication.Helpers
{
    public class TextHelper
    {
        private static readonly string PunctuationPattern = @"[\p{P}\p{S}]";
        public static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();
            // remove diacritics
            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            // remove punctuation from text
            var cleanedText = Regex.Replace(stringBuilder.ToString(), PunctuationPattern, "");
            return cleanedText.Normalize(NormalizationForm.FormC);
        }
    }
}

