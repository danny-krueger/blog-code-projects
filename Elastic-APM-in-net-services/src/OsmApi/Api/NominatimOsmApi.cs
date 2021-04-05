using System.Collections.Generic;
using RestSharp;
using SharedLib.Entities.OsmApi;

namespace OsmApi.Api
{
    public class NominatimOsmApi : INominatimOsmApi
    {
        private const string NominatimOsmBaseUrl = "https://nominatim.openstreetmap.org";
        
        private readonly RestClient client;

        public NominatimOsmApi()
        {
            client = new RestClient(NominatimOsmBaseUrl);
            client.AddDefaultHeader("accept-language", "en-US");
        }

        public IList<OsmPlace> SearchOsmPlaces(string query, int limit = 10)
        {
            string queryCleaned = query.Replace(" ", "+");
            
            IRestRequest request = new RestRequest("", DataFormat.Json)
                .AddParameter("addressdetails", "1")
                .AddParameter("namedetails", "1")
                .AddParameter("format", "json")
                .AddParameter("limit", limit.ToString())
                .AddParameter("q", queryCleaned, ParameterType.QueryStringWithoutEncode);

            IRestResponse<IList<OsmPlace>> response = client.Get<IList<OsmPlace>>(request);
            return response.Data;
        }
    }
}