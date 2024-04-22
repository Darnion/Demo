using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.Context.Models
{
    public class EquipmentType
    {
        [Key]
        public int IdEquipmentType { get; set; }
        [Required]
        public string EquipmentTypeTitle { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}