using System.ComponentModel;

namespace Nhom2.TMDT.Common.Enums
{
    public enum Role
    {
        [Description("Người quản trị")]
        Admin = 1,
        [Description("Nhân viên")]
        Employee = 2,
        [Description("Khách hàng")]
        Customer = 3
    }
}
