using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentacionLayer.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            var result = BL.Usuario.getUsers();

            List<ML.Usuario> usuarioList = new List<ML.Usuario>();

            usuarioList = ConvertLista(result);

            return View(usuarioList);
        }

        public ActionResult Delete(int id)
        {
            var result = BL.Usuario.UserDelete(id);

            result = BL.Usuario.getUsers();

            List<ML.Usuario> usuarioList = new List<ML.Usuario>();

            usuarioList = ConvertLista(result);

            return View("Index", usuarioList);

        }

        [HttpPost]
        public bool UsuarioAdd(ML.Usuario usuario)
        {
            if (usuario.IdUsuario == 0)
            {
                var result = BL.Usuario.AddUser(usuario);
                return result.Correct;
            }
            else
            {
                var result = BL.Usuario.UpdateUser(usuario);
                return result.Correct;
            }
        }

        [HttpPost]
        public ActionResult GetUser(int id)
        {
            ML.Result result = new ML.Result();
            result = BL.Usuario.GetUsuario(id);

            ML.Usuario usuarioItem = new ML.Usuario();
            usuarioItem.IdUsuario = ((ML.Usuario)result.Object).IdUsuario;
            usuarioItem.Nombres = ((ML.Usuario)result.Object).Nombres;
            usuarioItem.ApellidoPaterno = ((ML.Usuario)result.Object).ApellidoPaterno;
            usuarioItem.ApellidoMaterno = ((ML.Usuario)result.Object).ApellidoMaterno;
            usuarioItem.UsuarioName = ((ML.Usuario)result.Object).UsuarioName;
            usuarioItem.Password = ((ML.Usuario)result.Object).Password;
            usuarioItem.Email = ((ML.Usuario)result.Object).Email;
            usuarioItem.Tipo = ((ML.Usuario)result.Object).Tipo;
            usuarioItem.Rol = ((ML.Usuario)result.Object).Rol;
            usuarioItem.Telefono = ((ML.Usuario)result.Object).Telefono;
         

            return Json(usuarioItem);
        }


        public List<ML.Usuario> ConvertLista(ML.Result result)
        {
            List<ML.Usuario> usuarioList = new List<ML.Usuario>();

            foreach (var lineaItem in result.Objects)
            {
                ML.Usuario usuarioItem = new ML.Usuario();
                usuarioItem.IdUsuario = ((ML.Usuario)lineaItem).IdUsuario;
                usuarioItem.Nombres = ((ML.Usuario)lineaItem).Nombres;
                usuarioItem.ApellidoPaterno = ((ML.Usuario)lineaItem).ApellidoPaterno;
                usuarioItem.ApellidoMaterno = ((ML.Usuario)lineaItem).ApellidoMaterno;
                usuarioItem.UsuarioName = ((ML.Usuario)lineaItem).UsuarioName;
                usuarioItem.Password = ((ML.Usuario)lineaItem).Password;
                usuarioItem.Email = ((ML.Usuario)lineaItem).Email;
                usuarioItem.Tipo = ((ML.Usuario)lineaItem).Tipo;
                usuarioItem.Rol = ((ML.Usuario)lineaItem).Rol;
                usuarioItem.Telefono = ((ML.Usuario)lineaItem).Telefono;
                usuarioList.Add(usuarioItem);
            }


            return (usuarioList);

        }
    }
}
