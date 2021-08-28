using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentacionLayer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn(string username, string password)
        {
            var result = BL.Usuario.LogIn(username);

            ML.Usuario Usuario = new ML.Usuario();

            if(result.Object != null)
            {

            Usuario.IdUsuario = int.Parse(((ML.Usuario)result.Object).IdUsuario.ToString());
            Usuario.UsuarioName = ((ML.Usuario)result.Object).UsuarioName.ToString();
            Usuario.Password = ((ML.Usuario)result.Object).Password.ToString();


            if (Usuario.UsuarioName == username && Usuario.Password == password)
            {
                Session["LogIn"] = Usuario;
                TempData["LogInMessage"] = "Sesión Iniciada";
                return RedirectToAction("../Main/Index");
            }
            else
            {
                return RedirectToAction("../Home/Index");
            }


            }
            else
            {
                return RedirectToAction("../Home/Index");
            }
        }

        public ActionResult LogOut()
        {
            Session.Remove("LogIn");

            return RedirectToAction("../Home/Index");
        }
    }
}