using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Role obj)
        {
            var existingRole = await roleManager.RoleExistsAsync(obj.RoleName);

            if (!existingRole)
            {
                await roleManager.CreateAsync( new IdentityRole(obj.RoleName));
                TempData["SuccessMessage"] = "Record Saved Successfully!";
                return View("Index");
            }
            else
            {
                ModelState.AddModelError("", "Role Name already Exists!, Please Input New Role");
                return View("Index");
            }

            
        }
    }
}
