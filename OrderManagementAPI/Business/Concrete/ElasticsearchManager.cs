using Business.Abstract;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Entities.Concrete;
using Business.Mapping;
using System.Linq;

namespace Business.Concrete
{
    public class ElasticsearchManager : IElasticsearchService
    {
        private readonly IConfiguration _configuration;
        private readonly IElasticClient _client;
        public ElasticsearchManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = CreateInstance();
        }
        private ElasticClient CreateInstance()
        {
            string host = _configuration.GetSection("ElasticsearchServer:Host").Value;
            string port = _configuration.GetSection("ElasticsearchServer:Port").Value;
            string username = _configuration.GetSection("ElasticsearchServer:Username").Value;
            string password = _configuration.GetSection("ElasticsearchServer:Password").Value;
            var settings = new ConnectionSettings(new Uri(host + ":" + port));
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                settings.BasicAuthentication(username, password);

            return new ElasticClient(settings);
        }
        public async Task ChekIndex(string indexName)
        {
            var anyy = await _client.Indices.ExistsAsync(indexName);
            if (anyy.Exists)
                return;

            var response = await _client.Indices.CreateAsync(indexName,
                ci => ci
                    .Index(indexName)
                    .ProductMapping()
                    .Settings(s => s.NumberOfShards(3).NumberOfReplicas(1))
                    );

            return;
        }
        public async Task DeleteIndex(string indexName)
        {
            await _client.Indices.DeleteAsync(indexName);
        }
        public async Task<Product> GetDocument(string indexName, string id)
        {
            var response = await _client.GetAsync<Product>(id, q => q.Index(indexName));
            return response.Source;
        }
        public async Task<List<Product>> GetDocuments(string indexName)
        {

            var response = await _client.SearchAsync<Product>(s => s
                                  .Index(indexName)
                                .Size(10000)
                                .Query(q => q
                                .Match(m => m.Field("name").Query("palto")
                                 )));

            return response.Documents.ToList();
        }
        public async Task InsertDocument(string indexName, Product product)
        {
            var response = await _client.CreateAsync(product, q => q.Index(indexName));
            if (response.ApiCall?.HttpStatusCode == 409)
            {
                await _client.UpdateAsync<Product>(product.Id, a => a.Index(indexName).Doc(product));
            }
        }
        public async Task InsertBulkDocuments(string indexName, List<Product> product)
        {
            await _client.IndexManyAsync(product, index: indexName);
        }
        public async Task DeleteByIdDocument(string indexName, Product product)
        {
            var response = await _client.CreateAsync(product, q => q.Index(indexName));
            if (response.ApiCall?.HttpStatusCode == 409)
            {
                await _client.DeleteAsync(DocumentPath<Product>.Id(product.Id).Index(indexName));
            }
        }
    }
}
