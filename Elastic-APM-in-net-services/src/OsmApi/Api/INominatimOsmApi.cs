using System.Collections.Generic;
using SharedLib.Entities.OsmApi;

namespace OsmApi.Api
{
    public interface INominatimOsmApi
    {
        IList<OsmPlace> SearchOsmPlaces(string query, int limit = 10);
    }
}