using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lion.Domain.Models
{
    public class CountryDetail
    {
        [Key]
        [ScaffoldColumn(false)]
        public short CountryID { get; set; }

        [StringLength(25)]
        public string CountryName { get; set; }

        [StringLength(5)]
        public string CountryCode { get; set; }

        [StringLength(5)]
        public string ISDCode { get; set; }
        
        [ScaffoldColumn(false)]
        public short CurrencyID { get; set; }

        public virtual Currency Currency { get; set; }

    }
}
