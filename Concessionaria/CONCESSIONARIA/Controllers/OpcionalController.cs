using Concessionaria.Aplicacao.Aplicacoes;
using Concessionaria.Aplicacao.Construtores;
using Concessionaria.Dominio;
using CONCESSIONARIA.ControleLogin;
using System.Net;
using System.Web.Mvc;

namespace CONCESSIONARIA.Controllers
{
    public class OpcionalController : AuthController
    {
        private OpcinalAplicacao appOpcional;
    
        public OpcionalController()
        {
            appOpcional = OpcionalAplicacaoConstrutor.OpcionalAplicacao();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {
            var listadeOpcionais = appOpcional.ListarTodos();
            return View(listadeOpcionais);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult CadastrarOpcional(Opcional opcional)
        {
            if (ModelState.IsValid)
            {
                appOpcional.Salvar(opcional);
                return Content("Cadastro concluído.");
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            Response.TrySkipIisCustomErrors = true;
            return Content("Erro no cadastro.");
        }

        public ActionResult Editar(string id)
        {
            var opcional = appOpcional.ListarPorId(id);
            if(opcional == null)
            {
                return Content("Opcional não encontrado!");
            }
            return View(opcional);
        }

        [HttpPost]
        public ActionResult EditarOpcional(Opcional opcional)
        {
            if (ModelState.IsValid)
            {
                appOpcional.Salvar(opcional);
                return Content("Edição concluída");
            }
            return Content("Erro na edição");
        }

       

        public ActionResult Detalhes(string id)
        {
            var opcional = appOpcional.ListarPorId(id);
            if (opcional == null)
            {
                return Content("Opcional não encontrado");
            }
            return View(opcional);
        }

        public ActionResult Excluir (string id)
        {
            var opcional = appOpcional.ListarPorId(id);
            if(opcional == null)
            {
                return Content("Opcional não encontrado!");
            }
            return View(opcional);
        }
        
        public ActionResult ExcluirOpcional(string id)
        {
            var opcional = appOpcional.ListarPorId(id);
            if (opcional == null)
            {
                return Content("Erro na exclusão");
            }
            appOpcional.Excluir(opcional);
            return Content("Opcional exluído");
        }
    }

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    // public ActionResult Cadastrar(Opcional opcional)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        appOpcional.Salvar(opcional);
    //        return RedirectToAction("Index");
    //    }
    //    return View(opcional);
    //}

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Editar(Opcional opcional)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        appOpcional.Salvar(opcional);
    //        return RedirectToAction("Index");
    //    }
    //    return View(opcional);
    //}

    //[HttpPost, ActionName("Excluir")]
    //[ValidateAntiForgeryToken]
    //public ActionResult ExcluirConfirmados(string id)
    //{
    //var opcional = appOpcional.ListarPorId(id);
    //appOpcional.Excluir(opcional);
    //return RedirectToAction("Index");
    //}
}