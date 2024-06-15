using Common.Application.Validation;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace Shop.Api.ViewModels.Auth
{
    public  class LoginViewModel
    {
        [Required(ErrorMessage ="شماره تلفن را وارد کنید")]
        [MaxLength(11 , ErrorMessage =ValidationMessages.InvalidPhoneNumber)]
        [MinLength(11 , ErrorMessage = ValidationMessages.InvalidPhoneNumber)]


        public string PHoneNumber { get; set; }

        [Required(ErrorMessage = "رمز عبور را وارد کنید")]
        public string PassWord { get; set; }
    }

    
}
