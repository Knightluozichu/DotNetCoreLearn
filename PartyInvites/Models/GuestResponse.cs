using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "请填写名字")]
        public string Name { get; set; }
        [Required(ErrorMessage = "请填写邮箱")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "请填写手机")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "请做出选择")]
        public bool? WillAttend { get; set; }
    }
}