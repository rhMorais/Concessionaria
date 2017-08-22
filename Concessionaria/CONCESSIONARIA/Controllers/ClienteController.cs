using Concessionaria.Aplicacao.Aplicacoes;
using Concessionaria.Aplicacao.Construtores;
using Concessionaria.Dominio;
using System.Web.Mvc;

namespace CONCESSIONARIA.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private ClienteAplicacao appCliente;

        public ClienteController()
        {
            appCliente = ClienteAplicacaoConstrutor.ClienteAplicacao();
        }

        public ActionResult Index()
        {
            var listadeClientes = appCliente.ListarTodos();
            return View(listadeClientes);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                appCliente.Salvar(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Editar(string id)
        {
            var cliente = appCliente.ListarPorId(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                appCliente.Salvar(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Detalhes(string id)
        {
            var cliente = appCliente.ListarPorId(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        public ActionResult Excluir(string id)
        {
            var cliente = appCliente.ListarPorId(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmados(string id)
        {
            var cliente = appCliente.ListarPorId(id);
            appCliente.Excluir(cliente);
            return RedirectToAction("Index");
        }
    }
}