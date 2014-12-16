using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lion.Domain.Models
{
    public class VoucherType
    {
        [Key]
        public short VoucherTypeID { get; set; }

        [StringLength(15)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

    }
}
