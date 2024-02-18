using System.Net;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace SwashbuckleTestBug2679.Controllers {

    [ApiVersion(1.0)]
    [Authorize]
    [Route("api/v{version:ApiVersion}/a")]
    public class AController : ODataController {

        [HttpGet]
        [ProducesResponseType(typeof(IQueryable<DtoA>), 200)]
        [ProducesResponseType((Int32)HttpStatusCode.NotFound)]
        [ProducesResponseType((Int32)HttpStatusCode.BadRequest)]
        [ProducesResponseType((Int32)HttpStatusCode.InternalServerError)]
        public Task<ActionResult<IQueryable<DtoA>>> Gets() {

            ActionResult<IQueryable<DtoA>> result = Ok(new List<DtoA>());
            return Task.FromResult(result);
        }

        [HttpGet("{key}")]
        [ProducesResponseType(typeof(DtoA), 200)]
        [ProducesResponseType((Int32)HttpStatusCode.NotFound)]
        [ProducesResponseType((Int32)HttpStatusCode.BadRequest)]
        [ProducesResponseType((Int32)HttpStatusCode.InternalServerError)]
        public Task<ActionResult<DtoA>> Get(Int64 key) {
            ActionResult<DtoA> result = Ok(new DtoA());
            return Task.FromResult(result);
        }

        [HttpGet("{key}/c")]
        [ProducesResponseType(typeof(DtoB), 200)]
        [ProducesResponseType((Int32)HttpStatusCode.NotFound)]
        [ProducesResponseType((Int32)HttpStatusCode.BadRequest)]
        [ProducesResponseType((Int32)HttpStatusCode.InternalServerError)]
        public Task<ActionResult<DtoB>> GetB(Int64 key) {
            ActionResult<DtoB> result = Ok(new DtoB());
            return Task.FromResult(result);
        }

    }
}