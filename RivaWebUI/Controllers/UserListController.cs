using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Riva.EntityLayer.Entities;

namespace RivaWebUI.Controllers
{
    public class UserListController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserListController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync(); 
            return View(users);
        }
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
           
                return RedirectToAction("Index", "UserList");
            }
            else
            {
                
                return RedirectToAction("Index", "UserList");
            }
        }
    }
}
