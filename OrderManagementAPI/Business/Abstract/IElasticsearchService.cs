using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IElasticsearchService
    {
        Task ChekIndex(string indexName);
        Task InsertDocument(string indexName, Product product);
        Task DeleteIndex(string indexName);
        Task DeleteByIdDocument(string indexName, Product product);
        Task InsertBulkDocuments(string indexName, List<Product> product);
        Task<Product> GetDocument(string indexName, string id);
        Task<List<Product>> GetDocuments(string indexName);
    }
}
