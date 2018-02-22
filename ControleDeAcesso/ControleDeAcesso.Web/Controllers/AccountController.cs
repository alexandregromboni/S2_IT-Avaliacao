using S2Games.Business;
using S2Games.Business.Interface;
using S2Games.Web.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace S2Games.Web.Controllers
{
    public class AccountController : BaseController
    {
        /// <param name="returnURL"></param>
        /// <returns></returns>
        public ActionResult Login(string returnURL)
        {
            ViewBag.ReturnUrl = returnURL;
            return View(new LoginViewModel());
        }

        /// <param name="login"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login, string returnUrl)
        {
            IUsuarioBusiness _usuarioBusiness = new UsuarioBusiness();
            
            if (ModelState.IsValid)
            {
                var objUsuario = _usuarioBusiness.GetUsuariosPorEmail(login.Email).FirstOrDefault();

                if (objUsuario != null)
                {
                    if (objUsuario.Is_Ativo)
                    {
                        if (Equals(objUsuario.Senha, login.Senha))
                        {
                            FormsAuthentication.SetAuthCookie(objUsuario.Email, false);
                            if (Url.IsLocalUrl(returnUrl)
                            && returnUrl.Length > 1
                            && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//")
                            && returnUrl.StartsWith("/\\"))
                            {
                                return Redirect(returnUrl);
                            }
                            Session["Nome"] = objUsuario.Nome;
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Senha informada Inválida!");
                            return View(new LoginViewModel());
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Usuário sem acesso para usar o sistema!");
                        return View(new LoginViewModel());
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-mail informado inválido!");
                    return View(new LoginViewModel());
                }

            }
            return View(login);
        }

        public ActionResult Loggout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            return RedirectToAction("Index", "Home");
        }
    }
}