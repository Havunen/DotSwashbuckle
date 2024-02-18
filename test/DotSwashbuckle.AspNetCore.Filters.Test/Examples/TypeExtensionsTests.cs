using Shouldly;
using DotSwashbuckle.AspNetCore.Filters.Extensions;
using System;
using Xunit;
using DotSwashbuckle.AspNetCore.Filters.Test.TestFixtures.Examples;

namespace DotSwashbuckle.AspNetCore.Filters.Test.Examples
{
    public class TypeExtensionsTests
    {
        [Theory]
        [InlineData(typeof(PersonRequest), "PersonRequest")]
        // [InlineData(typeof(RequestWrapper<PersonRequest>), "RequestWrapper[PersonRequest]")] // Swashbuckle.AspNetCore v4
        [InlineData(typeof(RequestWrapper<PersonRequest>), "PersonRequestRequestWrapper")]      // Swashbuckle.AspNetCore v5
        [InlineData(typeof(Title?), "Title")]
        public void SchemaDefinitionName_ShouldCalculate(Type type, string expectedName)
        {
            // Arrange
            var sut = new RequestExample(null, null);

            // Act
            var result = type.SchemaDefinitionName();

            // Assert
            result.ShouldBe(expectedName);
        }
    }
}
