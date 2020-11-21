using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Project.Models.Amadeus.Configuration
{
    public class Test
    {
        public string BaseUri { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string GrantType { get; set; }
    }

    public class Prod
    {
        public string BaseUri { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }

    public class AmadeusConfiguration
    {
        public Test Test { get; set; }
        public Prod Prod { get; set; }
    }
}
