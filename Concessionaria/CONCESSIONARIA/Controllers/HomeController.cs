using CONCESSIONARIA.ControleLogin;
using System.Web.Mvc;

namespace CONCESSIONARIA.Controllers
{
    public class HomeController : AuthController
    {
        //private LoginAplicacao appLogin;

        //public HomeController()
        //{
        //    appLogin = LoginAplicacaoConstrutor.LoginAplicacao();
        //}

        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(Login login)
        //{
        //    if (appLogin.AutenticarUsuario(login))
        //    {
        //        Session["UsuarioLogado"] = login.Logusuar;
        //        return RedirectToAction("Index", "Venda");
        //    }
        //    return View(login);
        //}

    }
}