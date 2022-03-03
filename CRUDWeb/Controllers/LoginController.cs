using Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        [BindProperty]
        public Login Model { get; set; }

        public LoginController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login()
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false);
                if (result.Succeeded)
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
