using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.Context.Models
{
    public class DefectType
    {
        [Key]
        public int IdDefectType { get; set; }
        [Required]
        public string DefectTypeTitle { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}