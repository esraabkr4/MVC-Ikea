using System.ComponentModel.DataAnnotations;

namespace Ikea.PL.Models.Account
{
    public class SignUpVM
    {
        [Display(Name ="First Name")]
        public string Fname { get; set; } = null!;
        [Display(Name = "Lst Name")]
        public string Lname { get; set; } = null!;
        public bool IsAgree { get; set; }
        public string UserName { get; set; } = null!;
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Confirm Password Not Match Password")]
        public string ConfirmPassword { get; set; } = null!;
        public string Email { get; set; } = null!;

    }
}
