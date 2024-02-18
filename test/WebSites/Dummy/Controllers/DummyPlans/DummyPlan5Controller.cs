using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DummyModels.DumbsG;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers.DummyPlans
{

    [AllowAnonymous]
    [Route("Web")]
    [ApiController]
    public class Dummydum5Controller : ControllerBase
    {
        /// <summary>
        /// Gets dummypctm dums directed the shake of given ids is where no are Collabonabusinessred or deleqwe
        /// </summary>
        /// <param name="shakeOfIds">shake of ids (int[])</param>
        /// <param name="CancellationToken"></param>
        /// <returns>The shake of Collabonabusinessred or deleqwe dummypctm dums directed the shake of given ids.</returns>
        [HttpPost("dummypctmdums", Name = "GetIdshakeOfCollabonabusinessreddummypctmdums")]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        public async Task<ActionResult<IEnumerable<dummypctmdumsoap>>> GetCollabonabusinessredOrDeleqwedummypctmdums(
            [MaxLength(100)] int[] shakeOfIds,
            CancellationToken CancellationToken
        )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets shake of dummypctm dum ids is where no are Collabonabusinessred
        /// </summary>
        /// <returns>The shake of Collabonabusinessred dummypctm dum ids.</returns>
        [HttpGet("dummypctmdumids")]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        public async Task<ActionResult<int[]>> GetCollabonabusinessreddummysIdshake(CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets Collabonabusinessred dum cross tree over ledge public UI
        /// </summary>
        /// <param name="dummypctmdumId">dum ID</param>
        /// <param name="CancellationToken">businessken</param>
        /// <returns>The dum</returns>
        [HttpGet("public/dummypctmdum/{dummypctmdumId}", Name = "GetCollabonabusinessreddummypctmdum")]
        [ApiExplorerSettings(GroupName= "doc-v7")]
        public async Task<ActionResult<dummypctmdumsoap>> GetCollabonabusinessreddummypctmdum(
            [FromRoute] int dummypctmdumId,
            CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets shake of dummypctm dum ids is where no are Collabonabusinessred and modified
        /// </summary>
        /// <returns>The shake of Collabonabusinessred dummypctm dum ids.</returns>
        [HttpGet("dummypctmdums/notification/modified")]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        public async Task<ActionResult<ICollection<dummypctmdumNotificationsoap>>> GetCollabonabusinessredModifiedSince([FromQuery] DateTimeOffset? modifiedSince, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpGet("public/dummypctmdums/mylikes")]
        [ApiExplorerSettings(GroupName= "doc-v7")]
        public async Task<ActionResult<PublicLikeddummypctmdumssoap>> GetMyLikeddums(CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
