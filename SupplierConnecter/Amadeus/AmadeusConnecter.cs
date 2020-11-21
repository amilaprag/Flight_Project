using Flight_Project.Models.Amadeus.Authorization;
using Flight_Project.Models.Common;
using Flight_Project.Repository.Authorization.Amadeus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Flight_Project.SupplierConnecter.Amadeus
{
    public class AmadeusConnecter : IAmadeusConnecter
    {
        private readonly ILogger<AmadeusConnecter> _logger;
        private readonly IAmadeus_AuthorizationRepository _IAmadeus_AuthorizationRepository;

        public AmadeusConnecter(ILogger<AmadeusConnecter> logger,IAmadeus_AuthorizationRepository IAmadeus_AuthorizationRepository)
        {
            _IAmadeus_AuthorizationRepository = IAmadeus_AuthorizationRepository;
            _logger = logger;
        }

        public string HttpGetCall(string SearchString)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var token= _IAmadeus_AuthorizationRepository.Authorization();

                    client.BaseAddress = new Uri("https://test.api.amadeus.com/v2/shopping/");
                    string tokenfinal = "Bearer "+token;
                    client.DefaultRequestHeaders.Add("Authorization", tokenfinal);

                    var responseTask = client.GetAsync(SearchString);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                         var response = result.Content.ReadAsStringAsync().Result;
                      //  _logger.LogDebug("response" + response);
                        return response;
                    }
                }
            }
            catch (Exception ErrorMessage)
            {
                _logger.LogError("return null with exeception",ErrorMessage);
                return null;
            }
            _logger.LogDebug("return null as finally");
            return null;
        }
    }

}
