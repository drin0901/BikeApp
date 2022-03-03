using Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        [BindProperty]
        public Register Model { get; set; }

        public RegisterController(
            UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {

            PopulateRole();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            PopulateRole();

            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = Model.Email,
                    Email = Model.Email
                };

                var result = await userManager.CreateAsync(user, Model.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Model.RoleName);
                    await signInManager.SignInAsync(user, false);
                    TempData["SuccessMessage"] = "Record Saved Successfully!";
                    return View("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            TempData["SuccessMessage"] = "Unable to Save Records!";
            return View("Index");
        }

        public void PopulateRole()
        {
            List<SelectListItem> roleList = new List<SelectListItem>();

            foreach (var role in roleManager.Roles)
            {
                roleList.Add(new SelectListItem() { Value = role.Name, Text = role.Name });
            }

            ViewBag.Roles = roleList;
        }
    }
}
