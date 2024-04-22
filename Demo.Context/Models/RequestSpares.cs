using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Context.Models
{
    public class RequestSpares
    {
        [Key]
        public int IdRequestSpares { get; set; }
        [ForeignKey("Spare")]
        public int SpareId { get; set;}
        public Spare Spare { get; set; }
        [ForeignKey("Request")]
        public int RequestId { get; set; }
        public Request Request { get; set; }
        [Required]
        public int SparesCount { get; set; } = 1;
    }
}
