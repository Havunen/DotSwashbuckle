# v2.0.0

## Removed following obsolete features:

- SwaggerGenOptionsExtensions.TagActionsBy overload -> "Use the overload that accepts a Func that returns a list of tags"
- SwaggerGenOptionsExtensions.GeneratePolymorphicSchemas -> You can use \"UseOneOfForPolymorphism\", \"UseAllOfForInheritance\" and \"SelectSubTypesUsing\" to configure equivalent behavior
- DataContract.ForPrimitive -> "Provide jsonConverter function instead of enumValues"
- DataContract.EnumValues -> Use JsonConverter instead
- ApiDescriptionExtensions.GetAdditionalMetadata -> "Use TryGetMethodInfo() and CustomAttributes() instead"
- ApiParameterDescriptionExtensions.GetAdditionalMetadata -> "Use ParameterInfo(), PropertyInfo() and CustomAttributes() extension methods instead"
- SwaggerUIOptionsExtensions.ValidatorUrl -> "The validator is disabled by default. Use EnableValidator to enable it"