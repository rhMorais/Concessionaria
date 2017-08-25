using System.Web.Mvc;

namespace CONCESSIONARIA.ControleLogin
{
    public class AuthController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["UsuarioLogado"] == null) 
            {
                filterContext.Result = new RedirectResult("/EfetuarLogin/Index");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}