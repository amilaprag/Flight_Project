using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Project.Models.Amadeus.Authorization
{
    public class AuthorizationRQModel
    {
        public string Grant_Type { get; set;}

        public string Client_Id { get; set; }

        public string Client_Secret { get; set; }
    }
}
