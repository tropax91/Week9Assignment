using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignmentWeek9.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Username")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Display(Name = "Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address is required")]
        [StringLength(80, MinimumLength = 5)]
        public string Address { get; set; }

        [Display(Name = "Zip/Postal code")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Postal code is required")]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        [Display(Name = "City")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "City is required")]
        [StringLength(30, MinimumLength = 5)]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 20 characters")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please confirm Password")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password do not match please confirm your password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}