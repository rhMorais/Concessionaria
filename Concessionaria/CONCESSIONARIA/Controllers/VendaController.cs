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
        readonly VendaAplicacao _appVenda;
        readonly CarroAplicacao _appCarro;
        readonly ClienteAplicacao _appCliente;
        readonly ExcelAplicacao _appExcel;

        public VendaController()
        {
            _appVenda = VendaAplicacaoConstrutor.VendaAplicacaoADO();
            _appCarro = CarroAplicacaoConstrutor.CarroAplicacao();
            _appCliente = ClienteAplicacaoConstrutor.ClienteAplicacao();
            _appExcel = ExcelConstrutor.ExcelAplicacao();
        }
        public ActionResult Index()
        {
            var listadeVendas = _appVenda.ListarTodos();
            return View(listadeVendas);
        }

        public FileContentResult VendasExcel()
        {
            return new FileContentResult(_appExcel.GerarExcelVenda(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public ActionResult Cadastrar()
        {
            var listaClientes = _appCliente.ListarTodos();
            var listaCarros = _appCarro.ListarTodos();
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

            _appVenda.Salvar(venda);
            return RedirectToAction("Index");

        }

        public ActionResult Excluir(string id)
        {
            var venda = _appVenda.ListarPorId(id);
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
            var venda = _appVenda.ListarPorId(id);
            _appVenda.Excluir(venda);
            return RedirectToAction("Index");
        }

        public ActionResult Detalhes(string id)
        {
            var venda = _appVenda.ListarPorId(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }
       
    }
}