using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lion.Domain.Models
{
    public class SecurityQuestion
    {
        [Key]
        public short QuestionID { get; set; }

        [StringLength(100)]
        public string Question { get; set; }

    }
}
