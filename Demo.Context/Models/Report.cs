using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Context.Models
{
    public class Report
    {
        [Key]
        [ForeignKey("Request")]
        public int IdReport { get; set; }
        [Required]
        public string ReportContent { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Request Request { get; set; }
    }
}