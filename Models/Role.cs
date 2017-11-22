using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SINEST.Models
{
    [Table("M_Roles")]
    public class Role
    {
        public Role()
        {
            this.Modules = new HashSet<Module>();
        }

        [Key]

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
    }
}