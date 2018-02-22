using AutoMapper;
using PagedList;
using S2Games.Business;
using S2Games.Business.Interface;
using S2Games.Entities;
using S2Games.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace S2Games.Web.Controllers
{
    [Authorize(Roles = "Administrador, Usuario")]
    public class AcessoController : BaseController
    {
        IUsuarioBusiness _usuarioBusiness = new UsuarioBusiness();

        public ActionResult Index(int? pagina)
        {
            int paginaNumero = (pagina ?? 1);

            var lstUsuarios = Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioBusiness.GetUsuario().ToList());
            return View(lstUsuarios.ToPagedList(paginaNumero, paginaTamanho));
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioViewModel usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(_usuarioBusiness.GetUsuario(id).FirstOrDefault());

            if (usuarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(usuarioViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_LOGIN,EMAIL,SENHA,ATIVO,PERFIL,NOME,SOBRENOME")] UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                _usuarioBusiness.AdicionarUsuario(Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel));
                return RedirectToAction("Index");
            }

            return View(usuarioViewModel);
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UsuarioViewModel usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(_usuarioBusiness.GetUsuario(id).FirstOrDefault());

            if (usuarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(usuarioViewModel);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_LOGIN,EMAIL,SENHA,ATIVO,PERFIL,NOME,SOBRENOME")] UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                _usuarioBusiness.AlterarUsuario(Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel));
                return RedirectToAction("Index");
            }
            return View(usuarioViewModel);
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UsuarioViewModel usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(_usuarioBusiness.GetUsuario(id).FirstOrDefault());

            if (usuarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(usuarioViewModel);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioViewModel usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(_usuarioBusiness.GetUsuario(id).FirstOrDefault());
            _usuarioBusiness.ExcluirUsuario(Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel));
            return RedirectToAction("Index");
        }

    }
}
