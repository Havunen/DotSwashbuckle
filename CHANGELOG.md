# v3.0.8
- Adds support for HttpResults https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2595
- Fixes an issue where interface chain is not checked for parameters, this resolves issue: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2596
- Added minimum and maximum constraint for unsigned integers to more accurately declare them in the schema. UInt128 maximum value is left as null because OpenApi maximum field is too small to support it. Changed uint to use int64 format because int32 is too small to represent its upper limit. Fixes https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2582
- Adds support for Int128 and UInt128 and unify STJ and Newtonsoft Primitive types and formats lookup dictionary to reduce code duplication. Fixes https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2611

# v3.0.7
- always prefer `modelMetaData.Type` over `parameter.Type` to support Enums. Fixes https://github.com/Havunen/DotSwashbuckle/issues/7

# v3.0.6
- Mark non-nullable properties required when SupportNonNullableReferenceTypes is enabled and property is declared non-nullable. Fixes https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2623 for https://github.com/Havunen/DotSwashbuckle/issues/3

# v3.0.5
- Adds support for RequestBodyFilters and ParameterFilters when constructing schema from Metadata fixes https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2613 and https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2561
- Fixes an issue where IFormFile parameters are incorrectly generated when WithOpenApi() extension method is used ref: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2625

# v3.0.4
- Fixes an issue where single file AOT .NET 8 project does not start if swagger is registered

# v3.0.3
- Adds support for System.Text.Json.RequiredAttribute
- Fixes an issue where referencing same schema multiple times causes runtime error. https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2679 Instead changed the runtime to throw error if same id path is used for different schemas. for https://github.com/Havunen/DotSwashbuckle/issues/3

# v3.0.2
- Fixes an issue where nullable is not defined for primitive response type schema https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2731
- Fixes an issue where nested record types nullable does not get generated correctly https://github.com/Havunen/DotSwashbuckle/commit/ab7e8e681888034fa9157565eaf45ec18703849b
- Adds support for Length attribute https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2756

# v3.0.1
- Adds support for required property modifiers. Fixes https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2764
- DotSwashbuckle dependencies are now defined with open version to allow applications update them

# v3.0.0
- Adds support for using `<remarks>` on schema XML comments.
When using `<remarks>` on a class, it will be used as the description for the schema.
When there is also `<summary>` defined, the `<summary>` will be used as the title for the schema.
When `<summary>` is defined alone it is used as description for the schema.
- Adds support for defining examples using `SwaggerSchemaAttribute`.
- Adds support for custom Required and Binding attributes
- Fixes an issue where UniqueItems is not set true for `IReadOnlySet<T>` 
- Adds support for `WithSummary` and `WithDescription` metadata
- Improve performance of IsRequiredSpecified method
- Fixes an issue where query string parameters crash OpenApi path generation `System.ArgumentException: Literal sections cannot contain the '?' character.`
- For more details see: https://github.com/Havunen/DotSwashbuckle/issues/1

## Breaking Changes
- `ReDoc` has been renamed to `Redoc`, this applies to all methods and types. Including the Nuget package name `DotSwashbuckle.AspNetCore.Redoc`

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
