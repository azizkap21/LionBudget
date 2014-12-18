﻿using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Lion.Domain.Models
{
    public class VoucherHeader
    {
        [Key]
        public Guid VoucherHeaderID { get; set; }

        [ScaffoldColumn(false)]
        public short VoucherTypeID { get; set; }
        
        
        public DateTime VoucherDate { get; set; }
        
        [StringLength(250)]
        public string Description { get; set; }
        
        [StringLength(1)]
        public string CrDr { get; set; }
        
        [StringLength(25)]
        public string Place { get; set; }
        
        
        public decimal Discount { get; set; }
        
        
        public DateTime CreatedOn { get; set; }

        public virtual VoucherType VoucherType { get; set; }
        public virtual IList<VoucherDetail> VoucherDetail { get; set; }

    }
}