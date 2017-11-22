using SINEST.Context;
using SINEST.Models;
using SINEST.Services;
using SINEST.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SINEST.Controllers
{
    public class MenuController : Controller
    {
        private SinestContext _context = new SinestContext();
        private IRolService _rolService;
        private IProgramService _programService;

        public MenuController(IRolService rolService, IProgramService programService)
        {
            _rolService = rolService;
            _programService = programService;
        }

        SinestContext db = new SinestContext();
        // GET: Menu
        public ActionResult Index()
        {
            var RolSesionId = 0;

            if (Session["LoggedUserRoleID"] != null)
            {
                RolSesionId = Convert.ToInt32(Session["LoggedUserRoleID"].ToString());
            }

            var rol = _rolService.GetRolById(RolSesionId);
            var model = new MenuViewModel();

            if (rol != null)
            {
                if (rol.Id == 1)
                {
                    model.Modules = _context.Modules.Where(p => p.IsActive.Equals(true)).ToList().OrderBy(p => p.Order);
                }
                else
                {
                    model.Modules = rol.Modules.Where(p=>p.IsActive.Equals(true)).ToList().OrderBy(p => p.Order);
                }
                model.Programs = _programService.GetPrograms().Where(p => p.IsActive.Equals(true));
            }

            return PartialView("_MenuPartial", model);
        }
    }
}