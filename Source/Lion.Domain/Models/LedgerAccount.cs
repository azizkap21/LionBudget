using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lion.Domain.Models
{
    public class LedgerAccount
    {
        [Key]
        public Guid LedgerAccountID { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public Guid UserID { get; set; }

        [Required]
        [StringLength(15)]
        public string LedgerAccountName { get; set; }


        [StringLength(1)]
        public string CrDr { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [ScaffoldColumn(false)]
        public short ParentAccountID { get; set; }

    }
}
