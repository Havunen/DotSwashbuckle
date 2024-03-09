using DotSwashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;

namespace Basic.Controllers
{
    [Route("/xmlComments")]
    public class XmlCommentController
    {
        /// <summary>
        /// Initialize request to api.
        /// </summary>
        /// <param name="request">Id of the request returned by POST.</param>
        /// <param name="timeStamp">the moment.</param>
        /// <param name="token"></param>
        /// <returns></returns>
        [SwaggerResponse(201, "The created status.", typeof(MyRequest))]
        [SwaggerResponse(400, "An error occurred. Message is returned.", typeof(string))]
        [SwaggerResponse(401, "Unauthorized.", typeof(string))]
        [SwaggerResponse(404, "Not found.", typeof(string))]
        [SwaggerResponse(500, "Unexpected exception while communicating with API.", typeof(string))]
        [HttpPost("xmlPost")]
        public async Task<ActionResult<MyRequest>> Post(
            [FromBody] MyRequest request,
            [FromQuery] string timeStamp,
            CancellationToken token
        )
        {
            return null;
        }

        public class MyRequest
        {
            public string Id { get; set; }
        }
    }
}
