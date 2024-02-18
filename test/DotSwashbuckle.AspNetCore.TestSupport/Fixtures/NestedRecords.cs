namespace DotSwashbuckle.AspNetCore.TestSupport.Fixtures
{
    public record RecordTypeWithNestedChild(RecordTypeWithNestedChild.NestedChild Child)
    {
        public record NestedChild(string NonNullable, string? Nullable);
    }

    public record RecordTypeWithNonNestedChild(RecordChild RecordChild);
    public record RecordChild(string NonNullable, string? Nullable);
}
