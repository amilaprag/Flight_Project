using Flight_Project.Models.Amadeus.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Project.Repository.Authorization.Amadeus
{
    public interface IAmadeus_AuthorizationRepository
    {
        public string Authorization();
    }
}
