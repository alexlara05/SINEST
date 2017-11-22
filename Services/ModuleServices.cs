using SINEST.Context;
using SINEST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SINEST.Services
{
    public interface IModuleService
    {
        IEnumerable<Module> GetModules();
        Module GetModuleById(int id);
        void Add(Module nuevoModule);
        void Edit(Module module);
    }

    public class ModuleService : IModuleService
    {
        private SinestContext _context;

        public ModuleService(SinestContext context)
        {
            _context = context;
         //   _context.Configuration.ProxyCreationEnabled = false;
        }

        public IEnumerable<Module> GetModules()
        {
            return _context.Modules;
        }

        public Module GetModuleById(int id)
        {
            return _context.Modules.Find(id);
        }

        public void Add(Module nuevoModule)
        {
            _context.Modules.Add(nuevoModule);
            _context.SaveChangesAsync();
        }

        public void Edit(Module module)
        {
            _context.Entry(module).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }
    }
}