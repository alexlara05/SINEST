using Newtonsoft.Json;
using SINEST.Context;
using SINEST.Helpers;
using SINEST.Models;
using SINEST.Models.ViewModels;
using SINEST.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SINEST.Controllers
{
    public class ModulesController : Controller
    {
        private ICommonService _commonService;
        private IModuleService _moduleService;

        public ModulesController(ICommonService commonService, IModuleService moduleService)
        {
            _commonService = commonService;
            _moduleService = moduleService;
        }

        // GET: Module
        // [Authenticated]
        public ActionResult Index()
        {
            var model = new List<ModuleViewModel>();

            foreach (var md in _moduleService.GetModules())
            {
                var module = new ModuleViewModel()
                {
                    Id = md.Id,
                    Name = md.Name,
                    Icon = md.Icon,
                    Order = md.Order,
                    IsActive = md.IsActive
                };

                model.Add(module);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult New()
        {
            var model = new ModuleViewModel();
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult New(ModuleViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newModule = new Module();
                    newModule.IsActive = true;
                    newModule.Name = model.Name;
                    newModule.Icon = model.Icon;
                    newModule.Order = model.Order;

                    _moduleService.Add(newModule);

                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = new ModuleViewModel();
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(ModuleViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var editModule = new Module();
                    editModule.IsActive = true;
                    editModule.Name = model.Name;
                    editModule.Icon = model.Icon;
                    editModule.Order = model.Order;

                    _moduleService.Edit(editModule);

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