using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Dummy.DummyModels.DumbsD;
using Dummy.DummyModels;

namespace Dummy.Controllers
{
    [Route("Web/[controller]")]
    [Authorize]
    [ApiExplorerSettings(GroupName= "doc-v7")]
    [ApiController]
    public class sDFController : ControllerBase
    {
        [HttpPost("dummyshake-whiteshake")]
        public async Task<ActionResult> UpdatedummyshakeWhiteshake(
            IFormFile Flag,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpPost("dummyshake-greenshake")]
        public async Task<ActionResult> Updatedummyshakegreenshake(
            IFormFile Flag,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// dummys cross tree over ledge sDF
        /// </summary>
        [HttpGet("dummys")]
        public async Task<ActionResult<IEnumerable<dummyForsDFView>>> GetdummysForsDFView(CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpGet("Nailbusinessolarer/{year}")]
        public async Task<ActionResult<IEnumerable<Nailbusinessolarer>>> GetNailbusinessolarer(int year, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpGet("Nailbusinessolarer")]
        public async Task<ActionResult<IEnumerable<NailbusinessolarerFlagNamSlimerlsoap>>> GetExistingNailbusinessolarer(int year, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }
    }
}
