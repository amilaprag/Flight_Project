using Flight_Project.Models.Amadeus.Search;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Project.Models.Amadeus.DbMapping
{
    public class LinksDB
    {
        [Key]
        public int LinksDBId { get; set; }
        public string self { get; set; }
    }

    public class MetaDB
    {
        [Key]
        public int MetaDBId { get; set; }
        public int count { get; set; }
        public Links links { get; set; }
    }

    public class DepartureDB
    {
        [Key]
        public int DepartureDBId { get; set; }
        public string iataCode { get; set; }
        public string terminal { get; set; }
        public DateTime at { get; set; }
    }

    public class ArrivalDB
    {
        [Key]
        public int ArrivalDBId { get; set; }
        public string iataCode { get; set; }
        public string terminal { get; set; }
        public DateTime at { get; set; }
    }

    public class AircraftDB
    {
        [Key]
        public int AircraftDBId { get; set; }
        public string code { get; set; }
    }

    public class OperatingDB
    {
        [Key]
        public int OperatingDBId { get; set; }
        public string carrierCode { get; set; }
    }

    public class SegmentDB
    {
        [Key]
        public int SegmentDBId { get; set; }
        public DepartureDB departure { get; set; }
        public ArrivalDB arrival { get; set; }
        public string carrierCode { get; set; }
        public string number { get; set; }
        public AircraftDB aircraft { get; set; }
        public OperatingDB operating { get; set; }
        public string duration { get; set; }
        public string id { get; set; }
        public int numberOfStops { get; set; }
        public bool blacklistedInEU { get; set; }
    }

    public class ItineraryDB
    {
        [Key]
        public int ItineraryDBId { get; set; }
        public string duration { get; set; }
        public List<SegmentDB> segments { get; set; }
    }

    public class FeeDB
    {
        [Key]
        public int FeeDBId { get; set; }
        public string amount { get; set; }
        public string type { get; set; }
    }

    public class PriceDB
    {
        [Key]
        public int PriceDBId { get; set; }
        public string currency { get; set; }
        public string total { get; set; }
        public string @base { get; set; }
        public List<FeeDB> fees { get; set; }
        public string grandTotal { get; set; }
    }

    public class PricingOptionsDB
    {
        [Key]
        public int PricingOptionsDBId { get; set; }
        public string fareType { get; set; }
        public bool includedCheckedBagsOnly { get; set; }
    }

    public class TravelPriceDB
    {
        [Key]
        public int TravelPriceDBId { get; set; }
        public string currency { get; set; }
        public string total { get; set; }
        public string @base { get; set; }
    }

    public class IncludedCheckedBagsDB
    {
        [Key]
        public int IncludedCheckedBagsDBId { get; set; }
        public int weight { get; set; }
        public string weightUnit { get; set; }
    }

    public class FareDetailsBySegmentDB
    {
        [Key]
        public int FareDetailsBySegmentDBId { get; set; }
        public string segmentId { get; set; }
        public string cabin { get; set; }
        public string fareBasis { get; set; }
        public string @class { get; set; }
        public IncludedCheckedBagsDB includedCheckedBags { get; set; }
    }

    public class TravelerPricingDB
    {
        [Key]
        public int TravelerPricingDBId { get; set; }
        public string travelerId { get; set; }
        public string fareOption { get; set; }
        public string travelerType { get; set; }
        public TravelPriceDB price { get; set; }
        public List<FareDetailsBySegmentDB> fareDetailsBySegment { get; set; }
    }

    public class DatumDB
    {
        [Key]
        public int DatumDBId { get; set; }
        public string type { get; set; }
        public string id { get; set; }
        public string source { get; set; }
        public bool instantTicketingRequired { get; set; }
        public bool nonHomogeneous { get; set; }
        public bool oneWay { get; set; }
        public string lastTicketingDate { get; set; }
        public int numberOfBookableSeats { get; set; }
        public List<ItineraryDB> itineraries { get; set; }
        public PriceDB price { get; set; }
        public PricingOptionsDB pricingOptions { get; set; }
        public string validatingAirlineCodes { get; set; }
        public List<TravelerPricingDB> travelerPricings { get; set; }
    }
    public class DictionariesDB
    {
        [Key]
        public int DictionariesDBId { get; set; }
        public String Location { get; set; }
        public List<AircraftsDB> Aircraft { get; set; }
        public List<CurenciesDB> Currencies { get; set; }
        public List<CarriersDB> Carriers { get; set; }

    }

    public class CarriersDB
    {
        [Key]
        public int CarriersDBId { get; set; }
        public string Details { get; set; }

    }

    public class AircraftsDB
    {
        [Key]
        public int AircraftsDBId { get; set; }
        public string Details { get; set; }

    }

    public class CurenciesDB
    {
        [Key]
        public int CurenciesDBId { get; set; }

        public string Details { get; set; }

    }

    public class FlightOffersSearchDB
    {
        [Key]
        public int FlightOffersSearchDBId { get; set; }
        public MetaDB meta { get; set; }
        public List<DatumDB> data { get; set; }
        public DictionariesDB dictionaries { get; set; }
    }



}