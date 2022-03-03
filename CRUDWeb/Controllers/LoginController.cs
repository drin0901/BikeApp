using Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Login Model { get; set; }

        public LoginController(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login()
        {
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false);
                if (result.Result.Succeeded)
                {
                    TempData["SuccessMessage"] = "Login Successfully! Welcome to Bike Rental Management";
                    return RedirectToAction("Index","BikeInfo");
                }
                else
                {
                    ModelState.AddModelError("","Username or Password is incorrect.");
                }
            }

            return View("Index");
        }
    }
}
