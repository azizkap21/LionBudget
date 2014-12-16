using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        public short QuestionID { get; set; }

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

      // One to Many relation with Address hence Ilist
        //Virtual keyword is used for Lazy Loading
        public virtual IList<UserAddress> UserAddresses { get; set;}

        // One to One relation with SecurityQuestion
        // If Property Names are same then we do not have to mention [Foreign Key] attribute
        public virtual SecurityQuestion Question { get; set; }

        // One to One relation with UserStatus
        public virtual UserStatus UserStatus{ get; set; }
    }
}
