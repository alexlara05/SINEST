﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SINEST.Models.ViewModels
{
    public class ModuleViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo icono es requerido")]
        public string Icon { get; set; }

        public int Order { get; set; }

        public bool IsActive { get; set; }
    }
}