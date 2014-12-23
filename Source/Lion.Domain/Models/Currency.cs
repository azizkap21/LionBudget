using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lion.Domain.Models
{
    public class Currency
    {
        [Key]
        public short CurrencyID { get; set; }

        [Required]
        [StringLength(3)]
        public string CurrencyCode { get; set; }

        [StringLength(1)]
        public string CurrencySymbol { get; set; }

        [StringLength(25)]
        public string Description { get; set; }

    }
}
