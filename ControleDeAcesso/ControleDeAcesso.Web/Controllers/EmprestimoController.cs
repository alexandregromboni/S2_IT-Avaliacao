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
    public class EmprestimoController : BaseController
    {
        IEmprestimoBusiness _emprestimoBusiness = new EmprestimoBusiness();
        IUsuarioBusiness _usuarioBusiness = new UsuarioBusiness();
        IJogoBusiness _jogoBusiness = new JogoBusiness();

        public ActionResult Index(int? pagina)
        {
            int paginaNumero = (pagina ?? 1);
            var lstEmprestimos = Mapper.Map<IEnumerable<Emprestimo>, IEnumerable<EmprestimoViewModel>>(_emprestimoBusiness.GetEmprestimo().ToList());

            return View(lstEmprestimos.ToList().ToPagedList(paginaNumero, paginaTamanho));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EmprestimoViewModel emprestimoViewModel = Mapper.Map<Emprestimo, EmprestimoViewModel>(_emprestimoBusiness.GetEmprestimo(id).FirstOrDefault());

            if (emprestimoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(emprestimoViewModel);
        }

        public ActionResult Create()
        {
            ViewBag.ID_LOGIN = new SelectList(Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioBusiness.GetUsuario().ToList()), "IdUsuario", "Nome");
            ViewBag.ID_JOGO = new SelectList(Mapper.Map<IEnumerable<Jogo>, IEnumerable<JogoViewModel>>(_jogoBusiness.GetJogo().ToList()), "IdJogo", "Descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_EMPRESTIMO,ID_JOGO,ID_LOGIN,DATA_EMPRESTIMO")] EmprestimoViewModel emprestimoViewModel)
        {
            if (ModelState.IsValid)
            {
                _emprestimoBusiness.AdicionarEmprestimo(Mapper.Map<EmprestimoViewModel, Emprestimo>(emprestimoViewModel));
                return RedirectToAction("Index");
            }

            ViewBag.ID_LOGIN = new SelectList(Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioBusiness.GetUsuario().ToList()), "IdUsuario", "Nome");
            ViewBag.ID_JOGO = new SelectList(Mapper.Map<IEnumerable<Jogo>, IEnumerable<JogoViewModel>>(_jogoBusiness.GetJogo().ToList()), "IdJogo", "Descricao");
            return View(emprestimoViewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EmprestimoViewModel emprestimoViewModel = Mapper.Map<Emprestimo, EmprestimoViewModel>(_emprestimoBusiness.GetEmprestimo(id).FirstOrDefault());

            if (emprestimoViewModel == null)
            {
                return HttpNotFound();
            }

            ViewBag.ID_LOGIN = new SelectList(Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioBusiness.GetUsuario().ToList()), "IdUsuario", "Nome", emprestimoViewModel.Id_Usuario);
            ViewBag.ID_JOGO = new SelectList(Mapper.Map<IEnumerable<Jogo>, IEnumerable<JogoViewModel>>(_jogoBusiness.GetJogo().ToList()), "IdJogo", "Descricao", emprestimoViewModel.Id_Jogo);

            return View(emprestimoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_EMPRESTIMO,ID_JOGO,ID_LOGIN,DATA_EMPRESTIMO")] EmprestimoViewModel emprestimoViewModel)
        {
            if (ModelState.IsValid)
            {
                _emprestimoBusiness.AlterarEmprestimo(Mapper.Map<EmprestimoViewModel, Emprestimo>(emprestimoViewModel));
                return RedirectToAction("Index");
            }

            ViewBag.ID_LOGIN = new SelectList(Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioBusiness.GetUsuario().ToList()), "IdUsuario", "Nome", emprestimoViewModel.Id_Usuario);
            ViewBag.ID_JOGO = new SelectList(Mapper.Map<IEnumerable<Jogo>, IEnumerable<JogoViewModel>>(_jogoBusiness.GetJogo().ToList()), "IdJogo", "Descricao", emprestimoViewModel.Id_Jogo);

            return View(emprestimoViewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EmprestimoViewModel emprestimoViewModel = Mapper.Map<Emprestimo, EmprestimoViewModel>(_emprestimoBusiness.GetEmprestimo(id).FirstOrDefault());

            if (emprestimoViewModel == null)
            {
                return HttpNotFound();
            }

            return View(emprestimoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmprestimoViewModel emprestimoViewModel = Mapper.Map<Emprestimo, EmprestimoViewModel>(_emprestimoBusiness.GetEmprestimo(id).FirstOrDefault());
            _emprestimoBusiness.ExcluirEmprestimo(Mapper.Map<EmprestimoViewModel, Emprestimo>(emprestimoViewModel));
            return RedirectToAction("Index");
        }

    }
}
