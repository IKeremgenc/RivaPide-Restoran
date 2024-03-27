using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Riva.EntityLayer.Entities;
using RivaWebUI.Dtos.IdentityDtos;

namespace RivaWebUI.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;
		public LoginController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}


		[HttpPost]
		public async Task<IActionResult> Index(LoginDto loginDto)
		{
			var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);
			if (result.Succeeded)
			{
				var user = await _signInManager.UserManager.FindByNameAsync(loginDto.Username);
				if (await _signInManager.UserManager.IsInRoleAsync(user, "Admin"))
				{
					TempData["SuccessMessage"] = "Girş başarıyla yapıldı.👍";
					return RedirectToAction("Index", "Category"); 
				}
                if (await _signInManager.UserManager.IsInRoleAsync(user, "User"))
				{
                    TempData["SuccessMessage"] = "Girş başarıyla yapıldı.👍";
                    return RedirectToAction("Index", "Default");
                }
             
             
            }

            TempData["DangerMessage"] = "Giriş Yapılmadı Lütfen Bilgileri Kontrol Edip Tekrar Deneyiniz.🤔";
            return RedirectToAction("Index", "Default");
        }
		public async Task<IActionResult> LogOut()
		{
            if (User.Identity.IsAuthenticated)
            {
               
                await _signInManager.SignOutAsync();
                TempData["SuccessMessage"] = "Çıkış Yaptınız .👍";
                return RedirectToAction("Index", "Default");
            }
            else
            {
               
                TempData["DangerMessage"] = "Giriş Yapmamış Gibisiniz.🤔";
                return RedirectToAction("Index", "Default");
            }

            
        }
	}
}
