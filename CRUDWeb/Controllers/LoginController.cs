using CRUDWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWeb.Controllers
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
                    return RedirectToAction("Index","PersonalInfo");
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
