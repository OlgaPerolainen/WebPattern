using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebPatter.WebUI.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Код")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Запомнить браузер?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Адрес электронной почты")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        //[Display(Name = "Запомнить меня")]
        //public bool RememberMe { get; set; }
    }

    public class RegisterViewModel : IValidatableObject
    {
        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя")]
        public virtual string FirstName { get; set; }
        // Фамилия
        [Display(Name = "Фамилия")]
        public virtual string LastName { get; set; }

        [Required(ErrorMessage = "Введите адрес")]
        [EmailAddress]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Данные указаны некорректно")]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите телефон")]
        [Display(Name = "Телефон")]
        public virtual string Phone { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //Не нулевое имя
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                yield return new ValidationResult("Введите имя", new string[] { "FirstName" });
            }
            //Не нулевой Email
            if (string.IsNullOrWhiteSpace(Email))
            {
                yield return new ValidationResult("Введите почту", new string[] { "Email" });
            }
            else
            {
                //корректный Email
                var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.Compiled);
                var match = regex.Match(Email);
                if (!(match.Success && match.Length == Email.Length))
                {
                    yield return new ValidationResult("Данные указаны некорректно", new string[] { "Email" });
                }
            }

            //Не нулевой телефон
            if (string.IsNullOrWhiteSpace(Phone))
            {
                yield return new ValidationResult("Введите телефон", new string[] { "Phone" });
            }

            //корректный телефон
            // else
            //{
            //var regexPhone = new Regex(@"(^8|7|\+7)((\d{10})|(\s\(\d{3}\)\s\d{3}\s\d{2}\s\d{2}))", RegexOptions.Compiled);
            //var matchPhone = regexPhone.Match(Email);
            //if (!(matchPhone.Success && matchPhone.Length == Phone.Length))
            //{
            //    yield return new ValidationResult("Введите корректный телефон", new string[] { "Phone" });
            //}
            //}


            //пароль не нулевой
            if (string.IsNullOrWhiteSpace(Password))
            {
                yield return new ValidationResult("Введите пароль", new string[] { "Password" });
            }

        }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Почта")]
        public string Email { get; set; }
    }
}
