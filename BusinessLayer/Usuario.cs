using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {

        public static ML.Result LogIn(string username)
        {
            ML.Result result = new ML.Result();

            try
            {

                using (DataLayer.pruebaEntities1 context = new DataLayer.pruebaEntities1())
                {

                    var UsuarioConsult = context.LoginUsuario(username);

                    if (UsuarioConsult != null)
                    {
                        result.Correct = true;

                        foreach (DataLayer.LoginUsuario_Result usuarioItem in UsuarioConsult)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = Convert.ToInt32(usuarioItem.IdUsuario.ToString());
                            usuario.Nombres = usuarioItem.Nombres.ToString();
                            usuario.ApellidoPaterno = usuarioItem.Nombres.ToString();
                            usuario.ApellidoMaterno = usuarioItem.ApellidoMaterno.ToString();
                            usuario.UsuarioName = usuarioItem.Usuario.ToString();
                            usuario.Password = usuarioItem.Password.ToString();
                            usuario.Email = usuarioItem.Email.ToString();
                            usuario.Tipo = usuarioItem.Tipo.ToString();
                            usuario.Rol = usuarioItem.Rol.ToString();
                            usuario.Telefono = usuarioItem.Telefono.ToString();
                            result.Object = (usuario);
                        }

                    }
                    else
                    {
                        result.Correct = false;
                        result.MessageError = "No existen registros";
                        //No existen registros
                    }


                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.MessageError = ex.Message;
            }


            return result;
        }

        public static ML.Result GetUsuario(int id)
        {
            ML.Result result = new ML.Result();

            try
            {

                using (DataLayer.pruebaEntities1 context = new DataLayer.pruebaEntities1())
                {

                    var UsuarioConsult = context.GetUsuarioId(id).First();

                    result.Objects = new List<object>();

                    if (UsuarioConsult != null)
                    {
                        result.Correct = true;

                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = Convert.ToInt32(UsuarioConsult.IdUsuario.ToString());
                        usuario.Nombres = UsuarioConsult.Nombres.ToString();
                        usuario.ApellidoPaterno = UsuarioConsult.Nombres.ToString();
                        usuario.ApellidoMaterno = UsuarioConsult.ApellidoMaterno.ToString();
                        usuario.UsuarioName = UsuarioConsult.Usuario.ToString();
                        usuario.Password = UsuarioConsult.Password.ToString();
                        usuario.Email = UsuarioConsult.Email.ToString();
                        usuario.Tipo = UsuarioConsult.Tipo.ToString();
                        usuario.Rol = UsuarioConsult.Rol.ToString();
                        usuario.Telefono = UsuarioConsult.Telefono.ToString();
                        result.Object = (usuario);
                    }
                    else
                    {
                        result.Correct = false;
                        result.MessageError = "No existen registros";
                        //No existen registros
                    }


                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.MessageError = ex.Message;
            }

            return result;
        }

        public static ML.Result AddUser(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {

                using (DataLayer.pruebaEntities1 context = new DataLayer.pruebaEntities1())
                {

                    var usuarioConsult = context.UsuarioAdd(usuario.Nombres, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.UsuarioName,  usuario.Telefono, usuario.Email);

                    if (usuarioConsult != null)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.MessageError = "No existen registros";
                        //No existen registros
                    }


                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.MessageError = ex.Message;
            }

            return result;
        }

        public static ML.Result UpdateUser(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {

                using (DataLayer.pruebaEntities1 context = new DataLayer.pruebaEntities1())
                {

                    var usuarioConsult = context.UpdateUsuario(usuario.IdUsuario, usuario.Nombres, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.UsuarioName, usuario.Email, usuario.Telefono);

                    if (usuarioConsult != null)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.MessageError = "No existen registros";
                        //No existen registros
                    }


                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.MessageError = ex.Message;
            }

            return result;
        }
        public static ML.Result getUsers()
        {
            ML.Result result = new ML.Result();

            try
            {

                using (DataLayer.pruebaEntities1 context = new DataLayer.pruebaEntities1())
                {

                    result.Objects = new List<object>();
                    var UsuarioConsult = context.getUsuarios().ToList();

                    if (UsuarioConsult != null)
                    {
                        result.Correct = true;

                        foreach (DataLayer.getUsuarios_Result usuarioItem in UsuarioConsult)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = Convert.ToInt32(usuarioItem.IdUsuario.ToString());
                            usuario.Nombres = usuarioItem.Nombres.ToString();
                            usuario.ApellidoPaterno = usuarioItem.Nombres.ToString();
                            usuario.ApellidoMaterno = usuarioItem.ApellidoMaterno.ToString();
                            usuario.UsuarioName = usuarioItem.Usuario.ToString();
                            usuario.Password = usuarioItem.Password.ToString();
                            usuario.Email = usuarioItem.Email.ToString();
                            usuario.Tipo = usuarioItem.Tipo.ToString();
                            usuario.Rol = usuarioItem.Rol.ToString();
                            usuario.Telefono = usuarioItem.Telefono.ToString();
                            result.Objects.Add(usuario);
                        }

                    }
                    else
                    {
                        result.Correct = false;
                        result.MessageError = "No existen registros";
                        //No existen registros
                    }


                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.MessageError = ex.Message;
            }


            return result;
        }

        public static ML.Result UserDelete(int id)
        {

            ML.Result result = new ML.Result();

            try
            {

                using (DataLayer.pruebaEntities1 context = new DataLayer.pruebaEntities1())
                {

                    var usuarioConsult = context.userDelete(id);

                    if (usuarioConsult != null)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.MessageError = "No se pudo realizar la operacion";
                    }


                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.MessageError = ex.Message;
            }

            return result;
        }


    }
}
