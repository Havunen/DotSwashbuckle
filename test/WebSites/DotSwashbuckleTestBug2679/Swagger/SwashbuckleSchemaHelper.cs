namespace SwashbuckleTestBug2679.Swagger {
    public class SwashbuckleSchemaHelper {

        private readonly Dictionary<String, List<String>> _schemaNameRepetition = new();

        // borrowed from https://github.com/domaindrivendev/Swashbuckle.AspNetCore/blob/95cb4d370e08e54eb04cf14e7e6388ca974a686e/src/Swashbuckle.AspNetCore.SwaggerGen/SchemaGenerator/SchemaGeneratorOptions.cs#L44
        private String DefaultSchemaIdSelector(Type modelType) {
            if (!modelType.IsConstructedGenericType) { return modelType.Name.Replace("[]", "Array"); }

            String prefix = modelType.GetGenericArguments()
                .Select(genericArg => DefaultSchemaIdSelector(genericArg))
                .Aggregate((previous, current) => previous + current);

            return prefix + modelType.Name.Split('`').First();
        }

        public String GetSchemaId(Type modelType) {
            String id = DefaultSchemaIdSelector(modelType);

            if (!_schemaNameRepetition.ContainsKey(id)) {
                _schemaNameRepetition.Add(id, new List<String>());
            }

            List<String> modelNameList = _schemaNameRepetition[id];
            String fullName = modelType.FullName ?? "";
            if (!String.IsNullOrEmpty(fullName) && !modelNameList.Contains(fullName)) {
                modelNameList.Add(fullName);
            }

            Int32 index = modelNameList.IndexOf(fullName);

            return $"{id}{(index >= 1 ? index.ToString() : "")}";
        }
    }
}
