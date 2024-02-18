using DotSwashbuckle.AspNetCore.SwaggerGen.Utils;
using Xunit;

namespace DotSwashbuckle.AspNetCore.SwaggerGen.Tests.Utils
{
    public class WhiteSpaceCleanerTests
    {
        [Fact]
        public void Condense_WithNullText_ReturnsEmptyString()
        {
            string text = null;

            string result = WhiteSpaceCleaner.Condense(text);

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void Condense_WithEmptyText_ReturnsEmptyString()
        {
            string text = string.Empty;

            string result = WhiteSpaceCleaner.Condense(text);

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void Condense_WithWhiteSpaceText_ReturnsCondensedText()
        {
            string text = "   Hello    World   ";

            string result = WhiteSpaceCleaner.Condense(text);

            Assert.Equal("Hello World", result);
        }

        [Fact]
        public void Condense_WithNewLineText_ReturnsCondensedText()
        {
            string text = "Hello\n\nWorld";

            string result = WhiteSpaceCleaner.Condense(text);

            Assert.Equal("Hello World", result);
        }

        [Fact]
        public void Condense_WithMixedWhiteSpaceText_ReturnsCondensedText()
        {
            string text = "Hello\n   \tWorld";

            string result = WhiteSpaceCleaner.Condense(text);

            Assert.Equal("Hello World", result);
        }

        [Fact]
        public void Condense_WithMixedWhiteSpaceTextWindowsStyle_ReturnsCondensedText()
        {
            string text = "\r\n  \r\n  Hello\r\n  \n  \tWorld \r\n   \r\n\n";

            string result = WhiteSpaceCleaner.Condense(text);

            Assert.Equal("Hello World", result);
        }
    }
}
