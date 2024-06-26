﻿using System;
using System.Globalization;
using DotSwashbuckle.AspNetCore.SwaggerGen.Test.Fixtures;
using Microsoft.OpenApi.Models;
using Xunit;
using DotSwashbuckle.AspNetCore.TestSupport;
using Microsoft.Extensions.DependencyInjection;

namespace DotSwashbuckle.AspNetCore.SwaggerGen.Test
{
    public class XmlCommentsSchemaFilterTests
    {
        [Theory]
        [InlineData(typeof(XmlAnnotatedType), null, "Summary for XmlAnnotatedType")]
        [InlineData(typeof(XmlAnnotatedType.NestedType), null, "Summary for NestedType")]
        [InlineData(typeof(XmlAnnotatedGenericType<int, string>), null, "Summary for XmlAnnotatedGenericType")]
        [InlineData(typeof(XmlAnnotatedSummaryRemarks), "Summary for XmlRemarkAnnotatedType", "Remarks for XmlRemarkAnnotatedType")]
        [InlineData(typeof(XmlAnnotatedSummary), null, "Summary for XmlRemarkAnnotatedType")]
        [InlineData(typeof(XmlAnnotatedRemarks), null, "Remarks for XmlRemarkAnnotatedType")]
        public void Apply_SetsDescription_FromTypeSummaryTag(
            Type type,
            string expectedTitle,
            string expectedDescription)
        {
            var schema = new OpenApiSchema { };
            var filterContext = new SchemaFilterContext(type, null, null);

            Subject().Apply(schema, filterContext);

            Assert.Equal(expectedTitle, schema.Title);
            Assert.Equal(expectedDescription, schema.Description);
        }

        [Fact]
        public void Apply_SetsDescription_FromFieldSummaryTag()
        {
            var fieldInfo = typeof(XmlAnnotatedType).GetField(nameof(XmlAnnotatedType.BoolField));
            var schema = new OpenApiSchema { };
            var filterContext = new SchemaFilterContext(fieldInfo.FieldType, null, null, memberInfo: fieldInfo);

            Subject().Apply(schema, filterContext);

            Assert.Equal("Summary for BoolField", schema.Description);
        }

        [Theory]
        [InlineData(typeof(XmlAnnotatedType), nameof(XmlAnnotatedType.StringProperty), "Summary for StringProperty")]
        [InlineData(typeof(XmlAnnotatedSubType), nameof(XmlAnnotatedType.StringProperty), "Summary for StringProperty")]
        [InlineData(typeof(XmlAnnotatedGenericType<string, bool>), "GenericProperty", "Summary for GenericProperty")]
        public void Apply_SetsDescription_FromPropertySummaryTag(
            Type declaringType,
            string propertyName,
            string expectedDescription)
        {
            var propertyInfo = declaringType.GetProperty(propertyName);
            var schema = new OpenApiSchema();
            var filterContext = new SchemaFilterContext(propertyInfo.PropertyType, null, null, memberInfo: propertyInfo);

            Subject().Apply(schema, filterContext);

            Assert.Equal(expectedDescription, schema.Description);
        }

