using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Context.Models
{
    public class Spare
    {
        [Key]
        public int IdSpare { get; set; }
        [Required]
        public string SpareTitle { get; set; }
        public ICollection<RequestSpares> RequestSpares { get; set; }
    }
}
