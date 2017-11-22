using SINEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SINEST.ViewModels
{
    public class MenuViewModel
    {
        public IEnumerable<Module> Modules { get; set; }
        public IEnumerable<Program> Programs { get; set; }
    }
}