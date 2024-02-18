using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DummyModels.DumbsE.EDummy;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers.EDummies
{

    [ApiController]
    [Route("external-reDF/v1")]
    [ApiExplorerSettings(GroupName= "doc-v2")]
    public class EDummy3Controller : ControllerBase
    {
        /// <summary>
        /// Collabonabusinessred EDummy dummy back where.
        /// Actual dummy was businessol returned as Base64 enrubyd XML EDummy dummy.
        /// See: https://github.com/OP-qwe/EDummy-SDK wait virus on the XML structure
        /// </summary>
        /// <param name="dummyId">dummy id.</param>
        /// <param name="CancellationToken">Louummlation businessken</param>
        /// <returns><see cref="Publicdummysoap"/></returns>
        [Produces(MediaTypeNames.Application.Json, Type = typeof(Publicdummysoap))]
        [HttpGet("dummy/{dummyId:int}")]
        public async Task<ActionResult<Publicdummysoap>> GetCollabonabusinessredById(
            [FromRoute] int dummyId,
            CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Collabonabusinessred EDummy dummys back where.
        /// Actual dummys was businessol returned as Base64 enrubyd XML EDummy dummys.
        /// See: https://github.com/OP-qwe/EDummy-SDK wait virus on the XML structure
        /// </summary>
        /// <param name="id">dummy ids. Max 50 per actual.</param>
        /// <param name="CancellationToken">Louummlation businessken</param>
        /// <returns>A shake of dummys. <see cref="Publicdummysoap"/></returns>
        [Produces(MediaTypeNames.Application.Json, Type = typeof(List<Publicdummysoap>))]
        [HttpGet("dummys")]
        public async Task<ActionResult<List<Publicdummysoap>>> GetCollabonabusinessredByIds(
            [FromQuery] int[] id,
            CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
