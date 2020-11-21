using Flight_Project.Models.Amadeus.Search;
using Flight_Project.Models.Common;
using Flight_Project.SupplierConnecter.Amadeus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Flight_Project.Repository.Search.Amadeus
{
    public class Amadeus_SearchRepository : IAmadeus_SearchRepository
    {
        private readonly IAmadeusConnecter _IAmadeusConnecterCaller;
        public Amadeus_SearchRepository(IAmadeusConnecter IAmadeusConnecterCaller)
        {
            _IAmadeusConnecterCaller = IAmadeusConnecterCaller;
        }
        public FlightOffersSearchRS FlightOffersSearch(string SearchString)
        {
            FlightOffersSearchRS FlightOffersSearchRSObj  = new FlightOffersSearchRS();
            try
            {
                #region Calling to Supplier
                FlightOffersSearchRSObj = JsonConvert.DeserializeObject<FlightOffersSearchRS>((string)_IAmadeusConnecterCaller.HttpGetCall(SearchString));
                return FlightOffersSearchRSObj;
                #endregion
            }
            catch (Exception)
            {
                return FlightOffersSearchRSObj;
            }
        }
    }
}
