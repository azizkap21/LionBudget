using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lion.Domain.Models
{
    public class UserStatus
    {
        [Key]
        public short UserStatusID { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

    }
}
