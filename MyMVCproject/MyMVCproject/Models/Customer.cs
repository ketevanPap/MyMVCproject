using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data;

namespace MyMVCproject.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //[Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Min18YearsIfAmember]
        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage = "The email address is required", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Phone is required")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public bool IsSubscibedToNewletter { get; set; }

        public MembershipType MembershipType { get; set; }
        
        [Display(Name = "Membership Type")]
        public int MemberShipTypeId { get; set; }
    }
}