using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lion.Domain.Models
{
    public class Budget
    {
        [Key]
        public Guid BudgetID {get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public Guid LedgerAccountID { get; set; }

        [Required]
        public int BudgetAmount { get; set; }

        [Required]
        public short BudgetPeriod { get; set; }


        public virtual LedgerAccount LedgerAccount { get; set; }


    }
}
