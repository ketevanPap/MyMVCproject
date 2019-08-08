using MyMVCproject.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyMVCproject.Dtos
{
    public class CustomerDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:d}")]
        //[Min18YearsIfAmember]
        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage = "The email address is required", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Phone is required")]
        public string PhoneNumber { get; set; }

        public bool IsSubscibedToNewletter { get; set; }
        
        public int MemberShipTypeId { get; set; }
    }
}