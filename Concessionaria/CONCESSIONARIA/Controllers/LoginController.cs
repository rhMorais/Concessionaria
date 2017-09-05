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
            return View();
        }

        public ActionResult Listar()
        {
            var listadeLogins = appLogin.ListarTodos();
            return View(listadeLogins);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]        
        public ActionResult CadastrarLogin(Login login)
        {
            if (ModelState.IsValid)
            {
                appLogin.Salvar(login);
                return Content("Login salvo com sucesso!");
            }
            return Content("Erro no cadastro de login!");
        }

        public ActionResult Editar(string id)
        {
            var login = appLogin.ListarPorId(id);
            if (login == null)
            {
                return Content("Login não encontrado");
            }
            return View(login);
        }

        [HttpPost]        
        public ActionResult EditarLogin(Login login)
        {
            if (ModelState.IsValid)
            {
                appLogin.Salvar(login);
                return Content("Senha alterada com sucesso");
            }
            return Content("Erro ao editar senha!");
        }

        public ActionResult Detalhes(string id)
        {
            var login = appLogin.ListarPorId(id);
            if (login == null)
            {
                return Content("Login não encontrado!");
            }
            return View(login);
        }

        public ActionResult Excluir(string id)
        {
            var login = appLogin.ListarPorId(id);
            if (login == null)
            {
                return Content("Login não encontrado!");
            }
            return View(login);
        }

        [HttpPost]        
        public ActionResult ExcluirLogin(string id)
        {
            var login = appLogin.ListarPorId(id);
            if (login == null)
            {
                return Content("Login não encontrado!");
            }
            return Content("Login excluído com sucesso!");
        }
    }
}