using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Riva.EntityLayer.Entities;
using RivaWebUI.Dtos.IdentityDtos;

namespace RivaWebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto registerDto)
        {
            var appUser = new AppUser()
            {
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Email = registerDto.Mail,
                UserName = registerDto.Name
            };

            var result = await _userManager.CreateAsync(appUser, registerDto.Password);

            if (result.Succeeded)
            {
            
                await _userManager.AddToRoleAsync(appUser, "user");

                TempData["SuccessMessage"] = "Kayıt başarıyla yapıldı.👍";
                return RedirectToAction("Index", "Default");
            }

            TempData["DangerMessage"] = "Kayıt Sırasında Bir Hata Oluştu.Lütfen Başka Bir Adla Kayıt OLmayı Deneyiniz🤔";
            return RedirectToAction("Index", "Default");
        }

    }
}
