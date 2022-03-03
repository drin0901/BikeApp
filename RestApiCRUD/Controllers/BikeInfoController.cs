using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.BikeInfoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeInfoController : ControllerBase
    {
        private IBikeInfoData _bikeInfoData;
        
        public BikeInfoController(IBikeInfoData BikeInfoData)
        {
            _bikeInfoData = BikeInfoData;
        }

        [HttpGet("GetBikeInfoList")]
        public IActionResult GetBikeInfoList()
        {
            return Ok(_bikeInfoData.GetBikeInfoList());
        }

        [HttpGet("GetBikeInfo")]
        public IActionResult GetBikeInfoById(int id)
        {

            var BikeInfo = _bikeInfoData.GetBikeInfo(id);

            if (BikeInfo != null)
            {
                return Ok(BikeInfo);
            }

            return NotFound($"Client with Id: {id} was not found");

        }

        [HttpPost("AddBikeInfo")]
        public IActionResult AddBikeInfo(BikeInfo obj)
        {

            _bikeInfoData.AddBikeInfo(obj);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + obj.Id, obj);

        }

        [HttpPut("EditBikeInfo")]
        public IActionResult EditBikeInfo(BikeInfo obj)
        {
            if (obj != null)
            {
                _bikeInfoData.EditBikeInfo(obj);
                return Ok(obj);
            }

            return NotFound($"Client with Id: {obj.Id} was not found");

        }

        [HttpDelete("DeleteBikeInfo")]
        public IActionResult DeleteBikeInfo(int id)
        {

            var BikeInfo = _bikeInfoData.GetBikeInfo(id);

            if (BikeInfo != null)
            {
                BikeInfo.IsActive = false;
                _bikeInfoData.DeleteBikeInfo(BikeInfo);
                return Ok();
            }

            return NotFound($"Client with Id: {id} was not found");

        }

    }
}
