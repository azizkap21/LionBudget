using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lion.Domain.Models
{
    public class Budget
    {
        [Key]
        public Guid BudgetID {get; set; }

        [ScaffoldColumn(false)]
        public Guid LedgerAccountID { get; set; }
        
        
        public int BudgetAmount { get; set; }
        
        
        public short BudgetPeriod { get; set; }


        public virtual LedgerAccount LedgerAccount { get; set; }


    }
}
