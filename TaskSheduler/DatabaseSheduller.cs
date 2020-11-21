using Flight_Project.Data;
using Flight_Project.Models.Amadeus.DbMapping;
using Flight_Project.Models.Amadeus.Search;
using Flight_Project.Repository.Search.Amadeus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Project.TaskSheduler
{
    public class DatabaseSheduller : IDatabaseSheduller
    {
        private readonly IConfiguration _Configuration;
        private readonly ILogger<DatabaseSheduller> _Logger;
        private readonly IAmadeus_SearchRepository _ISearchConnecterCaller;
        private readonly DatabaseContext _DatabaseContext;

        public DatabaseSheduller(IConfiguration Configuration, ILogger<DatabaseSheduller> Logger, IAmadeus_SearchRepository ISearchConnecterCaller, DatabaseContext DatabaseContext)
        {
            _Configuration = Configuration;
            _Logger = Logger;
            _ISearchConnecterCaller = ISearchConnecterCaller;
            _DatabaseContext = DatabaseContext;
        }

        public bool DbFetchSheduller()
        {

            var BaseLocation = _Configuration["LocationsList:BaseLocation"];
            var LocationList = _Configuration.GetSection("LocationsList:ToLocations").GetChildren().Select(x => x.Value).ToArray();

            foreach (var item in LocationList)
            {
                DateTime DateStart = DateTime.Now;
                DateTime DateStop = DateStart.AddDays(330);

                for (DateTime DateRunning = DateStart; DateRunning.Date < DateStop.Date; DateRunning = DateRunning.AddDays(1))
                {
                    FlightOfferSearchRQ FlightOfferSearchRQ = new FlightOfferSearchRQ();
                    OriginLocationCode OriginLocationCode = new OriginLocationCode();
                    DestinationLocationCode DestinationLocationCode = new DestinationLocationCode();
                    Pax Pax = new Pax();

                    OriginLocationCode.DepartureDate = DateRunning;
                    OriginLocationCode.IataCode = BaseLocation;

                    DestinationLocationCode.IataCode = item;

                    FlightOfferSearchRQ.TravelClass = "";
                    FlightOfferSearchRQ.NonStop = true;
                    FlightOfferSearchRQ.CurrencyCode = "";

                    Pax.Adult = 1;

                    var SearchString = "flight-offers?originLocationCode=" + OriginLocationCode.IataCode + "&destinationLocationCode=" + DestinationLocationCode.IataCode + "&departureDate=" + OriginLocationCode.DepartureDate.ToString("yyyy-MM-dd") + "&adults=" + Pax.Adult + "&nonStop=" + FlightOfferSearchRQ.NonStop.ToString().ToLower() + "&max=250";

                    FlightOffersSearchRS FlightOffersSearchRS = _ISearchConnecterCaller.FlightOffersSearch(SearchString);

                    if (FlightOffersSearchRS==null)
                    {
                        int i = 0;
                        while (FlightOffersSearchRS == null && i < 3)
                        {
                            System.Threading.Thread.Sleep(1000);
                            FlightOffersSearchRS = _ISearchConnecterCaller.FlightOffersSearch(SearchString);
                            i++;
                        }
                    }

                    try
                    {
                        FlightOffersSearchDB FlightOffersSearchDBObj = new FlightOffersSearchDB();
                        MetaDB MetaDBObj = new MetaDB();
                        List<DatumDB> DatumDBList = new List<DatumDB>();
                        DictionariesDB DictionariesDBObj = new DictionariesDB();

                        MetaDBObj.links = FlightOffersSearchRS.meta.links;
                        MetaDBObj.count = FlightOffersSearchRS.meta.count;
                        FlightOffersSearchDBObj.meta = MetaDBObj;

                        foreach (var Data in FlightOffersSearchRS.data)
                        {
                            DatumDB DatumDBObj = new DatumDB();
                            DatumDBObj.type = Data.type;
                            DatumDBObj.id = Data.id;
                            DatumDBObj.source = Data.source;
                            DatumDBObj.instantTicketingRequired = Data.instantTicketingRequired;
                            DatumDBObj.nonHomogeneous = Data.nonHomogeneous;
                            DatumDBObj.oneWay = Data.oneWay;
                            DatumDBObj.lastTicketingDate = Data.lastTicketingDate;
                            DatumDBObj.numberOfBookableSeats = Data.numberOfBookableSeats;

                            List<ItineraryDB> ItineraryDBList = new List<ItineraryDB>();
                            foreach (var Itineraries in Data.itineraries)
                            {
                                ItineraryDB ItineraryDBObj = new ItineraryDB();
                                ItineraryDBObj.duration = Itineraries.duration;
                                List<SegmentDB> SegmentDBList = new List<SegmentDB>();

                                foreach (var Segments in Itineraries.segments)
                                {
                                    SegmentDB SegmentDBObj = new SegmentDB();
                                    SegmentDBObj.carrierCode = Segments.carrierCode;
                                    SegmentDBObj.number = Segments.number;
                                    SegmentDBObj.duration = Segments.duration;
                                    SegmentDBObj.id = Segments.id;
                                    SegmentDBObj.numberOfStops = Segments.numberOfStops;
                                    SegmentDBObj.blacklistedInEU = Segments.blacklistedInEU;

                                    DepartureDB DepartureDBObj = new DepartureDB();
                                    DepartureDBObj.iataCode = Segments.departure.iataCode;
                                    DepartureDBObj.terminal = Segments.departure.terminal;
                                    DepartureDBObj.at = Segments.departure.at;

                                    SegmentDBObj.departure = DepartureDBObj;

                                    ArrivalDB ArrivalDBObj = new ArrivalDB();
                                    ArrivalDBObj.iataCode = Segments.arrival.iataCode;
                                    ArrivalDBObj.terminal = Segments.arrival.terminal;
                                    ArrivalDBObj.at = Segments.arrival.at;

                                    SegmentDBObj.arrival = ArrivalDBObj;

                                    AircraftDB AircraftDBObj = new AircraftDB();
                                    AircraftDBObj.code = Segments.aircraft.code;

                                    SegmentDBObj.aircraft = AircraftDBObj;

                                    OperatingDB OperatingDBObj = new OperatingDB();
                                    OperatingDBObj.carrierCode = Segments.operating.carrierCode;

                                    SegmentDBObj.operating = OperatingDBObj;

                                    SegmentDBList.Add(SegmentDBObj);
                                }
                                ItineraryDBObj.segments = SegmentDBList;
                                ItineraryDBList.Add(ItineraryDBObj);

                            }
                            DatumDBObj.itineraries = ItineraryDBList;

                            PriceDB PriceDBObj = new PriceDB();
                            PriceDBObj.currency = Data.price.currency;
                            PriceDBObj.total = Data.price.total;
                            PriceDBObj.@base = Data.price.@base;
                            PriceDBObj.grandTotal = Data.price.grandTotal;

                            List<FeeDB> FeesDBList = new List<FeeDB>();
                            foreach (var Fees in Data.price.fees)
                            {
                                FeeDB FeesDB = new FeeDB();
                                FeesDB.amount = Fees.amount;
                                FeesDB.type = Fees.type;
                                FeesDBList.Add(FeesDB);
                            }
                            PriceDBObj.fees = FeesDBList;

                            DatumDBObj.price = PriceDBObj;

                            PricingOptionsDB PricingOptionsDBobj = new PricingOptionsDB();
                            PricingOptionsDBobj.includedCheckedBagsOnly = Data.pricingOptions.includedCheckedBagsOnly;

                            foreach (var Fare in Data.pricingOptions.fareType)
                            {
                                PricingOptionsDBobj.fareType += Fare + ",";
                            }

                            DatumDBObj.pricingOptions = PricingOptionsDBobj;

                            foreach (var validatingAirlineCodes in Data.validatingAirlineCodes)
                            {
                                DatumDBObj.validatingAirlineCodes += validatingAirlineCodes + ",";
                            }

                            List<TravelerPricingDB> TravelerPricingDBList = new List<TravelerPricingDB>();
                            foreach (var TravelerPricings in Data.travelerPricings)
                            {
                                TravelerPricingDB TravelerPricingDBObj = new TravelerPricingDB();
                                TravelerPricingDBObj.travelerId = TravelerPricings.travelerId;
                                TravelerPricingDBObj.fareOption = TravelerPricings.fareOption;
                                TravelerPricingDBObj.travelerType = TravelerPricings.travelerType;

                                TravelPriceDB TravelPriceDBObj = new TravelPriceDB();
                                TravelPriceDBObj.currency = TravelerPricings.price.currency;
                                TravelPriceDBObj.total = TravelerPricings.price.total;
                                TravelPriceDBObj.@base = TravelerPricings.price.@base;
                                TravelerPricingDBObj.price = TravelPriceDBObj;

                                List<FareDetailsBySegmentDB> FareDetailsBySegmentDBList = new List<FareDetailsBySegmentDB>();
                                foreach (var FareDetailsBySegment in TravelerPricings.fareDetailsBySegment)
                                {
                                    FareDetailsBySegmentDB FareDetailsBySegmentDBObj = new FareDetailsBySegmentDB();
                                    FareDetailsBySegmentDBObj.cabin = FareDetailsBySegment.cabin;
                                    FareDetailsBySegmentDBObj.segmentId = FareDetailsBySegment.segmentId;
                                    FareDetailsBySegmentDBObj.fareBasis = FareDetailsBySegment.fareBasis;
                                    FareDetailsBySegmentDBObj.@class = FareDetailsBySegment.@class;

                                    IncludedCheckedBagsDB IncludedCheckedBagsDBObj = new IncludedCheckedBagsDB();
                                    IncludedCheckedBagsDBObj.weight = FareDetailsBySegment.includedCheckedBags.weight;
                                    IncludedCheckedBagsDBObj.weightUnit = FareDetailsBySegment.includedCheckedBags.weightUnit;

                                    FareDetailsBySegmentDBObj.includedCheckedBags = IncludedCheckedBagsDBObj;
                                    FareDetailsBySegmentDBList.Add(FareDetailsBySegmentDBObj);

                                }

                                TravelerPricingDBObj.fareDetailsBySegment = FareDetailsBySegmentDBList;
                                TravelerPricingDBList.Add(TravelerPricingDBObj);
                            }
                            DatumDBObj.travelerPricings = TravelerPricingDBList;
                            DatumDBList.Add(DatumDBObj);
                        }

                        FlightOffersSearchDBObj.data = DatumDBList;
                        DictionariesDB DictionariesDBObjI = new DictionariesDB();
                        List<AircraftsDB> AircraftsDBList = new List<AircraftsDB>();
                        List<CurenciesDB> CurenciesDBList = new List<CurenciesDB>();
                        List<CarriersDB> CarriersDBList = new List<CarriersDB>();

                        foreach (KeyValuePair<string, string> entry in FlightOffersSearchRS.dictionaries.Aircraft)
                        {
                            AircraftsDB AircraftsDBObj = new AircraftsDB();
                            AircraftsDBObj.Details = entry.Key + "_ " + entry.Value;
                            AircraftsDBList.Add(AircraftsDBObj);
                        }

                        DictionariesDBObjI.Aircraft = AircraftsDBList;

                        foreach (KeyValuePair<string, string> entry in FlightOffersSearchRS.dictionaries.Currencies)
                        {
                            CurenciesDB CurenciesDBObj = new CurenciesDB();
                            CurenciesDBObj.Details = entry.Key + "_ " + entry.Value;
                            CurenciesDBList.Add(CurenciesDBObj);
                        }

                        DictionariesDBObjI.Currencies = CurenciesDBList;


                        foreach (KeyValuePair<string, string> entry in FlightOffersSearchRS.dictionaries.Carriers)
                        {
                            CarriersDB CarriersDBObj = new CarriersDB();
                            CarriersDBObj.Details = entry.Key + " _ " + entry.Value;
                            CarriersDBList.Add(CarriersDBObj);

                        }
                        DictionariesDBObjI.Carriers = CarriersDBList;
                        FlightOffersSearchDBObj.dictionaries = DictionariesDBObjI;

                        _DatabaseContext.Add<FlightOffersSearchDB>(FlightOffersSearchDBObj);
                        _DatabaseContext.SaveChanges();


                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
            }
            return true;
        }
    }
}

