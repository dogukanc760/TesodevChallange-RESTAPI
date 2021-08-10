using Businness.Abstract;

using Entities;
using Entities.Concrete;

using Microsoft.AspNetCore.Authorization;
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
    public class OrderContentController:ControllerBase
    {
        private IOrderContentService _orderContent;
        public OrderContentController(IOrderContentService orderContent)
{
            _orderContent = orderContent;
        }

        [HttpPost("Add")]
        [Authorize(Roles = "Content.Add")]
        public ActionResult Add(OrderContent order)
        {
            var checkOrder = _orderContent.Get(order.OrderId);
            if (checkOrder==null)
            {
                return BadRequest("This Main Order Create Not Yet, You First Create Main Order!");
            }
            if (checkOrder.Data.ProductId == order.ProductId)
            {
                checkOrder.Data.Quantity += order.Quantity;
                _orderContent.Update(order);
                return Ok("Product Quantity Added!");
            }
            var result = _orderContent.Add(order);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Update")]
        [Authorize(Roles = "Content.Update")]
        public ActionResult Update(OrderContent order)
        {
            var orderToCheck = _orderContent.Get(order.Id);
            if (orderToCheck==null)
            {
                return BadRequest("Order not found!");
            }
            var result = _orderContent.Update(order);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        [Authorize(Roles = "Content.Delete")]
        public ActionResult Delete(OrderContent order)
        {
            var orderToCheck = _orderContent.Get(order.Id);
            if (orderToCheck == null)
            {
                return BadRequest("Order not found!");
            }
            var result = _orderContent.Delete(order);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("getlist")]
        [Authorize(Roles = "Content.GetList")]
        public ActionResult GetList(OrderContent order)
        {

            var result = _orderContent.GetList();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("get")]
        [Authorize(Roles = "Content.Get")]
        public ActionResult Get(string id)
        {

            var result = _orderContent.Get(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("getlistbyid")]
        [Authorize(Roles = "Content.GetListById")]
        public ActionResult GetListById(string id)
        {

            var result = _orderContent.GetListById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
