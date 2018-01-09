using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BPO.Models;
using BPO.Model;

namespace BPO.Repositorio
{
    public class UsuarioRepostorio 
    {

        
        public static bool AutenticarUsuario(string Login, string senha) 
        {
             BPOEntities db = new BPOEntities();
    
             var usuario = (from u in db.tbl_usuario
                           where u.username == Login
                           select u).SingleOrDefault();

            if (usuario == null)
                 return false;

            
            // if (usuario.password.ToUpper() != Repositorio.DiversosRepostorio.getMD5Hash(senha))
             //{
             //    return false;
            // }
            
            
            System.Web.HttpContext.Current.Session["usuario"] = usuario.username;
            System.Web.HttpContext.Current.Session["idUsuario"] = usuario.id;
                       
            return true;
        }

        public static Usuarios GetUsuarioLogado()
        {
            string _Login = (String)HttpContext.Current.Session["usuario"];

            if(_Login == "")
            {
                return null;
            } else {
                BPOEntities db = new BPOEntities();

                Usuarios user = (from u in db.tbl_usuario
                                    join tp in db.tbl_tipo_usuario on u.idTipo_Usuario equals tp.id
                                     where u.username == _Login
                                    select new Usuarios
                                    {
                                       username = u.username,
                                       password = u.password,
                                       id = u.id,
                                       nome = u.nome,
                                       descricao = tp.descricao
                                    }).SingleOrDefault();

                return user;
            }
        }

        public static void Deslogar ()
        {
            //FormsAuthentication.SignOut();
        }

        public static string GetUsuario()
        {
            string _Login = (String)HttpContext.Current.Session["usuario"];
            
            if (_Login == null) _Login = "";

            return _Login;
        }
        
    }
}

/*tbl_contrato_x_fornecedor con = new tbl_contrato_x_fornecedor();

          for (int i = 2; i < 1479; i++)
          {
              con.idContrato = i;
              con.idForncedor = i;

              db.tbl_contrato_x_fornecedor.Add(con);
                
              con = new tbl_contrato_x_fornecedor();
          }

          try
          {
              db.SaveChanges();
          }
          catch (DbEntityValidationException ex)
          {
              // Retrieve the error messages as a list of strings.
              var errorMessages = ex.EntityValidationErrors
                      .SelectMany(x => x.ValidationErrors)
                      .Select(x => x.ErrorMessage);

              // Join the list to a single string.
              var fullErrorMessage = string.Join("; ", errorMessages);

              // Combine the original exception message with the new one.
              var exceptionMessage = string.Concat(ex.Message, " Os erros de validação são: ", fullErrorMessage);

              // Throw a new DbEntityValidationException with the improved exception message.
              throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
          }
          catch (DbUpdateException ex)
          {
              var exception = HandleDbUpdateException(ex);
              throw exception;

          }*/