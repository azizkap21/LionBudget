using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lion.Domain.Models
{
    /// <summary>
    /// This class will hold type of addresses like Billing address, Mailing Address etc
    /// </summary>
    public class AddressType
    {
        [Key]
        [ScaffoldColumn(false)]
        public short AddressTypeID { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        /// <summary>
        /// Description of addresstype
        /// </summary>
        [StringLength(50)]
        public string Description { get; set; }


    }
}
