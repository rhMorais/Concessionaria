using Concessionaria.Aplicacao.Aplicacoes;
using Concessionaria.Aplicacao.Construtores;
using Concessionaria.Dominio;
using CONCESSIONARIA.ControleLogin;
using System.Web.Mvc;

namespace CONCESSIONARIA.Controllers
{
    public class LoginController : AuthController
    {
        private LoginAplicacao appLogin;

        public LoginController()
        {
            appLogin = LoginAplicacaoConstrutor.LoginAplicacao();
        }

        public ActionResult Index()
        {
            var listadeLogins = appLogin.ListarTodos();
            return View(listadeLogins);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Login login)
        {
            if (ModelState.IsValid)
            {
                appLogin.Salvar(login);
                return RedirectToAction("Index");
            }
            return View(login);
        }

        public ActionResult Editar(string id)
        {
            var login = appLogin.ListarPorId(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Login login)
        {
            if (ModelState.IsValid)
            {
                appLogin.Salvar(login);
                return RedirectToAction("Index");
            }
            return View(login);
        }

        public ActionResult Detalhes(string id)
        {
            var login = appLogin.ListarPorId(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        public ActionResult Excluir(string id)
        {
            var login = appLogin.ListarPorId(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmados(string id)
        {
            var login = appLogin.ListarPorId(id);
            appLogin.Excluir(login);
            return RedirectToAction("Index");
        }
    }
}