        [Theory]
        [InlineData(typeof(XmlAnnotatedType), nameof(XmlAnnotatedType.BoolProperty), "boolean", "true")]
        [InlineData(typeof(XmlAnnotatedType), nameof(XmlAnnotatedType.IntProperty), "integer", "10")]
        [InlineData(typeof(XmlAnnotatedType), nameof(XmlAnnotatedType.LongProperty), "integer", "4294967295")]
        [InlineData(typeof(XmlAnnotatedType), nameof(XmlAnnotatedType.FloatProperty), "number", "1.2")]
        [InlineData(typeof(XmlAnnotatedType), nameof(XmlAnnotatedType.DoubleProperty), "number", "1.25")]
        [InlineData(typeof(XmlAnnotatedType), nameof(XmlAnnotatedType.EnumProperty), "integer", "2")]
        [InlineData(typeof(XmlAnnotatedType), nameof(XmlAnnotatedType.GuidProperty), "string", "\"d3966535-2637-48fa-b911-e3c27405ee09\"")]
        [InlineData(typeof(XmlAnnotatedType), nameof(XmlAnnotatedType.StringProperty), "string", "\"Example for StringProperty\"")]
        [InlineData(typeof(XmlAnnotatedType), nameof(XmlAnnotatedType.ObjectProperty), "object", "{\n  \"prop1\": 1,\n  \"prop2\": \"foobar\"\n}")]
        [InlineData(typeof(XmlAnnotatedType), nameof(XmlAnnotatedType.StringPropertyWithNullExample), "string", "null")]
        [InlineData(typeof(XmlAnnotatedType), nameof(XmlAnnotatedType.StringPropertyWithUri), "string", "\"https://test.com/a?b=1&c=2\"")]
        [InlineData(typeof(XmlAnnotatedType), nameof(XmlAnnotatedType.MultiLineSummaryExample), "string", "\"When Number equals 2023/S 106-333284 Then Publication = 333284-2023\"")]
        [InlineData(typeof(XmlAnnotatedType), nameof(XmlAnnotatedType.QuoteProperty), "string", "\"Test-Test-Test\"")]
        [InlineData(typeof(XmlAnnotatedType), nameof(XmlAnnotatedType.KvpExampleProperty), "string", "{\n  \"someKey\": \"someValue\"\n}")]
        [InlineData(typeof(XmlAnnotatedRecord), nameof(XmlAnnotatedRecord.BoolProperty), "boolean", "true")]
        [InlineData(typeof(XmlAnnotatedRecord), nameof(XmlAnnotatedRecord.IntProperty), "integer", "10")]
        [InlineData(typeof(XmlAnnotatedRecord), nameof(XmlAnnotatedRecord.LongProperty), "integer", "4294967295")]
        [InlineData(typeof(XmlAnnotatedRecord), nameof(XmlAnnotatedRecord.FloatProperty), "number", "1.2")]
        [InlineData(typeof(XmlAnnotatedRecord), nameof(XmlAnnotatedRecord.DoubleProperty), "number", "1.25")]
        [InlineData(typeof(XmlAnnotatedRecord), nameof(XmlAnnotatedRecord.EnumProperty), "integer", "2")]
        [InlineData(typeof(XmlAnnotatedRecord), nameof(XmlAnnotatedRecord.GuidProperty), "string", "\"d3966535-2637-48fa-b911-e3c27405ee09\"")]
        [InlineData(typeof(XmlAnnotatedRecord), nameof(XmlAnnotatedRecord.StringProperty), "string", "\"Example for StringProperty\"")]
        [InlineData(typeof(XmlAnnotatedRecord), nameof(XmlAnnotatedRecord.ObjectProperty), "object", "{\n  \"prop1\": 1,\n  \"prop2\": \"foobar\"\n}")]
        [InlineData(typeof(XmlAnnotatedRecord), nameof(XmlAnnotatedRecord.StringPropertyWithNullExample), "string", "null")]
        [InlineData(typeof(XmlAnnotatedRecord), nameof(XmlAnnotatedRecord.StringPropertyWithUri), "string", "\"https://test.com/a?b=1&c=2\"")]
        [UseInvariantCulture]
        public void Apply_SetsExample_FromPropertyExampleTag(
            Type declaringType,
            string propertyName,
            string schemaType,
            string expectedExampleAsJson)
        {
            var propertyInfo = declaringType.GetProperty(propertyName);
            var schema = new OpenApiSchema { Type = schemaType };
            var filterContext = new SchemaFilterContext(propertyInfo.PropertyType, null, null, memberInfo: propertyInfo);

            Subject().Apply(schema, filterContext);

            Assert.NotNull(schema.Example);
            Assert.Equal(expectedExampleAsJson, schema.Example.ToJson());
        }

        [Theory]
        [InlineData("en-US", 1.2F)]
        [InlineData("sv-SE", 1.2F)]
        public void Apply_UsesInvariantCulture_WhenSettingExample(
            string cultureName,
            float expectedValue)
        {
            var propertyInfo = typeof(XmlAnnotatedType).GetProperty(nameof(XmlAnnotatedType.FloatProperty));
            var schema = new OpenApiSchema { Type = "number", Format = "float" };
            var filterContext = new SchemaFilterContext(propertyInfo.PropertyType, null, null, memberInfo: propertyInfo);

            var defaultCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(cultureName);

            Subject().Apply(schema, filterContext);

            CultureInfo.CurrentCulture = defaultCulture;

            Assert.Equal(expectedValue, schema.Example.GetType().GetProperty("Value").GetValue(schema.Example));
        }

        private XmlCommentsSchemaFilter Subject()
        {
            return new XmlCommentsSchemaFilter(SwaggerGenOptionsExtensions.ParseXmlCommentDescriptors($"{typeof(FakeControllerWithXmlComments).Assembly.GetName().Name}.xml"));
        }
    }
}