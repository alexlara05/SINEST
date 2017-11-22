using SINEST.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SINEST.Services
{
    public interface ICommonService
    {
        Task<bool> Save();
    }

    public class CommonService : ICommonService
    {
        private SinestContext _context;

        public CommonService(SinestContext context)
        {
            _context = context;
        }

        public async Task<bool> Save()
        {
            try
            {
                int n = await _context.SaveChangesAsync();

                if (n > 0)
                {
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return false;
        }
    }
}