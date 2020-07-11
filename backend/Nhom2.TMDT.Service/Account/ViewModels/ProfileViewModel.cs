using System;
using System.Collections.Generic;
using System.Text;

namespace Nhom2.TMDT.Service.Account.ViewModels
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public bool IsMale { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
