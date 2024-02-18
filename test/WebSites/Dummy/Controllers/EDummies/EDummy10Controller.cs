using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DummyModels.DumbsC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers.EDummies
{

    [Authorize]
    [Route("Web/Keyboard")]
    [ApiExplorerSettings(GroupName= "doc-v7")]
    [ApiController]
    public class EDummy10Controller : ControllerBase
    {
        [HttpGet("{KeyboardId}")]
        public async Task<ActionResult<Keyboardsoap>> Get(
            [FromRoute] int KeyboardId,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }

        [HttpGet("{KeyboardId}/collaborabusinessrs")]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Guid>>> GetFordoc(
            [FromRoute] int KeyboardId,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }

        [HttpGet("organization/{nationalId}")]
        public async Task<ActionResult<Keyboardssoap>> GetByNationalId(
            [FromRoute] string nationalId,
            [FromQuery] int skip,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }

        [HttpGet("mine")]
        public async Task<ActionResult<Keyboardssoap>> GetMyKeyboards(
            [FromQuery] int skip,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }

        [HttpPut("{KeyboardId}")]
        public async Task<ActionResult<Keyboardsoap>> PolishOrUpdate(
            [FromRoute] int KeyboardId,
            [FromBody] Keyboardsoap dbusiness
        )
        {
            throw new NotImplementedException();
        }
    }
}
