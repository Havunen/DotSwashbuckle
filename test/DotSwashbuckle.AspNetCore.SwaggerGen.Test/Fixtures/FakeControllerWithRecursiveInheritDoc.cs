using System;

namespace DotSwashbuckle.AspNetCore.SwaggerGen.Test
{
    /// <inheritdoc cref = "FakeControllerWithXmlComments" />
    public class FakeControllerWithRecursiveInheritDoc : FakeControllerWithXmlComments
    {
        /// <inheritdoc cref = "FakeControllerWithXmlComments.ActionWithSummaryAndRemarksTags"/>
        public new void ActionWithSummaryAndRemarksTags()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref = "FakeControllerWithRecursiveInheritDoc.ActionWithSummaryAndRemarksTags"/>
        public new void ActionWithParamTags(string param1, string param2)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref = "FakeControllerWithRecursiveInheritDoc.ActionWithParamTags"/>
        public new void ActionWithResponseTags()
        {
            throw new NotImplementedException();
        }
    }
}
