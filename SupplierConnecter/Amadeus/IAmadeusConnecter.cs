using Flight_Project.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Project.SupplierConnecter.Amadeus
{
    public interface IAmadeusConnecter
    {
        public string HttpGetCall(string SearchString);
    }

}
