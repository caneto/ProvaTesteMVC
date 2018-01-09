using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using BPO.Models;
using BPO.Repositorio;


namespace BPO.Controllers
{
    public class LoginController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.acesso = false;
            ViewBag.nome = "";

            return View();
        }
     

        // POST: /Login/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuarios model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if(UsuarioRepostorio.AutenticarUsuario(model.username, model.password) == false)
            {
                ViewBag.msg_Error = "O nome do usuário ou senha informada estão incorretos!";
            }
   
            return RedirectToAction("Index","Home");
            
        }

        // POST: /Login/Login
        public ActionResult Logout()
        {

            System.Web.HttpContext.Current.Session["usuario"] = ""; 
            

            return RedirectToAction("Index", "Home");
        }
    }
}