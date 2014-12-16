using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lion.Domain.Models
{
  
    public class AccountAddress
    {
        [Key]
        [ScaffoldColumn (false)]
        public Guid AccountAddressID { get; set; }

        [ScaffoldColumn (false)]
        public Guid AccountID { get; set; }

        [ScaffoldColumn(false)]
        public short AddressTypeId { get; set; }

        [StringLength(100)]
        public string AddressLine1 { get; set; }

        [StringLength(100)]
        public string AddressLine2 { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(15)]
        public string PostCode { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [ScaffoldColumn (false)]
        public short CountryID { get; set; }

        public virtual UserAccount UserAccount { get; set; }

        public virtual AddressType AddressType { get; set; }

        public virtual CountryDetail CountryDetail { get; set; }
    }
}
