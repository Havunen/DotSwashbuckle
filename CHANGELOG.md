# v3.0.0
- Add support for using `<remarks>` on schema XML comments.
When using `<remarks>` on a class, it will be used as the description for the schema.
When there is also `<summary>` defined, the `<summary>` will be used as the title for the schema.
When `<summary>` is defined alone it is used as description for the schema.
- Add support for defining examples using `SwaggerSchemaAttribute`.
- Adds support for custom Required and Binding attributes
- Fixes an issue where UniqueItems is not set true for `IReadOnlySet<T>` 

# v2.0.0

- XML comments parsing performance has been improved
- Add support for JsonPolymorphic and JsonDerivedType attributes
- DotSwashbuckle.AspNetCore.Filters added
- DotSwashbuckle.AspNetCore.Filters.Abstractions added

## Removed following obsolete features:

- SwaggerGenOptionsExtensions.TagActionsBy overload -> "Use the overload that accepts a Func that returns a list of tags"
- SwaggerGenOptionsExtensions.GeneratePolymorphicSchemas -> You can use \"UseOneOfForPolymorphism\", \"UseAllOfForInheritance\" and \"SelectSubTypesUsing\" to configure equivalent behavior
- DataContract.ForPrimitive -> "Provide jsonConverter function instead of enumValues"
- DataContract.EnumValues -> Use JsonConverter instead
- ApiDescriptionExtensions.GetAdditionalMetadata -> "Use TryGetMethodInfo() and CustomAttributes() instead"
- ApiParameterDescriptionExtensions.GetAdditionalMetadata -> "Use ParameterInfo(), PropertyInfo() and CustomAttributes() extension methods instead"
- SwaggerUIOptionsExtensions.ValidatorUrl -> "The validator is disabled by default. Use EnableValidator to enable it"
- SwaggerSubType, SwaggerSubTypesAttribute and SwaggerDiscriminator has been removed, use JsonPolymorphic and JsonDerivedType instead
