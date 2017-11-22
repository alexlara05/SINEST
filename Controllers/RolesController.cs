using SINEST.Models;
using SINEST.Models.ViewModels;
using SINEST.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SINEST.Controllers
{
    public class RolesController : Controller
    {
        private ICommonService _commonService;
        private IRolService _roleService;

        public RolesController(ICommonService commonService, IRolService roleService)
        {
            _commonService = commonService;
            _roleService = roleService;
        }

        // GET: Role
        // [Authenticated]
        public ActionResult Index()
        {
            var model = new List<RolViewModel>();

            foreach (var md in _roleService.GetRoles())
            {
                var role = new RolViewModel()
                {
                    Id = md.Id,
                    Name = md.Name,
                    IsActive = md.IsActive
                };

                model.Add(role);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult New()
        {
            var model = new RolViewModel();
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult New(RolViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newRole = new Role();
                    newRole.IsActive = true;
                    newRole.Name = model.Name;

                    _roleService.Add(newRole);

                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(model);
        }

    }
}
