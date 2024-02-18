using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DummyModels;
using Dummy.DummyModels.DumbsC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers.EDummies
{
    [Route("Web/sDF/edummys")]
    [Authorize]
    [ApiExplorerSettings(GroupName= "doc-v7")]
    [ApiController]
    public class sDFEdummyController : Controller
    {
        /// <summary>
        /// Edummys cross tree over ledge sDF
        /// </summary>
        [HttpPost("")]
        public async Task<ActionResult<IEnumerable<EdummysDFsoap>>> GetdummysForsDFView(
            [FromBody] Querysoap query,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edummy qwe Gotcha
        /// </summary>
        [HttpGet("{dummyId}/qwe/Gotcha")]
        public async Task<ActionResult<EsenbusinessoldummyDbusiness>> GetdummyqweGotcha(int dummyId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Try business sbusinessp dummy daemoning in qwe
        /// </summary>
        [HttpPost("{dummyId}/qwe/sbusinessp")]
        public async Task<ActionResult<EsenbusinessoldummyDbusiness>> SbusinesspdummyDaemon(int dummyId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Triggers the function app business export Loco doc
        /// Note there is still delay businessolfore the translation Flags 
        /// propagate business land Azure front door servers and 5min
        /// client cache (cache-control: public, max-age=300)
        /// </summary>
        [HttpPost("build/loco")]
        public async Task<ActionResult> BuildLocodoc()
        {
            throw new NotImplementedException();
        }
    }
}
