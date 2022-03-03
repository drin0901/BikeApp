using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiCRUD.Models;
using RestApiCRUD.PersonalInfoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInfoController : ControllerBase
    {
        private IPersonalInfoData _personalInfoData;
        
        public PersonalInfoController(IPersonalInfoData personalInfoData)
        {
            _personalInfoData = personalInfoData;
        }

        [HttpGet("GetPersonalInfoList")]
        public IActionResult GetPersonalInfoList()
        {
            return Ok(_personalInfoData.GetPersonalInfoList());
        }

        [HttpGet("GetPersonalInfo")]
        public IActionResult GetPersonalInfoById(int id)
        {

            var personalInfo = _personalInfoData.GetPersonalInfo(id);

            if (personalInfo != null)
            {
                return Ok(personalInfo);
            }

            return NotFound($"Client with Id: {id} was not found");

        }

        [HttpPost("AddPersonalInfo")]
        public IActionResult AddPersonalInfo(PersonalInfo obj)
        {

            _personalInfoData.AddPersonalInfo(obj);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + obj.Id, obj);

        }

        [HttpPut("EditPersonalInfo")]
        public IActionResult EditPersonalInfo(PersonalInfo obj)
        {
            if (obj != null)
            {
                _personalInfoData.EditPersonalInfo(obj);
                return Ok(obj);
            }

            return NotFound($"Client with Id: {obj.Id} was not found");

        }

        [HttpDelete("DeletePersonalInfo")]
        public IActionResult DeletePersonalInfo(int id)
        {

            var personalInfo = _personalInfoData.GetPersonalInfo(id);

            if (personalInfo != null)
            {
                personalInfo.IsActive = false;
                _personalInfoData.DeletePersonalInfo(personalInfo);
                return Ok();
            }

            return NotFound($"Client with Id: {id} was not found");

        }

    }
}
