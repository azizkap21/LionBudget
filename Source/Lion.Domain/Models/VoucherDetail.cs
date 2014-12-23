using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lion.Domain.Models
{
    public class VoucherDetail
    {
        [Key]
        public Guid VoucherDetailID { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public Guid VoucherHeaderID { get; set; }

        [Required]
        [StringLength(50)]
        public string Item { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public Guid LedgerAccountID { get; set; }
        
        
        public decimal Volume { get; set; }
        
        [StringLength(5)]
        public string VolumeMeasure { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public virtual LedgerAccount LedgerAccount { get; set; }

    }
}
