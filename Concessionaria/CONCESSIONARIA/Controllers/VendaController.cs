using Concessionaria.Aplicacao.Aplicacoes;
using Concessionaria.Aplicacao.Construtores;
using Concessionaria.Dominio;
using CONCESSIONARIA.ControleLogin;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CONCESSIONARIA.Controllers
{
    public class VendaController : AuthController
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

        //public ActionResult GerarExcel()
        //{
        //    var vendas = appVenda.ListarTodos();
        //    return View(vendas);
        //    GerarExcel(vendas);
        //}

        public ActionResult Cadastrar()
        {
            var listaClientes = appCliente.ListarTodos();
            var listaCarros = appCarro.ListarTodos();
            var clientesSelecionaveis = new List<SelectListItem>();
            var carrosSelecionaveis = new List<SelectListItem>();

            foreach (var item in listaClientes)
            {
                clientesSelecionaveis.Add(new SelectListItem
                {
                    Value = item.Clicpf,
                    Text = item.Clinome + " - " + item.Clicpf
                });
            }
            foreach (var item in listaCarros)
            {
                carrosSelecionaveis.Add(new SelectListItem
                {
                    Value = item.Carplaca,
                    Text = item.Carmodel + " - " + item.Carcor + " - " + item.Carplaca
                });
            }
            ViewBag.carros = carrosSelecionaveis;
            ViewBag.clientes = clientesSelecionaveis;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Venda venda)
        {

            appVenda.Salvar(venda);
            return RedirectToAction("Index");

        }

        public ActionResult Excluir(string id)
        {
            var venda = appVenda.ListarPorId(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmados(string id)
        {
            var venda = appVenda.ListarPorId(id);
            appVenda.Excluir(venda);
            return RedirectToAction("Index");
        }

        public ActionResult Detalhes(string id)
        {
            var venda = appVenda.ListarPorId(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }
       
    }
}