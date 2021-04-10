using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseRepository.EfCore;

namespace DatabaseRepository.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly PlaceContext placeContext;

        public PlaceRepository(PlaceContext placeContext)
        {
            this.placeContext = placeContext;
        }
        
        public void AddPlace(Place place)
        {
            if (place == null)
            {
                throw new ArgumentNullException(nameof(place));
            }
            
            placeContext.Places.Add(place);

            placeContext.SaveChanges();
        }

        public IList<Place> SearchPlace(string query, int limit = 10)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentNullException(nameof(query));
            }
            
            return placeContext.Places
                .Where(w => w.Name.ToLower().Contains(query.ToLower()))
                .Take(limit)
                .ToList();
        }
    }
}