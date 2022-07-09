using EdicoesEmMassa.Service;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
        [HttpPost]
        public IActionResult ValidateLogin(string userName, string pass)
        {
            if(_loginService.ValidateLogin(userName, pass))
            {
                return Json(new { message = "Usuário Logado Com Sucesso!"});
            }
            return Json(new {message = "Usuário não encontrado, verifique suas credenciais!"});
        }
    }
}
