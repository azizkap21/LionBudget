﻿using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lion.Domain.Models
{
    public class VoucherDetail
    {
        [Key]
        public Guid VoucherDetailID { get; set; }
        
        [ScaffoldColumn(false)]
        public Guid VoucherHeaderID { get; set; }
        
        [StringLength(50)]
        public string Item { get; set; }
        
        
        public decimal Quantity { get; set; }
        
        
        public decimal UnitPrice { get; set; }
        
        [ScaffoldColumn(false)]
        public Guid LedgerAccountID { get; set; }
        
        
        public decimal Volume { get; set; }
        
        [StringLength(5)]
        public string VolumeMeasure { get; set; }
        
        
        public DateTime CreatedOn { get; set; }

        public virtual LedgerAccount LedgerAccount { get; set; }

    }
}