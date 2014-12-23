using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Lion.Domain.Models
{
    public class VoucherHeader
    {
        [Key]
        public Guid VoucherHeaderID { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public short VoucherTypeID { get; set; }

        [Required]
        public DateTime VoucherDate { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [StringLength(1)]
        public string CrDr { get; set; }
        
        [StringLength(25)]
        public string Place { get; set; }
        
        public decimal Discount { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public virtual VoucherType VoucherType { get; set; }
        public virtual IList<VoucherDetail> VoucherDetail { get; set; }

    }
}
