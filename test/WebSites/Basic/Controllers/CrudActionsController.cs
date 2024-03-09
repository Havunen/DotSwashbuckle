using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Basic.Controllers
{
    /// <summary>
    /// Summary for CrudActionsController
    /// </summary>
    [Route("/products")]
    [Produces("application/json")]
    public class CrudActionsController
    {
        /// <summary>
        /// Creates a <paramref name="product"/>
        /// </summary>
        /// <remarks>
        /// ## Heading 1
        /// 
        ///     POST /products
        ///     {
        ///         "id": "123",
        ///         "description": "Some product"
        ///     }
        /// 
        /// </remarks>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateProduct")]
        public Product Create([FromBody, Required]Product product)
        {
            return product;
        }

        /// <summary>
        /// Searches the collection of products by description key words
        /// </summary>
        /// <param name="keywords" example="hello">A list of search terms</param>
        /// <returns></returns>
        [HttpGet(Name = "SearchProducts")]
        public IEnumerable<Product> Get([FromQuery(Name = "kw")]string keywords = "foobar")
        {
            return new[]
            {
                new Product { Id = 1, Description = "A product" },
                new Product { Id = 2, Description = "Another product" },
            };
        }

        /// <summary>
        /// Returns a specific product
        /// </summary>
        /// <param name="id" example="111">The product id</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetProduct")]
        public Product Get(int id)
        {
            return new Product { Id = id, Description = "A product" };
        }

        /// <summary>
        /// Updates all properties of a specific product
        /// </summary>
        /// <param name="id" example="222"></param>
        /// <param name="product"></param>
        [HttpPut("{id}", Name = "UpdateProduct")]
        public void Update(int id, [FromBody, Required]Product product)
        {
        }

        /// <summary>
        /// Updates some properties of a specific product
        /// </summary>
        /// <param name="id" example="333"></param>
        /// <param name="updates"></param>
        [HttpPatch("{id}", Name = "PatchProduct")]
        public void Patch(int id, [FromBody, Required]IDictionary<string, object> updates)
        {
        }

        /// <summary>
        /// Deletes a specific product
        /// </summary>
        /// <param name="id" example="444"></param>
        [HttpDelete("{id}", Name = "DeleteProduct")]
        public void Delete(int id)
        {
        }

        [HttpGet("status", Name = "GetStatus")]
        public void GetStatus(ProductStatus status)
        {
        }

        [HttpPost("status", Name = "GetStatus")]
        public ProductStatus PostStatus([FromBody] ProductStatus status)
        {
            return status;
        }

        [HttpGet("GetDoc")]
        [Consumes(typeof(IChild), MediaTypeNames.Application.Json)]
        [Produces(typeof(IChild))]
        public IActionResult GetDoc([FromQuery] IChild query)
        {
            return null;
        }

        [HttpPost("GetDoc2")]
        public async Task<ActionResult<IEnumerable<string>>> GetAll(GetData.Query query)
        {
            return null;
        }

        /// <summary> Request the forecast of a specific day. </summary>
        /// <param name="date" example="2023-01-24">Date of the requested forecast. </param>
        [HttpGet("weather/{date}")]
        public Results<Ok<WeatherForecast>, NotFound> GetWeather(DateOnly date)
        {
            return TypedResults.Ok(new WeatherForecast());
        }

        /// <summary> Request the forecast of a specific day. </summary>
        /// <param name="date" example="2023-01-24">Date of the requested forecast. </param>
        [HttpGet("weather/async/{date}")]
        public async Task<Results<Ok<WeatherForecast>, NotFound>> GetWeatherAsync(DateOnly date)
        {
            return TypedResults.Ok(await Task.FromResult(new WeatherForecast()));
        }

        [HttpPost("/formpost/regularPost")]
        public Ok<WeatherForecast> Save([FromForm] WeatherForecast person, [FromForm] Product address, [FromQuery] string ts) {
            return TypedResults.Ok(new WeatherForecast());
        }

        [HttpGet("/formpost/regularGet")]
        public Ok<WeatherForecast> Save1([FromForm] WeatherForecast person, [FromForm] Product address, [FromQuery] string ts)
        {
            return TypedResults.Ok(new WeatherForecast());
        }
    }

    public class WeatherForecast
    {
        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
    }

    public class GetData
    {
        public class Query
        {
            public int MyParameter { get; set; }
        }
    }

    /// <summary>The parent.</summary>
    public interface IParent
    {
        /// <summary>The parent value.</summary>
        string? ParentValue { get; set; }
    }

    /// <summary>The child.</summary>
    public interface IChild : IParent
    {
        /// <summary>The child value.</summary>
        string? Value { get; set; }
    }

    public enum ProductStatus
    {
        All = 0,
        OutOfStock = 1,
        InStock = 2
    }

    /// <summary>
    /// Represents a product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Uniquely identifies the product
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Describes the product
        /// </summary>
        public string Description { get; set; }

        public ProductStatus Status { get; set; }

        public ProductStatus? Status2 { get; set; }
    }
}