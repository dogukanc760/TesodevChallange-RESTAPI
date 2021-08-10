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
    public class AddressController : ControllerBase
    {
        private IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost("update")]
        [Authorize(Roles = "Adres.Update")]
        public ActionResult Update(Address address)
        {
            var result = _addressService.Update(address);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("delete")]
        [Authorize(Roles = "Adres.Delete")]
        public ActionResult Delete(Address address)
        {
            var result = _addressService.Delete(address);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("add")]
        [Authorize(Roles = "Adres.Add")]
        public ActionResult Add(Address address)
        {
            var result = _addressService.Add(address);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }

        [HttpGet("GetAll")]
        [Authorize(Roles = "Adres.GetAll")]
        public ActionResult GetAll()
        {
            var result = _addressService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }

        [HttpGet("GetAllByCustomer")]
        [Authorize(Roles = "Adres.GetAllByCustomer")]
        public ActionResult GetAllByCustomer(string id)
        {
            var result = _addressService.GetAllByCustomer(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }

        [HttpGet("bycustomeraddress")]
        [Authorize(Roles = "Adres.GetAddressByCustomer")]
        public ActionResult GetAddressByCustomer(string id)
        {
            var result = _addressService.GetAddressByCustomer(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }
    }
}
