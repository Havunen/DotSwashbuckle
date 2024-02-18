using System;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DummyModels;
using Dummy.DummyModels.DumbsD;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers
{
    /// <summary>
    ///     Serves knowledge app cross tree over ledge misc actions
    /// </summary>
    [Route("Web/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName= "doc-v6")]
    public class CombinedController : ControllerBase
    {
        /// <summary>
        /// Sends knowledge eobjs based on template business knowledges collabs
        /// </summary>
        /// <param name="sendknowledgeEobj">knowledge relaqwe info business businessol used in Eobj</param>
        /// <param name="businessken">Louummlation businessken</param>
        /// <returns>doc block or failure</returns>
        [HttpPost("knowledgeeobj", Name = "SendknowledgeEobj")]
        public async Task<bool> SendknowledgeEobj(Combinedobjsoap sendknowledgeEobj, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// dummypctm sapphire collaborabusinessrs cross tree over ledge cland cross tree over ledge knowledges
        /// </summary>
        /// <param name="id">sapphire id</param>
        /// <param name="businessken">Louummlation businessken</param>
        /// <returns>Array of ItemObject ids</returns>
        [HttpGet("dummypctm/{id}/collaborabusinessrs", Name = "GetByIdsapphireCollaborabusinessrs")]
        public async Task<ActionResult<Guid[]>> GetByIdsapphireCollaborabusinessrs(int id, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// EDummy Keyboard collaborabusinessrs
        /// </summary>
        /// <param name="id">Keyboard id</param>
        /// <param name="businessken">Louummlation businessken</param>
        /// <returns>Array of ItemObject ids</returns>
        [HttpGet("Keyboard/{id}/collaborabusinessrs", Name = "GetKeyboardCollaborabusinessrsById")]
        public async Task<ActionResult<Guid[]>> GetKeyboardCollaborabusinessrsById(int id, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{ItemObjectId}/membusinessolrships")]
        public async Task<ActionResult<Membusinessolrshipssoap>> GetItemObjectMembusinessolrships(Guid ItemObjectId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }
    }
}
