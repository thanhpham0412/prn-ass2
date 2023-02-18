using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using BusinessObject.Validation;

#nullable disable

namespace BusinessObject
{
    public partial class StaffAccount
    {
        [Required, UniqueIdValidation(typeof(StaffAccount))]
        public string StaffId { get; set; }
        [Required]
        public string FullName { get; set; }
        [EmailAddress, Required, UniqueEmailValidation]
        public string Email { get; set; }
        [DataType(DataType.Password), Required]
        public string Password { get; set; }
        public int? Role { get; set; }
    }
}
