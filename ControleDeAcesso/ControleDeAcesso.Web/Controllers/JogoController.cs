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
    public class JogoController : BaseController
    {
        IJogoBusiness _jogoBusiness = new JogoBusiness();

        public ActionResult Index(int? pagina)
        {
            int paginaNumero = (pagina ?? 1);
            var lstJogos = Mapper.Map<IEnumerable<Jogo>, IEnumerable<JogoViewModel>>(_jogoBusiness.GetJogo().ToList());

            return View(lstJogos.ToPagedList(paginaNumero, paginaTamanho));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            JogoViewModel jogoViewModel = Mapper.Map<Jogo, JogoViewModel>(_jogoBusiness.GetJogo(id).FirstOrDefault());

            if (jogoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(jogoViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JogoViewModel jogoViewModel)
        {
            if (ModelState.IsValid)
            {
                _jogoBusiness.AdicionarJogo(Mapper.Map<JogoViewModel, Jogo>(jogoViewModel));
                return RedirectToAction("Index");
            }

            return View(jogoViewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            JogoViewModel jogoViewModel = Mapper.Map<Jogo, JogoViewModel>(_jogoBusiness.GetJogo(id).FirstOrDefault());

            if (jogoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(jogoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JogoViewModel jogoViewModel)
        {
            if (ModelState.IsValid)
            {
                _jogoBusiness.AlterarJogo(Mapper.Map<JogoViewModel, Jogo>(jogoViewModel));
                return RedirectToAction("Index");
            }
            return View(jogoViewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            JogoViewModel jogoViewModel = Mapper.Map<Jogo, JogoViewModel>(_jogoBusiness.GetJogo(id).FirstOrDefault());

            if (jogoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(jogoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JogoViewModel jogoViewModel = Mapper.Map<Jogo, JogoViewModel>(_jogoBusiness.GetJogo(id).FirstOrDefault());
            _jogoBusiness.ExcluirJogo(Mapper.Map<JogoViewModel, Jogo>(jogoViewModel));
            return RedirectToAction("Index");
        }

    }
}
