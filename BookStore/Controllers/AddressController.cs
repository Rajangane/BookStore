using BusinessLayer.Interfaces;
using CommomLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        IAddressBL addressBL;

        public AddressController(IAddressBL addressBL)
        {
            this.addressBL = addressBL;
        }

        [HttpPost]
        [Route("addAddress")]

        public IActionResult AddAddress([FromBody] AddressModel address)
        {
            try
            {
                string result = this.addressBL.AddAddress(address);
                if (result.Equals("Address Added succssfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("updateAddress")]

        public IActionResult UpdateAddress([FromBody] AddressModel address)
        {
            try
            {
                string result = this.addressBL.UpdateAddress(address);
                if (result.Equals("Address updated succssfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("getAllAddress")]
        public IActionResult GetAllAddresses()
        {
            try
            {
                var result = this.addressBL.GetAllAddresses();
                if (result != null)
                {
                    return this.Ok(new ResponseModel<object>() { Status = true, Message = "Retrieval all addresses succssful", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Retrieval is unsucessful" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        //Getting address by userid api
        [HttpGet]
        [Route("getAddressbyUserid")]
        public IActionResult GetAddressesbyUserid(int userId)
        {
            try
            {
                var result = this.addressBL.GetAddressesbyUserid(userId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<object>() { Status = true, Message = "Retrieval all addresses succssful", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Userid not Exist" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

    }
}
