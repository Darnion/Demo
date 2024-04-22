using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.Context.Models
{
    public class Status
    {
        [Key]
        public int IdStatus { get; set; }
        [Required]
        public string StatusTitle { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}