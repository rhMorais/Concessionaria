using Concessionaria.Aplicacao.Aplicacoes;
using Concessionaria.Aplicacao.Construtores;
using Concessionaria.Dominio;
using System.Web.Mvc;
using System.Web.Security;

namespace CONCESSIONARIA.Controllers
{
    public class AuthController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (true)
            {
                filterContext.Result = new RedirectResult("/controller/action");
            }

            base.OnActionExecuting(filterContext);
        }
    }

    public class HomeController : AuthController
    {
        private LoginAplicacao appLogin;

        public HomeController()
        {
            appLogin = LoginAplicacaoConstrutor.LoginAplicacao();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Login login)
        {            
            if (appLogin.AutenticarUsuario(login))
            {
                FormsAuthentication.SetAuthCookie(login.Logusuar, false);
                return RedirectToAction("Index", "Venda");
            }
            return View(login);
        }                       

    }
}