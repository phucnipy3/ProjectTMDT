﻿namespace Nhom2.TMDT.Service.Account.ViewModels
{
    public class RegisterViewModel
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
        public bool IsMale { get; set; }
    }
}
