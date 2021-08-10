using Businness.Abstract;

using Entities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TesodevChallangeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
}

        [HttpPost("createOrder")]
        [Authorize(Roles = "Customer.CreateOrder")]
        public ActionResult CreateOrder(Order order)
        {
            var orderCheck = _orderService.Get(order.Id);
            if (orderCheck!=null)
            {
                return BadRequest("This Order Id Has Using!");
            }
            var result = _orderService.Add(order);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("updateOrder")]
        [Authorize(Roles = "Customer.UpdateOrder")]
        public ActionResult UpdateOrder(Order order)
        {
            var result = _orderService.Update(order);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("deleteOrder")]
        [Authorize(Roles = "Customer.DeleteOrder")]
        public ActionResult DeleteOrder(Order order)
        {
            var result = _orderService.Delete(order);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("get")]
        [Authorize(Roles = "Customer.GetOrder")]
        public ActionResult GetOrder(string orderId)
        {
            var result = _orderService.Get(orderId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getorderlistbyid")]
        [Authorize(Roles = "Customer.GetOrderListById")]
        public ActionResult GetOrderListById(string id)
        {
            var result = _orderService.GetListById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getlist")]
        [Authorize(Roles = "Customer.GetList")]
        public ActionResult GetList()
        {
            var result = _orderService.GetList();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("changestatus")]
        [Authorize(Roles = "Customer.ChangeStatus")]
        public ActionResult ChangeStatus(string id, string state)
        {
            var result = _orderService.ChangeStatus(id, state);
            if (result==null)
            {
                return BadRequest("This Order by id has not found!");
            }
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
