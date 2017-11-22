using SINEST.Context;
using SINEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINEST.Services
{
    // Interfaz
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUserByUsername(string username);
        User GetUserById(int id);
    }

    // Clase implementa la interfaz. Recordar hacer el Bind en App_Start.NinjectWebCommon.cs 
    public class UserService : IUserService
    {
        private SinestContext _context;

        public UserService(SinestContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.Where(u => u.Username.Equals(username) && u.IsActive.Equals(true)).FirstOrDefault();
        }
    }
}