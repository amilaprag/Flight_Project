using Flight_Project.Models.Amadeus.Authorization;
using Flight_Project.Models.Amadeus.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Flight_Project.Repository.Authorization.Amadeus
{
    public class Amadeus_AuthorizationRepository : IAmadeus_AuthorizationRepository
    {
        private readonly IConfiguration _Configuration;
        private readonly ILogger<Amadeus_AuthorizationRepository> _Logger;

        public Amadeus_AuthorizationRepository(IConfiguration Configuration, ILogger<Amadeus_AuthorizationRepository> Logger)
        {
            _Configuration = Configuration;
            _Logger = Logger;
        }


        public string Authorization()
        {
            string Env = "Test";
            try
            {
                 Dictionary<string, string> Params = new Dictionary<string, string>();
                 Params.Add("client_id", _Configuration["AmadeusConfiguration:"+ Env + ":ClientId"]);
                 Params.Add("client_secret", _Configuration["AmadeusConfiguration:Test:ClientSecret"]);
                 Params.Add("grant_type", _Configuration["AmadeusConfiguration:Test:GrantType"]);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_Configuration["AmadeusConfiguration:Test:BaseUri"]);
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");

                    var postTask = client.PostAsync("v1/security/oauth2/token", new FormUrlEncodedContent(Params));
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        AuthorizationRSModel AuthorizationRSModelObj = JsonConvert.DeserializeObject<AuthorizationRSModel>(result.Content.ReadAsStringAsync().Result);
                        return AuthorizationRSModelObj.Access_Token;
                    }

                }
            }
            catch (Exception Error)
            {
                _Logger.LogError("Autherization Error",Error);
                return null;
            }
            _Logger.LogError("return finally null block");
            return null;
        }
    }
}
