using Flight_Project.Models.Amadeus.Search;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Project.Models.Amadeus.Search
{
    public class Links
    {
        public int LinksId { get; set; }
        public string self { get; set; }
    }

    public class Meta
    {
        public int MetaId { get; set; }
        public int count { get; set; }
        public Links links { get; set; }
    }

    public class Departure
    {
        public int DepartureId { get; set; }
        public string iataCode { get; set; }
        public string terminal { get; set; }
        public DateTime at { get; set; }
    }

    public class Arrival
    {
        public int ArrivalId { get; set; }
        public string iataCode { get; set; }
        public string terminal { get; set; }
        public DateTime at { get; set; }
    }

    public class Aircraft
    {
        public int AircraftId { get; set; }
        public string code { get; set; }
    }

    public class Operating
    {
        public int OperatingId { get; set; }
        public string carrierCode { get; set; }
    }

    public class Segment
    {
        public int SegmentId { get; set; }
        public Departure departure { get; set; }
        public Arrival arrival { get; set; }
        public string carrierCode { get; set; }
        public string number { get; set; }
        public Aircraft aircraft { get; set; }
        public Operating operating { get; set; }
        public string duration { get; set; }
        public string id { get; set; }
        public int numberOfStops { get; set; }
        public bool blacklistedInEU { get; set; }
    }

    public class Itinerary
    {
        public int ItineraryId { get; set; }
        public string duration { get; set; }
        public List<Segment> segments { get; set; }
    }

    public class Fee
    {
        public int FeeId { get; set; }
        public string amount { get; set; }
        public string type { get; set; }
    }

    public class Price
    {
        public int PriceId { get; set; }
        public string currency { get; set; }
        public string total { get; set; }
        public string @base { get; set; }
        public List<Fee> fees { get; set; }
        public string grandTotal { get; set; }
    }

    public class PricingOptions
    {
        public int PricingOptionsId { get; set; }

        [NotMapped]
        public List<string> fareType { get; set; }

        public bool includedCheckedBagsOnly { get; set; }

    }

    public class Price2
    {
        public int Price2Id { get; set; }
        public string currency { get; set; }
        public string total { get; set; }
        public string @base { get; set; }
    }

    public class IncludedCheckedBags
    {
        public int IncludedCheckedBagsId { get; set; }
        public int weight { get; set; }
        public string weightUnit { get; set; }
    }

    public class FareDetailsBySegment
    {
        public int FareDetailsBySegmentId { get; set; }
        public string segmentId { get; set; }
        public string cabin { get; set; }
        public string fareBasis { get; set; }
        public string @class { get; set; }
        public IncludedCheckedBags includedCheckedBags { get; set; }
    }

    public class TravelerPricing
    {
        public int TravelerPricingId { get; set; }
        public string travelerId { get; set; }
        public string fareOption { get; set; }
        public string travelerType { get; set; }
        public Price2 price { get; set; }
        public List<FareDetailsBySegment> fareDetailsBySegment { get; set; }
    }

    public class Datum
    {
        public int DatumId { get; set; }
        public string type { get; set; }
        public string id { get; set; }
        public string source { get; set; }
        public bool instantTicketingRequired { get; set; }
        public bool nonHomogeneous { get; set; }
        public bool oneWay { get; set; }
        public string lastTicketingDate { get; set; }
        public int numberOfBookableSeats { get; set; }
        public List<Itinerary> itineraries { get; set; }
        public Price price { get; set; }
        public PricingOptions pricingOptions { get; set; }

        private List<String> _validatingAirlineCodes { get; set; }
        [NotMapped]
        public List<string> validatingAirlineCodes { get; set; }
        public List<TravelerPricing> travelerPricings { get; set; }
    }

    public class Dictionaries
    {
        public int DictionariesId { get; set; }
        public String _Aircrafts { get; set; }
        [NotMapped]
        public Dictionary<string, string> Aircraft { get; set; }
        [NotMapped]
        public Dictionary<string, string> Currencies { get; set; }
         [NotMapped]
        public Dictionary<string, string> Carriers { get; set; }

    }

    public class FlightOffersSearchRS
    {
        public int FlightOffersSearchRSId { get; set; }
        public Meta meta { get; set; }
        public List<Datum> data { get; set; }
        [NotMapped]
        public Dictionaries dictionaries { get; set; }
    }



}