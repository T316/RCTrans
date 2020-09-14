namespace RCTrans.Web.ViewModels.Blog
{
    using System.ComponentModel.DataAnnotations;

    public class ArticleCreateInputModel
    {
        [Required(ErrorMessage = "Заглавието е задължително.")]
        [StringLength(50, ErrorMessage = "Заглавието трябва да е между {2} и {1} символа.", MinimumLength = 3)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Съдържанието е задължително.")]
        [StringLength(5000, ErrorMessage = "Съдържанието трябва да е между {2} и {1} символа.", MinimumLength = 10)]
        [Display(Name = "Съдържание")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Картинката е задължителна.")]
        [Display(Name = "Картинка")]
        public string ImageUrl { get; set; }
    }
}
