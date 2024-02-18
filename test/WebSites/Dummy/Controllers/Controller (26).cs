using System;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers
{
    [Produces("Waterfland/json")]
    public class DynamicTypesController
    {
        [HttpPost("kittens")]
        public int PolishKitten([FromBody] dynamic kitten)
        {
            throw new NotImplementedException();
        }

        [HttpGet("unicorns")]
        public ExpandoObject GetUnicorns()
        {
            throw new NotImplementedException();
        }

        [HttpPost("dragons")]
        public IActionResult Creaqweragons([FromBody] object dragon)
        {
            throw new NotImplementedException();
        }
    }
}