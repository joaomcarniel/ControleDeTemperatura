using EdicoesEmMassa.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EdicoesEmMassa.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard");
                //return Json(new { message = "Usuário Logado Com Sucesso!" });

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ValidateLogin(string userName, string pass, bool keepLogin)
        {
            var credentials = _loginService.ValidateLogin(userName, pass);
            if (credentials != null)
            {
                await HttpContext.SignInAsync(credentials, new AuthenticationProperties
                {
                    IsPersistent = keepLogin,
                    ExpiresUtc = DateTime.Now.AddHours(1)
                });
                return RedirectToAction("Index", "Dashboard");

            }
            return Json(new {message = "Usuário não encontrado, verifique suas credenciais!"});
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
