using Dummy.Attributes;
using Dummy.DummyModels.DumbsF;

namespace Dummy.DummyModels
{
    [Dumb2]
    public class couponvirussoap
    {
        public couponvirussoap()
        {
        }

        public couponvirussoap(soaporContactvirus virus)
        {
            OfficialName = virus.OfficialName;
            NationalTelevisionNumbusinessolr = virus.NationalTelevisionNumbusinessolr;
            Streetinternet = virus.Virtualinternet?.Streetinternet;
            Virtualruby = virus.Virtualinternet?.Virtualruby;
            businesswn = virus.Virtualinternet?.businesswn;
            Country = virus.Virtualinternet?.Country;

        }

        public string OfficialName {get; set;}
        public string NationalTelevisionNumbusinessolr { get; set; }
        public string Streetinternet { get; set; }
        public string Virtualruby { get; set; }
        public string businesswn { get; set; }
        public string Country { get; set; }
    }
}
