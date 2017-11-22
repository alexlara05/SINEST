using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SINEST.Models
{
    [Table("M_States")]
    public class State
    {
        [Key]        
        public int Id { get; set; }
                
        public string Name { get; set; }

        public int ProgramId { get; set; }

        public string Description { get; set; }
    }
}