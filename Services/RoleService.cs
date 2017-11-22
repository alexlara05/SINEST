using SINEST.Context;
using SINEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SINEST.Services
{
    public interface IRolService
    {
        Role GetRolById(int id);
        IEnumerable<Role> GetRoles();
        void Add(Role nuevoRole);
    }

    public class RolService : IRolService
    {
        private SinestContext _context;

        public RolService(SinestContext context)
        {
            _context = context;
        }

        public Role GetRolById(int id)
        {
            return _context.Roles.Where(r => r.Id.Equals(id) && r.IsActive.Equals(true)).FirstOrDefault();
        }

        public IEnumerable<Role> GetRoles()
        {
            return _context.Roles;
        }

        public void Add(Role nuevoRole)
        {
            _context.Roles.Add(nuevoRole);
            _context.SaveChangesAsync();
        }
    }
}