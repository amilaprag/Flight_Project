using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Project.Models.Amadeus.Authorization
{
    public class AuthorizationRSModel
    {
        public string Type { get; set; }
        public string Username { get; set; }
        public string Application_Name { get; set; }
        public string Client_Id { get; set; }
        public string Token_Type { get; set; }
        public string Access_Token { get; set; }
        public int Expires_In { get; set; }
        public string State { get; set; }
        public string Scope { get; set; }
    }
}
