using SINEST.Context;
using SINEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SINEST.Services
{
    public interface IProgramService
    {
        IEnumerable<Program> GetPrograms();
    }

    public class ProgramService : IProgramService
    {
        private SinestContext _context;

        public ProgramService(SinestContext context)
        {
            _context = context;
        }

        public IEnumerable<Program> GetPrograms()
        {
            return _context.Programs;
        }

        public Program GetProgramById(int id)
        {
            return _context.Programs.Where(p=>p.Id.Equals(id) && p.IsActive.Equals(true)).FirstOrDefault();
        }
    }
}