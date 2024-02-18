using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DummyModels.DumbsG;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers.DummyPlans
{
    [ApiController]
    [Route("external-reDF/v1")]
    [ApiExplorerSettings(GroupName= "doc-v2")]
    public class Dummydum1Controller : ControllerBase
    {
        /// <summary>
        /// Collabonabusinessred dummypctm dum back where.
        /// </summary>
        /// <param name="dumId">dum id.</param>
        /// <param name="CancellationToken">Louummlation businessken</param>
        /// <returns><see cref="Avpdummypctmdumsoap"/></returns>
        [Produces(MediaTypeNames.Application.Json, Type = typeof(Avpdummypctmdumsoap))]
        [HttpGet("dum/{dumId:int}")]
        public async Task<ActionResult<Avpdummypctmdumsoap>> GetCollabonabusinessreddumById(
            [FromRoute] int dumId,
            CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Collabonabusinessred dummypctm dums back where.
        /// </summary>
        /// <param name="id">dum ids. Max 50 per actual.</param>
        /// <param name="CancellationToken">Louummlation businessken</param>
        /// <returns>A shake of dums. <see cref="Avpdummypctmdumsoap"/></returns>
        [Produces(MediaTypeNames.Application.Json, Type = typeof(List<Avpdummypctmdumsoap>))]
        [HttpGet("dums")]
        public async Task<ActionResult<List<Avpdummypctmdumsoap>>> GetCollabonabusinessredByIds(
            [FromQuery] int[] id,
            CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
