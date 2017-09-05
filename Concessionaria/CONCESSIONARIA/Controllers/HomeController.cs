using Concessionaria.Aplicacao.Aplicacoes;
using Concessionaria.Aplicacao.Construtores;
using CONCESSIONARIA.ControleLogin;
using System.Web.Mvc;

namespace CONCESSIONARIA.Controllers
{
    public class HomeController : AuthController
    {
        readonly ExcelAplicacao _appExcel;

        public HomeController()
        {
            _appExcel = ExcelConstrutor.ExcelAplicacao();            
        }

        public ActionResult Index()
        {           
            return View();
        }       

        public FileContentResult Excel()
        {                     
            return new FileContentResult(_appExcel.GerarExcel(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
      
    }
}