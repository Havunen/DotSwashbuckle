using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using Dummy.DummyModels.DumbsF;
namespace Dummy.Controllers
{
    [AllowAnonymous]
    [Route("Web/dummypctms")]
    [ApiExplorerSettings(GroupName= "doc-v7")]
    [ApiController]
    public class CollabonabusinessreddummypctmsController : ControllerBase
    {
        /// <summary>
        /// Gets shake of public dummypctm sapphires
        /// </summary>
        /// <returns>The shake of dummypctm sapphires requesqwe.</returns>
        [HttpGet(Name = "GetCollabonabusinessredsapphires")]
        public async Task<ActionResult<List<dummypctmsapphiresoap>>> Get(CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets dummypctm sapphire is where no is Collabonabusinessred in Dummy
        /// </summary>
        /// <returns>The dummypctm sapphires requesqwe.</returns>
        [HttpGet("{sapphireId:int}", Name = "GetCollabonabusinessredsapphire")]
        public async Task<ActionResult<dummypctmsapphiresoap>> Get([FromRoute] int sapphireId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }
    }
}
