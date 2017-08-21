using Concessionaria.Aplicacao.Aplicacoes;
using Concessionaria.Aplicacao.Construtores;
using Concessionaria.Dominio;
using System.Web.Mvc;

namespace CONCESSIONARIA.Controllers
{
    public class CarroController : Controller
    {
        private CarroAplicacao appCarro;
        private OpcinalAplicacao appOpcional;

        public CarroController()
        {
            appCarro = CarroAplicacaoConstrutor.CarroAplicacao();
            appOpcional = OpcionalAplicacaoConstrutor.OpcionalAplicacao();
        }

        public ActionResult Index()
        {
            var listadeCarros = appCarro.ListarTodos();
            return View(listadeCarros);
        }

        public ActionResult Vendidos()
        {
            var listadeVendidos = appCarro.ListarVendidos();
            return View(listadeVendidos);
        }

        public ActionResult Cadastrar()
        {
            //var opcional = appOpcional.ListarTodos();
            //ViewBag.opcional = new SelectList(opcional, "Opcid", "Opcdescr");
            ViewBag.Opcional = appOpcional.ListarTodos();
            return View();
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Carro carro, int[] Opcional)
        {
            if (ModelState.IsValid)
            {
                appCarro.Salvar(carro, Opcional);                
                return RedirectToAction("Index");
            }
            return View(carro);
        }

        public ActionResult Editar(string id)
        {
            var carro = appCarro.ListarPorId(id);
            if (carro == null)
            {
                return HttpNotFound();
            }            
            return View(carro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Carro carro, int[] Opcional)
        {
            if (ModelState.IsValid)
            {
                appCarro.Salvar(carro, Opcional);
                return RedirectToAction("Index");
            }
            return View(carro);
        }

        public ActionResult Detalhes(string id)
        {
            var carro = appCarro.ListarPorId(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            ViewBag.Opcional = appCarro.ListarOpcionaldoCarro(id);
            return View(carro);
        }

        public ActionResult DetalhesVendidos(string placa)
        {
            var venda = appCarro.ListarDetalhesVendidos(placa);
            if (venda == null)
                return HttpNotFound();
            return View(venda);
        }

        public ActionResult Excluir(string id)
        {
            var carro = appCarro.ListarPorId(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmados(string id)
        {
            var carro = appCarro.ListarPorId(id);
            appCarro.Excluir(carro);
            return RedirectToAction("Index");
        }    
    }
}