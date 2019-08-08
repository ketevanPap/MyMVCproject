using System.Collections.Generic;
using MyMVCproject.Models;

namespace MyMVCproject.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType>  MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}