﻿using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lion.Domain.Models
{
    public class UserAddress
    {
        [Key]
        public Guid UserAddressID { get; set; }

        [ScaffoldColumn(false)]
        public Guid UserAccountID { get; set; }

        [ScaffoldColumn(false)]
        public short AddressType { get; set; }
        
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
        
        [ScaffoldColumn(false)]
        public short CountryID { get; set; }

        public virtual UserAccount UserAccount { get; set; }
        public virtual CountryDetail CountryDetail { get; set; }

    }
}