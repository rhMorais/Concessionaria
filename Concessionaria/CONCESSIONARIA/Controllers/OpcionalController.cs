using Concessionaria.Aplicacao.Aplicacoes;
using Concessionaria.Aplicacao.Construtores;
using Concessionaria.Dominio;
using System.Web.Mvc;

namespace CONCESSIONARIA.Controllers
{
    public class OpcionalController : Controller
    {
        private OpcinalAplicacao appOpcional;
    
        public OpcionalController()
        {
            appOpcional = OpcionalAplicacaoConstrutor.OpcionalAplicacao();
        }

        public ActionResult Index()
        {
            var listadeOpcionais = appOpcional.ListarTodos();
            return View(listadeOpcionais);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
         public ActionResult Cadastrar(Opcional opcional)
        {
            if (ModelState.IsValid)
            {
                appOpcional.Salvar(opcional);
                return RedirectToAction("Index");
            }
            return View(opcional);
        }

        public ActionResult Editar(string id)
        {
            var opcional = appOpcional.ListarPorId(id);
            if(opcional == null)
            {
                return HttpNotFound();
            }
            return View(opcional);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Opcional opcional)
        {
            if (ModelState.IsValid)
            {
                appOpcional.Salvar(opcional);
                return RedirectToAction("Index");
            }
            return View(opcional);
        }

        public ActionResult Detalhes(string id)
        {
            var opcional = appOpcional.ListarPorId(id);
            if (opcional == null)
            {
                return HttpNotFound();
            }
            return View(opcional);
        }
    }
}