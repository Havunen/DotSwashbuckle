using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

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
        /// <param name="cat">
        /// 0. katti
        /// 1. kissa
        /// 2. cat
        /// </param>
        /// <returns>doc block or failure</returns>
        [HttpGet("{cat}")]
        public async Task<IActionResult> Get(CancellationToken Louummlation, [FromRoute] string cat = "GG-GG")
        {
            throw new NotImplementedException();
        }

        [HttpGet("minmax/{minMaxCat}/{minMaxCat2}")]
        public async Task<IActionResult> GetS(
            [FromRoute] [Length(1, 10)] string minMaxCat = "GG-GG",
            [FromRoute] [MinLength(1)] [MaxLength(4)] [Length(2, 5)] string minMaxCat2 = "CC-GG"
        )
        {
            throw new NotImplementedException();
        }
    }
}
