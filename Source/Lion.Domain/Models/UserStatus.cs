using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lion.Domain.Models
{
    public class UserStatus
    {
        [Key]
        public short UserStatusID { get; set; }

        [StringLength(15)]
        public string UserStatus { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

    }
}
