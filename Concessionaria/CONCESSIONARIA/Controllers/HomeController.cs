using Concessionaria.Aplicacao.Aplicacoes;
using CONCESSIONARIA.ControleLogin;
using System.Web.Mvc;

namespace CONCESSIONARIA.Controllers
{
    public class HomeController : AuthController
    {
        private ExcelAplicacao appExcel;       

        public ActionResult Index()
        {           
            return View();
        }


        public void gerarExcel()
        {                        
            appExcel.GerarExcel();
            
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