using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Create an Order
        /// If you are not authorized, you cannot perform this action. Create user or sign in
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost("add")]
        //[Authorize]
        public IActionResult Add(Order order)
        {
            var result = _orderService.Add(order);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        /// <summary>
        /// Update the Order
        /// If you are not authorized, you cannot perform this action. Create user or sign in
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost("update")]
        [Authorize]
        //[Authorize(Roles = "Product.List")]
        public IActionResult Update(Order order)
        {
            var result = _orderService.Update(order);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        /// <summary>
        /// Delete the Order
        /// If you are not authorized, you cannot perform this action. Create user or sign in
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>

        [HttpPost("delete")]
        [Authorize]
        public IActionResult Delete(Order order)
        {
            var result = _orderService.Delete(order);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        /// <summary>
        ///  Get All Orders
        ///  If you are not authorized, you cannot perform this action. Create user or sign in
        /// </summary>
        /// <returns></returns>
        [HttpGet("getall")]
        [Authorize]
        public IActionResult GetAll()
        {
            var result = _orderService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        /// <summary>
        /// Get Order By Id
        /// If you are not authorized, you cannot perform this action. Create user or sign in
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpGet("getbyid")]
        [Authorize]
        public IActionResult GetById(int orderId)
        {
            var result = _orderService.GetById(orderId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
