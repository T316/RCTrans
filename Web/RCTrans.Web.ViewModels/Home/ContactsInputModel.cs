namespace RCTrans.Web.ViewModels.Home
{
    using System.ComponentModel.DataAnnotations;

    public class ContactsInputModel
    {
        [Required(ErrorMessage = "Името е задължително.")]
        [StringLength(50, ErrorMessage = "Имената трябва да са между {2} и {1} символа.", MinimumLength = 5)]
        [Display(Name = "Име и фамилия")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Имейл адресът е задължителен.")]
        [EmailAddress(ErrorMessage = "Невалиден имейл адрес.")]
        [Display(Name = "Имейл адрес:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Съдържанието е задължително.")]
        [StringLength(500, ErrorMessage = "Съдържанието трябва да е между {2} и {1} символа.", MinimumLength = 10)]
        [Display(Name = "Съдържание")]
        public string Content { get; set; }
    }
}
