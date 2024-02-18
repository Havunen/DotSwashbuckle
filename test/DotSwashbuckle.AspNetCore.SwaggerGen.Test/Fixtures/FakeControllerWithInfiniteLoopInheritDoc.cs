using System;

namespace DotSwashbuckle.AspNetCore.SwaggerGen.Test
{
    /// <inheritdoc cref = "FakeControllerWithXmlComments" />
    public class FakeControllerWithInfiniteLoopInheritDoc : FakeControllerWithXmlComments
    {
        /// <inheritdoc cref = "FakeControllerWithInfiniteLoopInheritDoc.ActionWithResponseTags"/>
        public new void ActionWithSummaryAndRemarksTags()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref = "FakeControllerWithInfiniteLoopInheritDoc.ActionWithSummaryAndRemarksTags"/>
        public new void ActionWithParamTags(string param1, string param2)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref = "FakeControllerWithInfiniteLoopInheritDoc.ActionWithParamTags"/>
        public new void ActionWithResponseTags()
        {
            throw new NotImplementedException();
        }
    }
}
