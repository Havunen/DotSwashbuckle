using Dummy.Attributes;

namespace Dummy.DummyModels.DumbsF
{
    [Dumb2]
    public class Valuesoap
    {
        [Dumb3("value_excl_vat", "II.1.5")]
        public decimal? Value { get; set; }


        [Dumb3("currency", "II.1.5")]
        [CurrencySpecialValidation]
        public string Currency { get; set; }
    }
}
