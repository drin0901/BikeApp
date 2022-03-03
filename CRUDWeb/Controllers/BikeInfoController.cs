using Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Web.Controllers
{
    [Authorize]
    public class BikeInfoController : Controller
    {
        
        private HttpResponseMessage response;
        public BikeInfoController()
        {
            response = new HttpResponseMessage();
        }

        public IActionResult Index()
        {
            IEnumerable<BikeInfo> BikeInfoList;
            response = GlobalVariables.WebApiClient.GetAsync("GetBikeInfoList").Result;
            BikeInfoList = response.Content.ReadAsAsync<IEnumerable<BikeInfo>>().Result;

            return View(BikeInfoList);
        }

        [HttpGet]
        public IActionResult Create(int id = 0)
        {
            try
            {
                if (id == 0)
                {
                    return View(new BikeInfo());
                }
                else
                {
                    response = GlobalVariables.WebApiClient.GetAsync("GetBikeInfo?id=" + id).Result;
                    return View(response.Content.ReadAsAsync<BikeInfo>().Result);
                }
            }
            catch (Exception ex)
            {

            }

            return View();
        }

        [HttpPost]
        public IActionResult Create(BikeInfo obj)
        {
            if (obj.Id == null)
            {
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("AddBikeInfo", obj).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully!";
            }
            else
            {
                response = GlobalVariables.WebApiClient.PutAsJsonAsync("EditBikeInfo", obj).Result;
                TempData["SuccessMessage"] = "Record Updated Successfully!";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            response = GlobalVariables.WebApiClient.DeleteAsync("DeleteBikeInfo?id="+id).Result;
            TempData["SuccessMessage"] = "Record Deleted Successfully!";

            return RedirectToAction("Index");
        }
    }
}
