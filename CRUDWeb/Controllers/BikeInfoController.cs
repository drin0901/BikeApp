using Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {
            IEnumerable<BikeInfo> BikeInfoList;
            response = await GlobalVariables.WebApiClient.GetAsync("GetBikeInfoList");
            BikeInfoList = await response.Content.ReadAsAsync<IEnumerable<BikeInfo>>();

            return View(BikeInfoList);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id = 0)
        {
            if (id == 0)
            {
                return View(new BikeInfo());
            }
            else
            {
                response = await GlobalVariables.WebApiClient.GetAsync("GetBikeInfo?id=" + id);
                return View( await response.Content.ReadAsAsync<BikeInfo>());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(BikeInfo obj)
        {
            if (obj.Id == null)
            {
                response = await GlobalVariables.WebApiClient.PostAsJsonAsync("AddBikeInfo", obj);
                TempData["SuccessMessage"] = "Record Saved Successfully!";
            }
            else
            {
                response = await GlobalVariables.WebApiClient.PutAsJsonAsync("EditBikeInfo", obj);
                TempData["SuccessMessage"] = "Record Updated Successfully!";
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            response = await GlobalVariables.WebApiClient.DeleteAsync("DeleteBikeInfo?id="+id);
            TempData["SuccessMessage"] = "Record Deleted Successfully!";

            return RedirectToAction("Index");
        }
    }
}
