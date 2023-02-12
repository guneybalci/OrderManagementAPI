using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();

        // Category ID'ye göre ürünleri getir
        IDataResult<List<Product>> GetAllByCategoryId(int id);

        // Şu Fiyat Aralığında Olan Ürünleri Getir
        IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max);

        IDataResult<List<ProductDetailDto>> GetProductDetails();

        // Tek bir ürünle ilgili bilgiler
        IDataResult<Product> GetById(int productId);

        IResult Add(Product product);

        IResult Update(Product product);
    }
}
