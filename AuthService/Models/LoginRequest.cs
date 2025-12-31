using System.ComponentModel.DataAnnotations;

namespace AuthService.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Tài khoản không được để trống!")]
        public string Account { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        public string Pass { get; set; }
    }

}
