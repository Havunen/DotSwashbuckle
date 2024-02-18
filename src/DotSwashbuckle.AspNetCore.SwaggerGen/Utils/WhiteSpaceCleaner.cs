using System.Text;

namespace DotSwashbuckle.AspNetCore.SwaggerGen.Utils
{
    public static class WhiteSpaceCleaner
    {
        /// <summary>
        /// Condenses the text by removing leading, trailing, and duplicate whitespace characters.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Condense(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            var condensedTextBuilder = new StringBuilder(text.Length);
            bool hasWhiteSpace = false;
            bool hasText = false;

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (char.IsWhiteSpace(c))
                {
                    hasWhiteSpace = true;
                } else
                {
                    if (hasWhiteSpace && hasText)
                    {
                        condensedTextBuilder.Append(' ');
                    }

                    hasText = true;
                    hasWhiteSpace = false;
                    condensedTextBuilder.Append(c);
                }
            }

            return condensedTextBuilder.ToString();
        }
    }
}
