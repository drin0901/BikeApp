using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class LogoutController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;

        public LogoutController(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            TempData["SuccessMessage"] = "Logged Out Successfully! Thank you for using our App";
            return RedirectToAction("Index","Login");
        }
    }
}
