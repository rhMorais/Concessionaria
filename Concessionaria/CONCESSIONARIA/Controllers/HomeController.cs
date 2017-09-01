using Concessionaria.Aplicacao.Aplicacoes;
using Concessionaria.Aplicacao.Construtores;
using CONCESSIONARIA.ControleLogin;
using System.Web.Mvc;

namespace CONCESSIONARIA.Controllers
{
    public class HomeController : AuthController
    {
        private ExcelAplicacao appExcel;

        public HomeController()
        {
            appExcel = ExcelConstrutor.ExcelAplicacao();            
        }

        public ActionResult Index()
        {           
            return View();
        }

        public ActionResult Teste()
        {
            appExcel.GerarExcel();
            return View("Index");
        }
        public string GerarExcel()
        {                        
            //appExcel.GerarExcel();
            return "penis";
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(Login login)
        //{
        //    if (appLogin.AutenticarUsuario(login))
        //    {
        //        Session["UsuarioLogado"] = login.Logusuar;
        //        return RedirectToAction("Index", "Venda");
        //    }
        //    return View(login);
        //}

    }
}