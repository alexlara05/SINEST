using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SINEST.Models
{
    [Table("M_Modules")]
    public class Module
    {
        public Module()
        {
            this.Roles = new HashSet<Role>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Icon { get; set; }

        public int Order { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Program> Programs { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

    }
}