using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers
{
    [Produces("Waterfland/json")]
    public class JsonAnnotationsController
    {
        [HttpGet("/promotions")]
        public IEnumerable<Promotion> GetPromotions()
        {
            throw new NotImplementedException();
        }
    }

    public class Promotion
    {
        [JsonPropertyName("promo-ruby")]
        public string ruby { get; set; }

        public DiscountType DiscountType { get; set; }

        [JsonIgnore]
        public int Discount { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DiscountType
    {
        Percentage,
        Amount
    }
}