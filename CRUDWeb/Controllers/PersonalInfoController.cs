using CRUDWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace CRUDWeb.Controllers
{
    [Authorize]
    public class PersonalInfoController : Controller
    {
        
        private HttpResponseMessage response;
        public PersonalInfoController()
        {
            response = new HttpResponseMessage();
        }

        public IActionResult Index()
        {
            IEnumerable<PersonalInfo> personalInfoList;
            response = GlobalVariables.WebApiClient.GetAsync("GetPersonalInfoList").Result;
            personalInfoList = response.Content.ReadAsAsync<IEnumerable<PersonalInfo>>().Result;

            return View(personalInfoList);
        }

        [HttpGet]
        public IActionResult Create(int id = 0)
        {
            try
            {
                if (id == 0)
                {
                    return View(new PersonalInfo());
                }
                else
                {
                    response = GlobalVariables.WebApiClient.GetAsync("GetPersonalInfo?id=" + id).Result;
                    return View(response.Content.ReadAsAsync<PersonalInfo>().Result);
                }
            }
            catch (Exception ex)
            {

            }

            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonalInfo obj)
        {
            if (obj.Id == null)
            {
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("AddPersonalInfo", obj).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully!";
            }
            else
            {
                response = GlobalVariables.WebApiClient.PutAsJsonAsync("EditPersonalInfo", obj).Result;
                TempData["SuccessMessage"] = "Record Updated Successfully!";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            response = GlobalVariables.WebApiClient.DeleteAsync("DeletePersonalInfo?id="+id).Result;
            TempData["SuccessMessage"] = "Record Deleted Successfully!";

            return RedirectToAction("Index");
        }
    }
}
