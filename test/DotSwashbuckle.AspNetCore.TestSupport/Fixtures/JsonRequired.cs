using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DotSwashbuckle.AspNetCore.TestSupport.Fixtures
{
    public sealed record OrganizationCustomExchangeRatesDto(
        [property: JsonRequired] TemporalHeaderDto ColumnDates,
        [property: JsonRequired] FrequencyDto Frequency,
        [property: JsonRequired] List<string> CurrenciesRates
    );

    public class FrequencyDto
    {
    }

    public record TemporalHeaderDto
    {
    }
}
