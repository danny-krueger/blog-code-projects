using System.Collections.Generic;
using DatabaseRepository.EfCore;

namespace DatabaseRepository.Repositories
{
    public interface IPlaceRepository
    {
        void AddPlace(Place place);
        IList<Place> SearchPlace(string query, int limit = 10);
    }
}