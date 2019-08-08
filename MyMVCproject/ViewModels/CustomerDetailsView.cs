using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMVCproject.ViewModels
{
    public class CustomerDetailsView
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime BirthDay { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public byte DiscountRate { get; set; }

        public byte DurationInMonths { get; set; }

        public short SignUpFee { get; set; }

        public string NameOfMemberShipType { get; set; }
    }
}