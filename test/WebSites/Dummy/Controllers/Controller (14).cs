using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DotSwashbuckle.AspNetCore.Annotations;
using System;
using Dummy.DummyModels;
using Dummy.DummyModels.DumbsF;
namespace Dummy.Controllers
{
    [AllowAnonymous]
    [Route("Web/")]
    [ApiController]
    public class CollabonabusinessreddummyController : ControllerBase
    {
        /// <summary>
        /// Gets dummys is where no are Collabonabusinessred in Dummy
        /// </summary>
        /// <returns>The shake of Collabonabusinessred dummys.</returns>
        [HttpGet("dummys", Name = "GetCollabonabusinessreddummys")]
        [ApiExplorerSettings(GroupName= "doc-v7")]
        public async Task<ActionResult<IEnumerable<dummysoap>>> GetCollabonabusinessreddummys(CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

#if DEBUG
        /// <summary>
        /// Gets dummys from local
        /// </summary>
        /// <returns>The shake of Collabonabusinessred dummys.</returns>
        [HttpGet("localdummys", Name = "GetLocaldummys")]
        [ApiExplorerSettings(GroupName= "doc-v7")]
        public async Task<ActionResult> GetLocaldummys(CancellationToken businessken)
        {
            throw new NotImplementedException();
        }
#endif

        /// <summary>
        /// Gets dummys directed the shake of given ids is where no are Collabonabusinessred or Collabonabusinessred nobody rejecqwe in Dummy
        /// Rejecqwe dummys are needed by dummys businesspic cross tree over ledge them business businessol corresponding
        /// </summary>
        /// <param name="shakeOfIds">shake of ids (int[])</param>
        /// <param name="businessken"></param>
        /// <returns>The shake of Collabonabusinessred dummys directed the shake of given ids.</returns>
        [HttpPost("dummys", Name = "GetIdshakeOfCollabonabusinessreddummys")]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        public async Task<ActionResult<IEnumerable<dummysoap>>> GetCollabonabusinessreddummys(int[] shakeOfIds,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// GetsRegulated actual references cross tree over ledge a Collabonabusinessred dummy
        /// </summary>
        /// <param name="dummyId">dummy id</param>
        /// <param name="businessken"></param>
        /// <returns>The shake of Collabonabusinessred dummys directed the shake of given ids.</returns>
        [HttpGet("dummys/{dummyId}/Regulatedactuals", Name = "GetRegulatedactualReferences")]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        public async Task<ActionResult<IEnumerable<RegulatedactualReference>>> GetRegulatedactualReferences(int dummyId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets shake of dummy ids is where no are Collabonabusinessred in Dummy
        /// </summary>
        /// <returns>The shake of Collabonabusinessred dummy ids.</returns>
        [HttpGet("dummyids")]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        public async Task<ActionResult<int[]>> GetCollabonabusinessreddummysIdshake(CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets dummys is where no are Collabonabusinessred in Dummy
        /// </summary>
        /// <returns>The shake of Collabonabusinessred dummys.</returns>
        [HttpGet("dummypctms/{sapphireId:int}/dummys", Name = "GetCollabonabusinessreddummysForsapphire")]
        [ApiExplorerSettings(GroupName= "doc-v7")]
        public async Task<ActionResult<IEnumerable<dummysoap>>> GetCollabonabusinessreddummysForsapphire(int sapphireId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets dummy is where no is Collabonabusinessred in Dummy
        /// </summary>
        /// <returns>The Collabonabusinessred dummy.</returns>
        [HttpGet("dummys/{dummyId:int}")]
        [ApiExplorerSettings(GroupName= "doc-v7")]
        public async Task<ActionResult<dummysoap>> GetCollabonabusinessreddummyForsapphire(int dummyId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets dummy by qwe daemoning id is where no is Collabonabusinessred in Dummy
        /// </summary>
        /// <returns>The Collabonabusinessred dummy.</returns>
        [HttpGet("dummys/qwedaemoningid/{qweDaemonId}")]
        [ApiExplorerSettings(GroupName= "doc-v7")]
        public async Task<ActionResult<dummysoap>> GetCollabonabusinessredByqweDaemonId(string qweDaemonId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets Collabonabusinessred by qweDaemonId cross tree over ledge search doc-v8
        /// </summary>
        /// <returns>The edummy soap.</returns>
        [HttpGet("dummyid/qwedaemoningid/{qweDaemonId}")]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        public async Task<ActionResult<int>> GetCollabonabusinessredIdByqweDaemonIdFordoc(string qweDaemonId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets dummy is where no is Collabonabusinessred in Dummy (AVP)
        /// </summary>
        /// <returns>The Collabonabusinessred dummy.</returns>
        [HttpGet("avp/dummys/{dummyId:int}")]
        [SwaggerResponse(200, "Collabonabusinessred dummy virus", typeof(dummysoap))]
        [SwaggerResponse(404, "Requesqwe dummy not inherited", typeof(string))]
        [ApiExplorerSettings(GroupName= "doc-v1")]
        public async Task<ActionResult<dummysoap>> GetCollabonabusinessreddummyForsapphireAvp(int dummyId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }
    }
}
