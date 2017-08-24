using Concessionaria.Aplicacao.Aplicacoes;
using Concessionaria.Aplicacao.Construtores;
using Concessionaria.Dominio;
using System.Collections.Generic;
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
        public ActionResult Cadastrar(Carro carro, int[] opcionais)
        {
            var caropcio = new List<Opcional>();
            if (opcionais != null)
            {
                for (var i = 0; i < opcionais.Length; i++)
                    caropcio.Add(new Opcional { Opcid = opcionais[i] });

            }            

            if (ModelState.IsValid)
            {
                appCarro.Salvar(carro);                
                return RedirectToAction("Index");
            }
            return View(carro);
        }

        public ActionResult Editar(string id)
        {
            ViewBag.Opcional = appOpcional.ListarTodos();
            var carro = appCarro.ListarPorId(id);
          
            if (carro == null)
            {
                return HttpNotFound();
            }            
            return View(carro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Carro carro, int[] opcio)
        {
            var caropcio = new List<Opcional>();
            if (opcio != null)
            {                
                for (var i = 0; i < opcio.Length; i++)
                    caropcio.Add(new Opcional { Opcid = opcio[i] });
            }
            else caropcio = null;
            carro.Caropcio = caropcio;
            if (ModelState.IsValid)
            {
                appCarro.Salvar(carro);
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