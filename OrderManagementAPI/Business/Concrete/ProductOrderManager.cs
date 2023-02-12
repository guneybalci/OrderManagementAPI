using Business.Abstract;
using Business.Constants;
using Castle.Core.Resource;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductOrderManager : IProductOrderService
    {
        IProductOrderDal _productOrderDal;

        public ProductOrderManager(IProductOrderDal productOrderDal)
        {
            _productOrderDal= productOrderDal;
        }
        public IResult Add(ProductOrder productOrder)
        {
            _productOrderDal.Add(productOrder);
            return new SuccessResult("Database Güncellendi");
        }

        public IResult Delete(ProductOrder productOrder)
        {
            _productOrderDal.Delete(productOrder);
            return new SuccessResult("Database Güncellendi");
        }

        public IResult Update(ProductOrder productOrder)
        {
            _productOrderDal.Update(productOrder);
            return new SuccessResult("Database Güncellendi");
        }
    }
}
