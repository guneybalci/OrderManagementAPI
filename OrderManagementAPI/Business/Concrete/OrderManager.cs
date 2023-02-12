using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;
        private IProductOrderService _productOrderService;
        public OrderManager(IOrderDal orderDal, IProductOrderService productOrderService)
        {
            _orderDal = orderDal;
            _productOrderService = productOrderService;
        }

        [LogAspect(typeof(FileLogger))]
        //[SecuredOperation("customer")]
        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            ProductOrder po;
            po = new ProductOrder { OrderId = order.Id, ProductId = order.ProductId };
            _productOrderService.Add(po);
            return new SuccessResult(Messages.OrderAdded);
        }

        [LogAspect(typeof(FileLogger))]
        //[SecuredOperation("customer")]
        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult(Messages.OrderDeleted);
        }

        [LogAspect(typeof(FileLogger))]
        //[SecuredOperation("customer")]
        public IDataResult<Order> GetById(int orderId)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(o=>o.Id == orderId));
        }

        [LogAspect(typeof(FileLogger))]
        //[SecuredOperation("customer")]
        public IDataResult<List<Order>> GetList()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll());
        }

        [LogAspect(typeof(FileLogger))]
        //[SecuredOperation("customer")]
        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult(Messages.OrderUpdated);
        }
    }
}
