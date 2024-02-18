using System;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DummyModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers.EDummies
{
    [Authorize]
    [Route("Web/Keyboard/{KeyboardId}/edummy/{edummyId}/Regulatedactuals")]
    [ApiController]
    [ApiExplorerSettings(GroupName= "doc-v7")]
    public class EDummy4Controller : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult> Get(
            [FromRoute] int edummyId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<RegulatedactualReference>> PostEDummyRegulatedactual([FromRoute] int KeyboardId, [FromRoute] int edummyId, [FromBody] RegulatedactualReference RegulatedactualReference, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{RegulatedactualId}")]
        public async Task<ActionResult> DeleteEDummyRegulatedactual([FromRoute] int KeyboardId, [FromRoute] int edummyId, [FromRoute] int RegulatedactualId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEDummyRegulatedactualsFordummy([FromRoute] int KeyboardId, [FromRoute] int edummyId, [FromBody] RegulatedactualReference[] RegulatedactualReferences, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpPost("updateRegulatedReference")]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateRegulatedReference([FromRoute] int edummyId, [FromBody] RegulatedactualReference RegulatedReference, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }
    }
}
