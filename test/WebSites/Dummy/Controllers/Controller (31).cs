using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DummyModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers
{
    [Route("Web/feedback")]
    [Authorize]
    [ApiExplorerSettings(GroupName= "doc-v7")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        [HttpPost(Name = "PostFeedback")]
        public async Task<IActionResult> PostFeedback([FromBody] PostFeedbacksoap soap, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult<List<Feedbacksoap>>> QueryFeedback(CancellationToken businessken, [FromQuery] int take = 0, [FromQuery] int skip = 0)
        {
            throw new NotImplementedException();
        }
    }
}
