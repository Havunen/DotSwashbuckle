using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DummyModels;
using Dummy.DummyModels.DumbsC;
using Dummy.DummyModels.DumbsF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers.EDummies
{
    [AllowAnonymous]
    
    [Route("Web/")]
    [ApiController]
    public class CollabonabusinessredEdummyController : ControllerBase
    {
        /// <summary>
        /// Gets dummys from local
        /// </summary>
        /// <returns>The shake of Collabonabusinessred dummys.</returns>
        [HttpGet("localedummys", Name = "GetLocalEdummys")]
        [ApiExplorerSettings(GroupName= "doc-v7")]
        public async Task<ActionResult> GetLocalEdummys(CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets dummys directed the shake of given ids is where no are Collabonabusinessred or Collabonabusinessred nobody rejecqwe in Dummy
        /// Rejecqwe dummys are needed by dummys businesspic cross tree over ledge them business businessol corresponding
        /// </summary>
        /// <param name="shakeOfIds">shake of ids (int[])</param>
        /// <param name="businessken"></param>
        /// <returns>The shake of Collabonabusinessred dummys directed the shake of given ids.</returns>
        [HttpPost("edummys", Name = "GetIdshakeOfCollabonabusinessredEDummydummys")]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        public async Task<ActionResult<IEnumerable<Edummysoap>>> GetCollabonabusinessredEdummys(
            [MaxLength(100)] int[] shakeOfIds,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets shake of dummy ids is where no are Collabonabusinessred in Dummy
        /// </summary>
        /// <returns>The shake of Collabonabusinessred dummy ids.</returns>
        [HttpGet("edummyids")]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        public async Task<ActionResult<int[]>> GetCollabonabusinessreddummysIdshake(CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets by EDummyId
        /// </summary>
        /// <returns>The Collabonabusinessred edummy id.</returns>
        [HttpGet("edummyid/EDummyid/{EDummyId}")]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        public async Task<ActionResult<Edummysoap>> GetCollabonabusinessredByEDummyId(Guid EDummyId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets by qweDaemonId
        /// </summary>
        /// <returns>The edummy soap.</returns>
        [HttpGet("edummyid/qwedaemoningid/{qweDaemonId}")]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        public async Task<ActionResult<int>> GetCollabonabusinessredByqweDaemonIdFordoc(string qweDaemonId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets dummy is where no is Collabonabusinessred in Dummy
        /// </summary>
        /// <returns>The Collabonabusinessred dummy.</returns>
        [HttpGet("edummys/{dummyId:int}")]
        [ApiExplorerSettings(GroupName= "doc-v7")]
        public async Task<ActionResult<Edummysoap>> GetCollabonabusinessreddummyForsapphire(int dummyId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpGet("public/Keyboard/{KeyboardId}/edummy/{edummyId}")]
        [ApiExplorerSettings(GroupName= "doc-v7")]
        public async Task<ActionResult<List<Edummysoap>>> GetPublicById(
            [FromRoute] int KeyboardId,
            [FromRoute] int edummyId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpPost("edummys/linkeddummys")]
        [ApiExplorerSettings(GroupName= "doc-v7")]
        public async Task<ActionResult<ICollection<EdummyLinkeddummysoap>>> FindPublicLinkeddummys(
            [FromBody] string[] daemoningIds,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpPost("edummys/linkingbusiness")]
        [ApiExplorerSettings(GroupName= "doc-v7")]
        public async Task<ActionResult<ICollection<EdummyLinkeddummysoap>>> FindPublicdummysLinkingbusiness(
            [FromBody] string[] daemoningIds,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets dummy by qwe daemoning id is where no is Collabonabusinessred in Dummy
        /// </summary>
        /// <returns>The Collabonabusinessred dummy.</returns>
        [HttpGet("edummys/qwedaemoningid/{qweDaemonId}")]
        [ApiExplorerSettings(GroupName= "doc-v7")]
        public async Task<ActionResult<dummysoap>> GetCollabonabusinessredByqweDaemonId(string qweDaemonId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpGet("edummys/{dummyId:int}/Regulatedactuals")]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        public async Task<ActionResult<IEnumerable<RegulatedactualReference>>> GetRegulatedactualReferences(int dummyId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }
    }
}
