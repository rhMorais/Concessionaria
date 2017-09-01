using Concessionaria.Aplicacao.Aplicacoes;
using Concessionaria.Aplicacao.Construtores;
using Concessionaria.Dominio;
using System.Web.Mvc;

namespace CONCESSIONARIA.Controllers
{
    public class EfetuarLoginController : Controller
    {
        private LoginAplicacao appLogin;

        public EfetuarLoginController()
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
                Session["UsuarioLogado"] = login.Logusuar;
                return RedirectToAction("Index", "Home");
            }
            return View(login);
        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logoff()
        {            
            Session["UsuarioLogado"] = null;
            return Redirect("Index");
        }
    }
}