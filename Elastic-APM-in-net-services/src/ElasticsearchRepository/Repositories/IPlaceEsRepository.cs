using System.Collections.Generic;
using ElasticsearchRepository.Entities;

namespace ElasticsearchRepository.Repositories
{
    public interface IPlaceEsRepository
    {
        void CreateIndexIfNotExists();
        IEnumerable<PlaceEs> SearchPlaces(string query, int limit = 10);
        void AddPlace(PlaceEs place);
    }
}