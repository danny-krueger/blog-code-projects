using System;
using System.Collections.Generic;
using Elasticsearch.Net;
using ElasticsearchRepository.Entities;
using Nest;

namespace ElasticsearchRepository.Repositories
{
    public class PlaceEsRepository : IPlaceEsRepository
    {
        private const string IndexName = "places";
        private readonly IElasticClient client;

        public PlaceEsRepository(string elasticsearchUrl)
        {
            var connectionPool = new SingleNodeConnectionPool(new Uri(elasticsearchUrl));

            ConnectionSettings settings = new ConnectionSettings(connectionPool);
            settings.DisableDirectStreaming();
            settings.ThrowExceptions();
            
            client = new ElasticClient(settings);
        }

        public void CreateIndexIfNotExists()
        {
            if (client.Indices.Exists(IndexName).Exists)
            {
                return;
            }

            client.Indices
                .Create(IndexName, c => c
                    .Map<PlaceEs>(m => m.AutoMap())
                );
        }

        public IEnumerable<PlaceEs> SearchPlaces(string query, int limit = 10)
        {
            var results = client.Search<PlaceEs>(s => s
                .Index(IndexName)
                .Take(limit)
                .Query(q => q.Bool(b => b.Should(sh => sh
                    .QueryString(qs => qs
                        .Fields(fs => fs
                            .Field(f => f.Name)
                            .Field(f => f.DisplayName)
                            .Field(f => f.Address.Zip)
                            .Field(f => f.Address.City)
                            .Field(f => f.Address.Street)
                            .Field(f => f.Address.HouseNumber)
                            .Field(f => f.Address.Country)
                        )
                        .Query(query))
                )))
            );

            return results.Documents;
        }

        public void AddPlace(PlaceEs place)
        {
            client.Index(place, s => s.Index(IndexName).Refresh(Refresh.True));
        }
    }
}