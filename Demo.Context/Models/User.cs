using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Context.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        [Required]
        public string Fullname { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set;}
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        [ForeignKey("ClientId")]
        public ICollection<Request> RequestClients { get; set; }
        [ForeignKey("WorkerId")]
        public ICollection<Request> RequestWorkers { get; set; }
    }
}
