using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
using Riva.EntityLayer.Entities;
using RivaWebUI.Dtos.ForgetPasswordDtos;
using Microsoft.AspNetCore.Authorization;

namespace RivaWebUI.Controllers
{
    [AllowAnonymous]
    public class ForgetPasswordController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ForgetPasswordController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult ForgetPassword()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordDto forgetPassword)
        {
            var user = await _userManager.FindByEmailAsync(forgetPassword.Email);
            string paswordresertoke = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordresetTokenLink = Url.Action("ResetPassword", "ForgetPassword", new
            {
                userId = user.Id,
                token = paswordresertoke
            }, HttpContext.Request.Scheme);
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom_ = new MailboxAddress("Riva", "ismailkeremgenc@gmail.com");
            MailboxAddress mailboxAddress = new MailboxAddress("User", forgetPassword.Email);

            mimeMessage.From.Add(mailboxAddressFrom_);
            mimeMessage.To.Add(mailboxAddress);
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = " Şifrenizi Yenilemek için Linke Tıklayın.): " + passwordresetTokenLink;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Riva Pide&Kebap Şifre Yenileme ";

            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 587, false);
                smtpClient.Authenticate("ismailkeremgenc@gmail.com", "lwticaaseqvmyuiu");
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);
            }
            return RedirectToAction("Index", "Default");
        }
        [HttpGet]
        public IActionResult ResetPassword(string userid, string token)
        {
            TempData["userid"] = userid;
            TempData["token"] = token;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var userid = TempData["userid"];
            var token = TempData["token"];
            if (userid == null || token == null)
            {
                //Hata Mesajı Eklicem

            }
            var user = await _userManager.FindByIdAsync(userid.ToString());
            var result = await _userManager.ResetPasswordAsync(user, token.ToString(), resetPasswordDto.password);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Şifreniz başarıyla Değiştirildi .👍";
                return RedirectToAction("Index", "Default");
            }
            TempData["DangerMessage"] = "Şifreniz Değiştirilirken Beklenmeyen Bir Hata Oluştu.🤔";
            return RedirectToAction("Index", "Default");
        }
    }
}
