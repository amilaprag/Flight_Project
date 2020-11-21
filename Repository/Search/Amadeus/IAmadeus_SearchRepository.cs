using Flight_Project.Models.Amadeus.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Project.Repository.Search.Amadeus
{
    public interface IAmadeus_SearchRepository
    {
        public FlightOffersSearchRS FlightOffersSearch(string SearchString);
    }
}
