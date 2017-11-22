using SINEST.Context;
using SINEST.Helpers;
using SINEST.Models;
using SINEST.Services;
using SINEST.ViewModels;
using System.Linq;
using System.Web.Mvc;
using Tracing.Helpers;

namespace SINEST.Controllers
{
    public class LoginController : Controller
    {
        // Referencia a la interfaz
        private IUserService _userService;

        // Modifica el constructor por defecto de la clase. He inyetamos la referencia a la interfaz
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Login      
        [HttpGet]
        public ActionResult Index()
        {
            // Si el usuario esta logueado he intenta ir al login. Lo envio al HomeController
            if (Global_Helper.ifLoggedIn())
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult LogIn(string user, string password)
        {
            if (ModelState.IsValid)
            {
                var encriptedPassword = Encrypt_Helper.SHA256(password);

                var userQuery = _userService.GetUserByUsername(user);
                if (userQuery != null)
                {
                    // Crear las variables de sesion
                    Session["LoggedUserID"] = userQuery.Id.ToString();
                    Session["LoggedUserFullName"] = userQuery.FirstName.ToString() + " " + userQuery.FirstSurname.ToString();
                    Session["LoggedUserRoleID"] = userQuery.RoleId.ToString();
                    Session["LoggedUserRoleName"] = userQuery.Role.Name.ToString();
                }
                else
                {
                    return Json(new
                    {
                        LoginCode = -1,
                    });
                }
            }
            //  return RedirectToAction("Index");
            return Json(new
            {
                LoginCode = 1,
                redirectUrl = Url.Action("Index", "Home"),
                isRedirect = true
            });
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}