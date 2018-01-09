using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BPO.Model;
using BPO.Models;
using BPO.Repositorio;
using System.Web.Security;
using System.Data.Entity.SqlServer;
using PagedList;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Text;
using System.Data.Entity;


namespace BPO.Controllers
{
    public class HomeController : Controller
    {
        private BPOEntities db = new BPOEntities();

        public ActionResult Index(int? pagina, string op = null)
        {
                        
            DateTime thisDay = DateTime.Now;


            if (UsuarioRepostorio.GetUsuario().Equals(""))
            {

           
            }

            var mes = thisDay.ToString("MM");
            var ano = thisDay.ToString("yyyy");
            var mesreferencia = mes+"/"+ano;

            Usuarios user = new Usuarios();
                        
            if (UsuarioRepostorio.GetUsuario().Equals(""))
            {
                ViewBag.acesso = false;
                ViewBag.nome = "";
                ViewBag.descricao = "";
                ViewBag.mesreferencia = "";
            }
            else
            {
                user = UsuarioRepostorio.GetUsuarioLogado();
                ViewBag.nome = user.nome;
                ViewBag.descricao = user.descricao;
                ViewBag.mesreferencia = mesreferencia;
                ViewBag.acesso = true;
                
            }

            return View();
        }

        public TimeSpan SubtrairData(DateTime _DataPrincipal, DateTime _DataAComparar)
        {
            return _DataPrincipal.Subtract(_DataAComparar);
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pesquisa(FormCollection collection)
        {
            DateTime thisDay = DateTime.Now;

            String pesquisa1 = collection["pesquisa1"].Trim();
            String pesquisa2 = collection["pesquisa2"].Trim();

            var mes = thisDay.ToString("MM");
            var ano = thisDay.ToString("yyyy");
            var mesreferencia = mes + "/" + ano;

            Usuarios user = new Usuarios();

            if (UsuarioRepostorio.GetUsuario().Equals(""))
            {
                ViewBag.acesso = false;
                ViewBag.nome = "";
                ViewBag.descricao = "";
                ViewBag.mesreferencia = "";
            }
            else
            {
                user = UsuarioRepostorio.GetUsuarioLogado();
                ViewBag.nome = user.nome;
                ViewBag.descricao = user.descricao;
                ViewBag.mesreferencia = mesreferencia;
                ViewBag.acesso = true;

          

            }

            return View();
        }

        
        
        private Exception HandleDbUpdateException(DbUpdateException dbu)
        {
            var builder = new StringBuilder("A DbUpdateException was caught while saving changes. ");

            try
            {
                foreach (var result in dbu.Entries)
                {
                    builder.AppendFormat("Type: {0} was part of the problem. ", result.Entity.GetType().Name);
                }
            }
            catch (Exception e)
            {
                builder.Append("Error parsing DbUpdateException: " + e.ToString());
            }

            string message = builder.ToString();
            return new Exception(message, dbu);
        }

        public ActionResult MenuDiversos()
        {
            ViewBag.Message = "Diversos Opções";

            return View();

        }

        public ActionResult MenuDiversosTabelas()
        {
            ViewBag.Message = "Diversos Opções";

            return View();

        }

        public ActionResult MenuRelatorios()
        {
            ViewBag.Message = "Relatórios";

            return View();

        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}