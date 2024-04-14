using System.Text.Json.Serialization.Metadata;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Basic.Controllers
{
    [Route("/modifiers")]
    [Produces("application/json")]
    public class ModifiersController
    {
        [HttpPost(Name = "CreateExample")]
        public ExampleClass Create([FromBody, Required] ExampleClass example)
        {
            return example;
        }

        /// <summary>
        /// Searches the collection of examples secret should not be shown or returned from the API
        /// </summary>
        /// <param name="examples" example="hello">A list of search terms</param>
        /// <returns></returns>
        [HttpGet(Name = "SearchExamples")]
        public IEnumerable<ExampleClass> Get([FromQuery(Name = "newexamples")] ExampleClass examples)
        {
            return new[]
            {
                new ExampleClass { Name = "name-1", Secret= new SecretHolder() { Value = "My secret" }},
                new ExampleClass  { Name = "name-2", Secret= new SecretHolder() { Value = "My secret2" }},
            };
        }
    }


    public class ExampleClass
    {
        public string Name { get; set; } = "";
        public SecretHolder? Secret { get; set; }
    }

    public class SecretHolder
    {
        public string Value { get; set; } = "";
    }

    public class PropertyModifiers
    {
        private readonly Type[] _ignoredTypes;

        public PropertyModifiers(params Type[] ignoredTypes)
            => _ignoredTypes = ignoredTypes;

        public void ModifyTypeInfo(JsonTypeInfo ti)
        {
            if (ti.Kind != JsonTypeInfoKind.Object)
                return;

            for (var index = 0; index < ti.Properties.Count; index++)
            {
                var jsonPropertyInfo = ti.Properties[index];
                if (_ignoredTypes.Contains(jsonPropertyInfo.PropertyType))
                {
                    ti.Properties.RemoveAt(index);
                }
            }
        }
    }
}
