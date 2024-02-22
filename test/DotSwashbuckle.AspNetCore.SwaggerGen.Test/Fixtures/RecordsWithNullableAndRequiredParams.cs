namespace DotSwashbuckle.AspNetCore.SwaggerGen.Test.Fixtures
{
    public sealed class TestClass
    {
        public TestClass(string requiredString, string optionalString)
        {
            RequiredString = requiredString;
            OptionalString = optionalString;
        }

        public string RequiredString { get; }
        public string? OptionalString { get; }
    }

    public sealed record TestRecordPrimary(string RequiredString, string? OptionalString);
    public sealed record TestRecordPrimaryInverse(string? OptionalString, string RequiredString);

    public sealed record TestValueRecordPrimary(int RequiredString, int? OptionalString);
    public sealed record TestValueRecordPrimaryInverse(int? OptionalString, int RequiredString);

    public sealed record TestRecord
    {
        public TestRecord(string requiredString, string? optionalString)
        {
            RequiredString = requiredString;
            OptionalString = optionalString;
        }

        public string RequiredString { get; }

        public string? OptionalString { get; }
    }

    public sealed record TestRecordInitOptional
    {
        public TestRecordInitOptional(string? optionalString)
        {
            OptionalString = optionalString;
        }

        public string RequiredString { get; set; } = string.Empty;

        public string? OptionalString { get; }
    }

    public sealed record TestRecordInitRequired
    {
        public TestRecordInitRequired(string requiredString)
        {
            RequiredString = requiredString;
        }

        public string RequiredString { get; }

        public string? OptionalString { get; set; }
    }

    public sealed record TestRecordMixed(string RequiredString)
    {
        public string? OptionalString { get; }
    }

    public sealed record TestRecordMixedSwapped(string? OptionalString)
    {
        public string RequiredString { get; set; } = string.Empty;
    }
}
