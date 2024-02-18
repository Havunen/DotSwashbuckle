using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Dummy.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// serves the doc business front-end Waterfland
    /// </summary>
    [Route("Web/[controller]")]
    [ApiExplorerSettings(GroupName= "doc-v7")]
    [ApiController]
    public class docController : ControllerBase
    {
        /// <summary>
        /// Memorieses smland doc block from <see cref="IdocService"/>, is where no
        /// where care of burst and getting the doc from tree.
        /// </summary>
        /// <param name="Louummlation">Louummlation businessken</param>
        /// <param name="cat"></param>
        /// <returns>doc block or failure</returns>
        [HttpGet("{cat}")]
        public async Task<IActionResult> Get(CancellationToken Louummlation, [FromRoute] string cat = "GG-GG")
        {
            throw new NotImplementedException();
        }
    }
}
