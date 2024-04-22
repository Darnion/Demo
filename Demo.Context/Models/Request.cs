using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Design;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Context.Models
{
    public class Request
    {
        [Key]
        public int IdRequest { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [ForeignKey("EquipmentType")]
        public int EquipmentTypeId { get; set; }
        public EquipmentType EquipmentType { get; set; }
        [ForeignKey("DefectType")]
        public int DefectTypeId { get; set; }
        public DefectType DefectType { get; set; }
        [Required]
        public string EquipmentModel { get; set; }
        public string Description { get; set; } = string.Empty;
        public int ClientId { get; set; }
        public User Client { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public Status Status { get; set; }
        [Required]
        public int Priority { get; set; } = 0;
        public string Comment { get; set; } = string.Empty;
        public int WorkerId { get; set; }
        public User Worker { get; set; }
        public ICollection<RequestSpares> RequestSpares { get; set; }
        public Report Report { get; set; }
    }
}
