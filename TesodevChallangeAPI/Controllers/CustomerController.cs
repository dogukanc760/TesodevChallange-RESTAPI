using Businness.Abstract;

using Entities.Concrete;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesodevChallangeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("update")]
        [Authorize(Roles ="Customer.Update")]
        public ActionResult Update(Customer customer)
        {
            var checkToUser = _customerService.UserExist(customer.Email);
            if (checkToUser)
            {
                _customerService.Update(customer);
                return Ok("Updated Successfull!");
            }
            return BadRequest("User Not Found!");
           
            
        }

        [HttpPost("delete")]
        [Authorize(Roles = "Customer.Delete")]
        public ActionResult Delete(Customer customer)
        {
            var checkToUser = _customerService.UserExist(customer.Email);
            if (checkToUser)
            {
                _customerService.Delete(customer);
                return Ok("Delete Successfull!");
            }
            return BadRequest("User Not Found!");
        }

        [HttpGet("get")]
        [Authorize(Roles = "Customer.Get")]
        public ActionResult Get(string id)
        {
            var result = _customerService.GetUser(id);
            if (result.Email!=null)
            {
                return Ok(result);
            }
            return BadRequest("User Has Not Found!");
        }

        [HttpGet("getbymail")]
        [Authorize(Roles = "Customer.GetByMail")]
        public ActionResult GetByMail(string mail)
        {
            var result = _customerService.GetByMail(mail);
            
            if (result.Email != null)
            {
                return Ok(result);
            }
            return BadRequest("User Has Not Found!");
        }

        [HttpGet("getall")]
        [Authorize(Roles = "Customer.GetAll")]
        public ActionResult GetAll()
        {
            var result = _customerService.GetAll();

            if (result.Count>0)
            {
                return Ok(result);
            }
            return BadRequest("User Has Not Found!");
        }

    }
}
