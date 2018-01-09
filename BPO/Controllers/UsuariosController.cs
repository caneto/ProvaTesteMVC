using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BPO.Model;
using BPO.Models;
using System.Data.Entity.Infrastructure;

namespace BPO.Controllers
{
    public class UsuariosController : Controller
    {
        private BPOEntities db = new BPOEntities();
        
        public ActionResult IndexNao()
        {
            ViewBag.Message = "Não Implementado";

            return View();

        }

        public ActionResult Index()
        {
            ViewBag.Message = "Diversos Usuários";

            var UsrLista = (from usr in db.tbl_usuario
                                 join tipo in db.tbl_tipo_usuario on usr.idTipo_Usuario equals tipo.id
                                 orderby usr.nome ascending
                                 select new Usuarios
                                 {
                                     id = usr.id,
                                     nome = usr.nome,
                                     password = usr.password,
                                     username = usr.username,
                                     descricao = tipo.descricao
                                     
                                 }).ToList();


            return View(UsrLista); 

        }

        public ActionResult IndexUsuario()
        {
            ViewBag.Message = "Diversos Usuários";

            var UsrLista = (from usr in db.tbl_usuario
                            orderby usr.nome ascending
                            select new Usuarios
                            {
                                id = usr.id,
                                nome = usr.nome,
                                password = usr.password,
                                username = usr.username,
                                email = usr.email

                            }).ToList();


            return View(UsrLista);

        }

        public ActionResult IndexTipoUsuario()
        {
            ViewBag.Message = "Diversos Usuários - Tipo de Usuário";

            var TipoLista = (from tipo in db.tbl_tipo_usuario
                            orderby tipo.descricao ascending
                            select new Usuarios
                            {
                                id = tipo.id,
                                descricao = tipo.descricao
                                
                            }).ToList();


            return View(TipoLista);

        }


        // GET: Fornecedor/DetalhesUsuario/5
        public ActionResult DetalhesUsuario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var UsrSel = (from usr in db.tbl_usuario
                            where usr.id == id
                            select new Usuarios
                            {
                                id = usr.id,
                                nome = usr.nome,
                                password = usr.password,
                                username = usr.username,
                                email = usr.email

                            }).ToList();
            
            return View(UsrSel);

        }

        // GET: Fornecedor/DetalhesTipoUsuario/5
        public ActionResult DetalhesTipoUsuario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var UsrSel = (from usr in db.tbl_tipo_usuario
                          where usr.id == id
                          select new Usuarios
                          {
                              id = usr.id,
                              descricao = usr.descricao

                          }).ToList();

            return View(UsrSel);

        }

        // GET: Usuarios/EditTipoContrato/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_usuario usuario = await db.tbl_usuario.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }

            PopulaAssignedTipoUsuarioData(usuario.idTipo_Usuario);

            return View(usuario);
        }

        // GET: Usuarios/EditTipoUsuario/5
        public async Task<ActionResult> EditTipoUsuario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_tipo_usuario usuario = await db.tbl_tipo_usuario.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);
        }

        public ActionResult CreateUsuario()
        {

            PopulaAssignedTipoUsuarioData();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUsuario([Bind(Include = "nome, password, email, username, idTipo_Usuario")] tbl_usuario usuario)
        {
            if (ModelState.IsValid)
            {
                //Criptografa a senha
                //usuario.password = Repositorio.DiversosRepostorio.getMD5Hash(usuario.password).ToLower();

                db.tbl_usuario.Add(usuario);
                db.SaveChanges();

                //Repositorio.LogSistemasRepositorio.GravaLog((int)System.Web.HttpContext.Current.Session["idUsuario"], "Usuario", "Criando Registro : " + usuario.id);

                return RedirectToAction("IndexUsuario");
            }
            
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, byte[] rowVersion)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var usuarioToUpdate = db.tbl_usuario.Find(id);

            if (TryUpdateModel(usuarioToUpdate, "",
               new string[] { "nome", "password", "email", "username", "idTipo_Usuario" }))
            {
                try
                {
                    if (String.IsNullOrWhiteSpace(usuarioToUpdate.nome))
                    {
                        usuarioToUpdate.nome = null;
                    }
                    
                    //Criptografa a senha
                    //usuarioToUpdate.password = Repositorio.DiversosRepostorio.getMD5Hash(usuarioToUpdate.password).ToLower();
                    
                    db.Entry(usuarioToUpdate).State = EntityState.Modified;
                    db.SaveChanges();

                    //Repositorio.LogSistemasRepositorio.GravaLog((int)System.Web.HttpContext.Current.Session["idUsuario"], "Usuario", "Editando Registro : " + usuarioToUpdate.id);

                    return RedirectToAction("IndexUsuario");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Não foi possível salvar as alterações. Tente de novo, e se o problema persistir, consulte o administrador do sistema.");
                }
            }

            return View(usuarioToUpdate);
        }

        public ActionResult CreateTipoUsuario()
        {
           return View();
        }


        private void PopulaAssignedTipoUsuarioData(object tipo_usuario_id = null)
        {
            var tipo_usuario = from d in db.tbl_tipo_usuario
                                orderby d.descricao
                                select d;

            ViewBag.idTipo_Usuario = new SelectList(tipo_usuario, "id", "descricao", tipo_usuario_id);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
         //       db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
