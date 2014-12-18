using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lion.Domain.Models
{
    public class LedgerAccount
    {
        [Key]
        public Guid LedgerAccountID { get; set; }

        [ScaffoldColumn(false)]
        public Guid UserID { get; set; }

        [StringLength(15)]
        public string Account { get; set; }

        [StringLength(1)]
        public string CrDr { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [ScaffoldColumn(false)]
        public short ParentAccountID { get; set; }

    }
}
