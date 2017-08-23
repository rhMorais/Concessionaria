using Concessionaria.Aplicacao.Aplicacoes;
using Concessionaria.Aplicacao.Construtores;
using Concessionaria.Dominio;
using System.Web.Mvc;

namespace CONCESSIONARIA.Controllers
{
    public class VendaController : Controller
    {
        private VendaAplicacao appVenda;
        private CarroAplicacao appCarro;
        private ClienteAplicacao appCliente;

        public VendaController()
        {
            appVenda = VendaAplicacaoConstrutor.VendaAplicacaoADO();
            appCarro = CarroAplicacaoConstrutor.CarroAplicacao();
            appCliente = ClienteAplicacaoConstrutor.ClienteAplicacao();
        }
        public ActionResult Index()
        {
            var listadeVendas = appVenda.ListarTodos();
            return View(listadeVendas);
        }

        public ActionResult Cadastrar()
        {
            ViewBag.Cliente = appCliente.ListarTodos();
            ViewBag.Carro = appCarro.ListarTodos();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Venda venda)
        {
            if (ModelState.IsValid)
            {
                appVenda.Salvar(venda);
                return RedirectToAction("Index");
            }
            return View(venda);
        }
    }
}