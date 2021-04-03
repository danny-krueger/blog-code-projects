using System.Collections.Generic;
using OsmApi.Entities;

namespace OsmApi.Api
{
    public interface INominatimOsmApi
    {
        IList<OsmPlace> SearchOsmPlaces(string query, int limit = 10);
    }
}