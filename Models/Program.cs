using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SINEST.Models
{
    [Table("M_Programs")]
    public class Program
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LinkUrl { get; set; }

        public int Order { get; set; }

        public bool IsActive { get; set; }

        public int ModuleId { get; set; }
        public virtual Module Module { get; set; }

    }
}