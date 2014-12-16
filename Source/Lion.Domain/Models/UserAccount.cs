using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lion.Domain.Models
{
    public class UserAccount
    {
        [Key]
        public Guid UserID { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        [ScaffoldColumn(false)]
        public short SecretQuestionID { get; set; }

        [StringLength(50)]
        public string SecretAnswer { get; set; }

        [ScaffoldColumn(false)]
        public short UserStatusID { get; set; }

        [StringLength(25)]
        public string Contact1 { get; set; }
        
        [StringLength(25)]
        public string Contact2 { get; set; }
        
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
