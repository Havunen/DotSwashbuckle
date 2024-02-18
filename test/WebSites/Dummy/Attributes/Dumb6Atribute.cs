using System.ComponentModel.DataAnnotations;

namespace Dummy.Attributes
{
    public sealed class StringMaxLengthAttribute : ValidationAttribute
    {
        public int MaxLength { get; set; }

        public StringMaxLengthAttribute(int maxLength)
        {
            MaxLength = maxLength;
        }
    }
}
